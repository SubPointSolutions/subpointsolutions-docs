---
id: "farmsolutiondefinition"
title: "FarmSolutionDefinition"
scenario_model: "Farm model"
scenario_category: "Farm"
---

## API support
[+] SSOM [-] CSOM

## Can be deployed under
Farm

## Notes
Farm solution provision is enabled via FarmSolutionDefinition object.

Provision checks if solution exists, deploying a new one using FileName as a key.

## Examples

### Add farm solution

```cs
var solutionDef = new FarmSolutionDefinition
{
    FileName = "your-solution-file.wsp",
    SolutionId = new Guid("your-solution-id"),
    Content = File.ReadAllBytes("path-to-your-solution-or-byte-array")
};
 
var model = SPMeta2Model.NewFarmModel(farm =>
{
    farm.AddFarmSolution(solutionDef);
});
 
DeployModel(model);
```