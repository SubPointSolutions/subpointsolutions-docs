---
Title		: "CakeBuildTools"
Description	: ""

Project.Title			: "CakeBuildTools"
Project.Description		: "Common CakeBuild tools for simplified CI/CD workflows"
Project.Category		: "Build and Deploy"
Project.CategoryOrder	: 901

Nav.LeftNodeTitle:  "Home" 

Project.LinkTitle:  "Home"
Project.LinkOrder:  10

---

# SubPointSolutions.CakeBuildTools
Common cake build tools for SubPoint Solution projects.

### Build status
| Branch  | Status |
| ------------- | ------------- |
| dev   | [![Build status](https://ci.appveyor.com/api/projects/status/54i4q9hrktdhj0je/branch/dev?svg=true)](https://ci.appveyor.com/project/SubPointSupport/cakebuildtools/branch/dev) |
| beta  | [![Build status](https://ci.appveyor.com/api/projects/status/54i4q9hrktdhj0je/branch/beta?svg=true)](https://ci.appveyor.com/project/SubPointSupport/cakebuildtools/branch/beta)  |
| master| [![Build status](https://ci.appveyor.com/api/projects/status/54i4q9hrktdhj0je/branch/master?svg=true)](https://ci.appveyor.com/project/SubPointSupport/cakebuildtools/branch/master) |

### SubPointSolutions.CakeBuildTools in details
CakeBuildTools is a high level abstraction over [Cakebuild](http://cakebuild.net) aiming to provide a highly repeatable and reusable build workflow.
It is used to build [SPMeta2](https://github.com/SubPointSolutions/SPMeta2), [SPMeta2 Reverse](https://github.com/SubPointSolutions/spmeta2-reverse), [SPMeta2 VS Extensions](https://github.com/SubPointSolutions/spmeta2-vsixextensions), [SPMeta2-Spec](https://github.com/SubPointSolutions/spmeta2-spec), [MetaPack](https://github.com/SubPointSolutions/MetaPack), [DefinitelyPacked](https://github.com/SubPointSolutions/DefinitelyPacked) and [some other projects](https://github.com/SubPointSolutions) in a highly standartized way.

Implementation is done via cake build script which is packaged and then reused across all the builds.
The aim is to hide all the complexity of the build and drive the whole build workflow via name conventions and json build configuration.

Current build handles:
* Checking presense of environment variables
* Cleaning folders
* Building *.sln files
* Building set of *.csproj files
* Running unit tests (files and groups)
* NuGet packaging and publishing
* Chocolatey packaging and publishing
* ZIP packaging (with checksums, part of Chocolatey packaging)

The following 'rules' and name conventions are encofced in order to keep the build simple:

#### Rule 1 - same build config for all solutions 
Every solution must have "Build" project housing the following files:
* build.cake
* build.ps1
* build.json
* tools/nuget.config
* tools/nuget.exe
* tools/packages.config
* tools/packages.config.md5sum

nuget.config must have configuration to load up the main NuGet gallery plus both SubPoint Solution Staging and CI galleries:
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget" value="https://www.nuget.org/api/v2/" />
    <add key="SubPointSolutions Staging" value="https://www.myget.org/F/subpointsolutions-staging/api/v2" />
    <add key="SubPointSolutions Appeyor CI - cakebuildtools " value="https://ci.appveyor.com/nuget/subpointsolutions-cakebuildtools" />
  </packageSources>
</configuration>
```
packages.config must have at least two packages. That's how common build infrastructure gets delivered to Cake.

```xml
<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Cake" version="0.17.0" />
  <package id="SubPointSolutions.CakeBuildTools" version="0.1.0-alpha170521456"  />
</packages>
```

#### Rule 2 - keep the build simple
Build script must delegate all work to 'SubPointSolutions.CakeBuild.Core.cake'.
Use 'load' directive to load up the core build script.
```
// load up common tools
#load tools/SubPointSolutions.CakeBuildTools/scripts/SubPointSolutions.CakeBuild.Core.cake

// default targets
RunTarget(target);
```
#### Rule 3 - Default and CI builds must always pass
The following builds must always pass. Use [cmder](cmder.net) in order to execute the following builds:
* powershell .\build.ps1
* powershell .\build.ps1 -Target Default-CI

#### Rule 4 - Leverage built-in tasks 
Common build script provides cake tasks with the following name convention:

* Default-XXX is a target to be used in build.ps1
* Action-XXX is a self-container build task to be chained with "Default-XXX" tasks


| Target  | Actions |
| ------------- | ------------- |
|   | Action-Docs-Publishing  |
|   | Action-Validate-Environment  |
| | Action-Restore-NuGet-Packages |
| | Action-GitHub-ReleaseNotes |
| | Action-Docs-Merge |
| Default  | Action-Clean <br/> Action-Build <br/> Action-Run-UnitTests   |
| Default-Build  | Action-Clean <br/> Action-Build    |
| Default-Clean  | Action-Clean    |
| Default-Run-UnitTests  | Action-Clean<br/>Action-Build<br/> Action-Run-UnitTests    |
| Default-API-NuGet-Packaging  | Action-Clean<br/>Action-Build<br/>Action-Run-UnitTests<br/>Action-NuGet-Packaging    |
| Default-API-NuGet-Publishing  | Action-Clean<br/>Action-Build<br/>Action-Run-UnitTests<br/>Action-API-NuGet-Packaging<br/>Action-API-NuGet-Publishing<br/>   |
| Default-CLI  | Action-Clean<br/>Action-Build<br/>Action-Run-UnitTests<br/>Action-API-NuGet-Packaging<br/>Action-CLI-Zip-Packaging<br/>Action-CLI-Chocolatey-Packaging   |
| Default-CLI-Publishing | Action-Clean<br/>Action-Build<br/>Action-Run-UnitTests<br/>Action-API-NuGet-Packaging<br/>Action-CLI-Zip-Packaging<br/>Action-CLI-Chocolatey-Packaging<br/>Action-CLI-Zip-Publishing<br/>Action-CLI-Chocolatey-Publishing   |
| Default-Desktop  | TBD  |
| Default-CI  | Action-Clean<br/>Action-Build<br/>Action-Run-UnitTests<br/>Action-API-NuGet-Packaging<br/>Action-CLI-Zip-Packaging<br/>Action-CLI-Chocolatey-Publishing<br/>Action-GitHub-ReleaseNotes<br/>Action-Docs-Merge |

#### Rule 5 - simple build is done with build.json config
All build configiration is to be driven from the build.json config.

The simpliest example can bve found below, and more complicated can be found in project repos at github (such as SPMeta2 and other projects).
```json
{
    "defaultSolutionDirectory": "./../",
    "defaultSolutionFilePath": "./../YourSolution.sln",
    "defaultNuGetPackagesDirectory": "./build-artifact-nuget-packages",
    "defaultChocolateyPackagesDirectory": "./build-artifact-cli-packages",
    "defaultNuspecVersion": "0.1.0",
     
    "defaultTestCategories": [
        "CI.Core"
    ],
    "customNuspecs": [

    ],
    "customChocolateySpecs": [
       
    ],
    "defaultTestAssemblyPaths": [
       
    ],
    "defaultBuildDirs": [ ],
    "defaultEnvironmentVariables": [ ]
}
```

#### Rule 6 - build customizations go with replacing default tasks
Core script exposes all default/action cake tasks as global C# variables. 
That allows to inject custom build tasks redefining the whole build workflow. 
Use the following example to get started:

```cs

// load up common tools
#tool nuget:https://www.myget.org/F/subpointsolutions-staging/api/v2?package=SubPointSolutions.CakeBuildTools&prerelease
#load tools\SubPointSolutions.CakeBuildTools\scripts\SubPointSolutions.CakeBuild.Core.cake

// redefining default build task
// cleaning up existing actions, adding our custom one

// in that case we follow all the avialable 'Default' build profiles from the core build script
defaultActionBuild.Task.Actions.Clear();
defaultActionBuild
    .Does(() => 
{
    Information(string.Format("Building VSIX for solution:[{0}]", defaultSolutionFilePath));

	MSBuild(defaultSolutionFilePath, settings => {

        settings.Verbosity = Verbosity.Quiet; 
        
        // Building with MSBuild 12.0 fails #97
        // CRAZY!! to avoid the following error
        // error MSB4018: The "ValidateVsixManifest" task failed unexpectedly
        settings.ToolPath = @"C:\Program Files (x86)\MSBuild\12.0\bin\MSBuild.exe";
    });
});

// filling up default build task with custom build
//defaultActionBuild.Does(actionCustomBuild);

// default targets
RunTarget(target);

```

#### Rule 7 - light appveyor.yml config
appveyor.yml config must be light. Avoid adding heavy logic into it keeping it as following:

```
test: off

clone_folder: c:\prj

build_script: 
    - ps: c:\prj\Build\build.ps1  -Target "Default-CI" -Verbosity Minimal

artifacts:
    - path: '**\packages\*.nupkg'
```

#### Rule 8 - find examples in other projects
Check dev branches of other SubPoint Solution projects to get more understanding on how common build works and can be configured.

### Known issues
* Appveyor build may somehow chacnge MD5 checksum of packages.config. Disable it in build.ps1