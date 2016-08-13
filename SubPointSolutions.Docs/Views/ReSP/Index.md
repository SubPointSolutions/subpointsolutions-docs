---
Title: 'reSP Home'
Tile: true
TileTitle: 'reSP'
TileOrder: 100
TileLink: true
TileLinkOrder: 10
TileDescription: 'ReSharper plugin that helps to write SharePoint related code faster and better.'
---

### Welcome to reSP
reSP is a free plugin for [JetBrain ReSharper](https://www.jetbrains.com/resharper/) tool to assist SharePoint developer.

Using ReSharper you have an online static validation of code, markup, XML and Javascript. Once installed the reSP plugin pay your attention to the problems in SharePoint API ([SSOM](/resp/inspections/csharp/), [JSOM](/resp/inspections/javascript/)) usage, potential performance issues, invalid [ASP](/resp/inspections/asp/) and [XML](/resp/inspections/xml/) and provide productivity tools like [IntelliSense](/resp/pro/code-completion/) and [live templates](/resp/pro/livetemplates/). 

Code inspection is performed automatically in design time for all opened files. Also, it can be applied to a whole solution or project. 

Depends on issue severity the problem text is highlighted in different ways and corresponded color marks are added to the marker bar. Mostly each of highlightings has a quick fix action (look like a bulb). And you can apply this fix on the [current file, current folder or project or whole solution.](_img/bulk.gif)

reSP plugin comes as a single bundle with two different editions:

* Basic - includes validation rules.
* Professional - includes productivity features like code completion, live templates etc.

You can enable/disable reSP features in the ReSharper Product & Features dialog.

### Supported platforms
* JetBrains ReSharper 9.0 or high 
* Visual Studio 2010/2012/2013/2015
* SharePoint project types:
   * Farm solution
   * Sandboxed
   * Console application

> In July 2013, JetBrains has launched a free [command line](https://www.jetbrains.com/resharper/features/command-line.html) version of ReSharper. It's compatible with ReSharper's plugins (can load them from the gallery). You can use it for CI purpose.