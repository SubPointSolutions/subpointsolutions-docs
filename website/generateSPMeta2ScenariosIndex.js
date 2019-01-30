const fs = require('fs');
const pretty = require('pretty');

const spmeta2Helpers = require('./siteConfig.spmeta2.js')

var cwd = process.cwd();

var markdown = spmeta2Helpers.generateSPMeta2ScenariosIndex(
    cwd + "/../docs/spmeta2",
    cwd + "/../docs"
);
  
console.log(pretty(markdown))