param(
    $NETLIFY_SITE_ID = $null,
    $NETLIFY_PRE_SITE_ID = $null,

    $NETLIFY_AUTH_TOKEN = $null
)

$dirPath = $BuildRoot

. "$dirPath/.build-helpers.ps1"

$buildFolder = "$dirPath/build-docs"
$buildaAtifactsFolder = "$dirPath/build-artifacts"

$webSiteFolders = @(
    "website"
)

Enter-Build {
    
    Write-Build Green "Building documentation..."
    
    New-Folder $buildFolder 
    New-Folder $buildaAtifactsFolder 
}

task NpmInstall {
    Write-Build Green "[~] running npm install"
    exec {
        pwsh -c "cd tests; npm install --silent --save-dev"
    }
}

task NetlifyInstall {
    if($null -eq (Get-Command netlify -ErrorAction SilentlyContinue) ) {
        npm config set error

        npm install netlify-cli -g --silent
        npm install typescript  -g --silent
    } else {
        Write-Build Green "[+] netlify-cli"
    }
}

task ShowTools {
    Write-Build Green "Using netlify cli:"
    netlify --version
}

# Synopsis: Cleans local build folders
task Clean {
    Clean-Folder $buildFolder 
    Clean-Folder $buildaAtifactsFolder 
}

# Synopsis: Serves web site with docusaurus
task Start {

    Copy-Assets

    foreach ($webSiteFolder in $webSiteFolders) {
        Write-Build Green "[~] starting web: $webSiteFolder"

        exec {
            pwsh -c "cd $webSiteFolder; yarn install --silent 2>&1; yarn start"
        }
    }
}

# Synopsis: Builds web site
task Build {

    Copy-Assets

    foreach ($webSiteFolder in $webSiteFolders) {
        Write-Build Green "[~] building web: $webSiteFolder"

        exec {
            pwsh -c "cd $webSiteFolder; yarn install --silent 2>&1"
            pwsh -c "cd $webSiteFolder; yarn build"
        }

        $buildFolder = "$webSiteFolder/build/docs/"
        
        # https://developers.google.com/web/tools/lighthouse/run
        # <html> element does not have a [lang] attribute
        # html lang=""
        $htmlFiles = Get-ChildItem $buildFolder -Filter "*.html" -Recurse

        foreach($htmlFile in $htmlFiles) {
            Edit-ValueInFile $htmlFile.FullName `
                'html lang=""' `
                'html lang="en"'
        }
    }
}

# Synopsis: Copies web site to the build folder
task Copy {
    foreach ($webSiteFolder in $webSiteFolders) {
        Write-Build Green "[~] copying web: $webSiteFolder"

        Copy-Item "$webSiteFolder/build/docs/*" `
            $buildFolder `
            -Recurse `
            -Force
    }
}

# Synopsis: Serves local web site using http-server
task Serve {
    http-server $buildFolder
}

# Synopsis: Deploys web site to netlify
task NetlifyDeploy {
    
    Set-NetlifyVariables
    Copy-NetlifyConfig

    Start-NetlifyCmd "deploy --dir $buildFolder"
}

function Start-NetlifyCmd($cmdArgumentList) {
    $process = Start-Process "netlify" `
        -ArgumentList $cmdArgumentList `
        -PassThru -Wait
    
    if($process.ExitCode -ne 0) {
        throw "Exit code: $($process.ExitCode) - cannot execite netlify cmd: $cmdArgumentList"
    }
}

task NetlifyPrePublish {
    Set-NetlifyPreVariables
    Copy-NetlifyConfig

    Write-Build Green "Pre-publishing netlify web site"
    Start-NetlifyCmd "deploy --dir $buildFolder --prod"

    $siteUrl = "http://localhost:3000"

    if($null -ne $env:APPVEYOR_REPO_BRANCH) { 
        switch (($env:APPVEYOR_REPO_BRANCH).ToLower()) {

            "dev"    { $siteUrl = "https://subpointsolutions-docs-dev-pre.netlify.com"    }
            "beta"   { $siteUrl = "https://subpointsolutions-docs-beta-pre.netlify.com"   }
            "master" { $siteUrl = "https://subpointsolutions-docs-master-pre.netlify.com" }

            default { 
                throw ( "Unknown branch: $($env:APPVEYOR_REPO_BRANCH)" )
            }
        }
    }

    $ENV:SITE_URL = $siteUrl 
    $ENV:SITE_MAP = "tests/data/sitemap-docs.subpointsolutions.com.xml"

    Write-Build Green "QA against: $siteUrl"

    Write-Build Green "[~] running site map validation"
    exec {
        node tests/run-validate-sitemap.js
    }

    Write-Build Green "[~] running broken links check"
    exec {
        node tests/run-broken-link-checker.js
    }

    Write-Build Green "[+] prepublishing is ok!"
}

# Synopsis: Publishes web site to netlify
task NetlifyPublish {
    
    Set-NetlifyVariables
    Copy-NetlifyConfig

    Start-NetlifyCmd "deploy --dir $buildFolder --prod"
}

# Synopsis: Generates SPMeta2 examples page
task GenerateSPMeta2ExampleIndex {
   
    Write-Build Green "[~] running checks.."
    exec {
        pwsh -c "cd website; node generateSPMeta2ScenariosIndex.js"
    }
}

# Synopsis: Validates broken links against deployed web site
task ValidateBrokenLinks {
    
    Write-Build Green "[~] running checks.."
    exec {
        
        node tests/run-broken-link-checker.js
    }
}

# Synopsis: Validates sitemap against deployed web site
task ValidateSiteMap {

    $ENV:SITE_MAP = "tests/data/sitemap-docs.subpointsolutions.com.xml"

    exec {
        node tests/run-validate-sitemap.js
    }
}

# Synopsis: Creates a zip package with the giving web site
task CreateZipArchive {
    Remove-Item $buildaAtifactsFolder\* -Recurse -Force
    Compress-Archive .\build-docs\* $buildaAtifactsFolder\subpointsolutions-docs.zip -Force 
}

# Synopsis: Executes Appveyor specific setup
task AppveyorPrepare {

}

# Synopsis: Executes netlify publishing to the giving web site
task DefaultBuild Clean, Build, Copy

# Synopsis: Executes netlify deploy to the giving web site
task NetlifyRedeploy DefaultBuild, NetlifyDeploy

# Synopsis: Executes netlify publishing to the giving web site
task NetlifyRepublish DefaultBuild, NetlifyPublish

# Synopsis: Executes netlify publishing under Appveyor
task Appveyor AppveyorPrepare, 
    NpmInstall, 
    NetlifyInstall,
    ShowTools,
    DefaultBuild, 
    CreateZipArchive, 
    NetlifyPrePublish, 
    NetlifyPublish 

# Synopsis: Defualt build for local and CI based execution
task . DefaultBuild