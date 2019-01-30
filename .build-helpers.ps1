function Clean-Folder {
    param(
        $path
    )

    Remove-Item "$path/*" `
        -Force `
        -Recurse `
        -ErrorAction SilentlyContinue
}

function New-Folder {
    [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSShouldProcess", "", Scope="Function")]
    [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSUseShouldProcessForStateChangingFunctions", "", Scope="Function")]
    param(
        $folder
    )

    if(!(Test-Path $folder))
    {
        New-Item -ItemType Directory -Force -Path $folder | Out-Null
    }
}

function Require-Variable($value, $description) {

    if($value -eq $null) {
        throw "Variable is null: $description"
    }
}

function Edit-ValueInFile($path, $old, $new) {
    (Get-Content $path).replace( $old, $new ) `
        | Set-Content $path
}

function Copy-NetlifyConfig {
    Copy-Item "$dirPath/netlify/*" "$buildFolder/" -Recurse -Force
}

function Set-NetlifyPreVariables() {
    if($null -ne $env:APPVEYOR_REPO_BRANCH) {
        Write-Build Green "Building under appveyor"

        $netlifySiteIdEnvName = ("SPS_NETLIFY_PRE_SITE_ID_" + $env:APPVEYOR_REPO_BRANCH)

        $netlifySiteId    = (get-item env:$netlifySiteIdEnvName).Value;
        $netlifyAuthToken = $env:SPS_NETLIFY_API_KEY

        Require-Variable $netlifySiteId    "Netlify site id"
        Require-Variable $netlifyAuthToken "Netlify auth token"

        $ENV:NETLIFY_SITE_ID   =  $netlifySiteId 
        $ENV:NETLIFY_AUTH_TOKEN = $netlifyAuthToken 
    } else {
        Write-Build Green "Building locally"
        
        Require-Variable $NETLIFY_PRE_SITE_ID  "Netlify site id"
        Require-Variable $NETLIFY_AUTH_TOKEN "Netlify auth token"

        $ENV:NETLIFY_SITE_ID   =  $NETLIFY_PRE_SITE_ID 
        $ENV:NETLIFY_AUTH_TOKEN = $NETLIFY_AUTH_TOKEN 
    }
}

function Set-NetlifyVariables() {
    if($null -ne $env:APPVEYOR_REPO_BRANCH) {
        Write-Build Green "Building under appveyor"

        $netlifySiteIdEnvName = ("SPS_NETLIFY_SITE_ID_" + $env:APPVEYOR_REPO_BRANCH)

        $netlifySiteId    = (get-item env:$netlifySiteIdEnvName).Value;
        $netlifyAuthToken = $env:SPS_NETLIFY_API_KEY

        Require-Variable $netlifySiteId    "Netlify site id"
        Require-Variable $netlifyAuthToken "Netlify auth token"

        $ENV:NETLIFY_SITE_ID   =  $netlifySiteId 
        $ENV:NETLIFY_AUTH_TOKEN = $netlifyAuthToken 
    } else {
        Write-Build Green "Building locally"
        
        Require-Variable $NETLIFY_SITE_ID    "Netlify site id"
        Require-Variable $NETLIFY_AUTH_TOKEN "Netlify auth token"

        $ENV:NETLIFY_SITE_ID   =  $NETLIFY_SITE_ID 
        $ENV:NETLIFY_AUTH_TOKEN = $NETLIFY_AUTH_TOKEN 
    }
}

function Copy-Assets() {
    $imageFolders = Get-ChildItem "$dirPath/docs" -Recurse -Filter *assets*

    foreach($imageFolder in $imageFolders) {
        $path = $imageFolder.FullName

        if($path.EndsWith("docs\assets") -eq $True) {
            continue;
        }

        Copy-Item $path "$dirPath/docs" -Recurse -Force
    }
}