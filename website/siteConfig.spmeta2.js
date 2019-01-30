const fs = require('fs');
const fm = require('front-matter')

var HTMLParser = require('node-html-parser');
var Remarkable = require('remarkable');

var md = new Remarkable();

const newLine = "\r\n"

function getFiles(path) {

    // https://stackoverflow.com/questions/5827612/node-js-fs-readdir-recursive-directory-search

    var walk = function(dir) {
        var results = [];
        var list = fs.readdirSync(dir);
        list.forEach(function(file) {
            file = dir + '/' + file;
            var stat = fs.statSync(file);
            if (stat && stat.isDirectory()) { 
                /* Recurse into a subdirectory */
                results = results.concat(walk(file));
            } else { 
                /* Is a file */
                results.push(file);
            }
        });
        return results;
    }

    return walk(path)
}

function getCategories() {
    return [
        "Farm",
        "Web Application",
        "Site Collection",
        "Root Web",
        "Web",
        "Features",
        "Security", 
        "Content Types",
        "Fields",
        "Lists and Libraries",
        "List Views",
        "Folders",
        "Files",
        "Welcome Page",
        "User Custom Action",
        "Property Bags",
        "Navigation",
        "Workflows", 
        "Wiki Pages",
        "Web Part Pages",
        "Publishing Pages",
        "Web Parts",
        "Master Page Gallery"
    ]
}

function renderSPMeta2ExamplesMarkup(path, docsPath) {
    var examples = getAllExamples(path)

    var result = []
    var categories = getCategories();

    console.log("Building index for categories:")
    
    categories.forEach(function(category) {
        console.log(category);

        var catgoryExamples = getExamplesForCategory(examples, category);
        result.push(renderCategoryBlock(category, catgoryExamples));
    });

    var src = docsPath + "/spmeta2/scenarios/index.template";
    var dst = docsPath + "/spmeta2/scenarios/index.generated.md";

    var markdown =  result.join(newLine)

    copyFile(src, dst);
    replaceValueInFile(dst, "$GENERATED_CONTENT$", markdown);

    return markdown;
}

function getExamplesForCategory(examples, category) {
    return examples.filter(example => {
        return example.scenario_category.toLowerCase() == category.toLowerCase();
    });
}

function renderCategoryBlock(category, examples) {
    var result = []

    result.push(`## ${category} (${examples.length})`); 
 
    examples.forEach( function(example ) {
        // text: text,
        // url: url,
        // anchor: anchor,
        // scenario_model: scenario_model,
        // scenario_category: scenario_category

        example.url = example.url.replace('.html', '')
        example.url = example.url.replace('.htm', '')

        var linkUrl  = example.url + "#"  + example.anchor
        var linkText = example.text

        result.push(`* <a href='${linkUrl}' target="_blank" rel="noreferrer">${linkText}</a>`);    
    });
   
    return result.join(newLine);
}

function renderModelBlock(modelName, categories, modelExamples) {

    var result = []

    result.push(`## ${modelName}`); 
    
    categories.forEach(function(category) {

        result.push(`### ${category}`);
        result.push('')

        var examples = getExamplesForCategory(modelExamples, category);
       
        examples.forEach( function(example ) {
            // text: text,
            // url: url,
            // anchor: anchor,
            // scenario_model: scenario_model,
            // scenario_category: scenario_category
    
            var linkUrl  = example.url + "#"  + example.anchor
            var linkText = example.text

            result.push(`### <a href='${linkUrl}' target="_blank" rel="noreferrer">${linkText}</a>`);    
        });
        
        result.push('')
    });

    return result.join(newLine);
}

function getExamplesForModel(examples, model) {
    return examples.filter(example => {
        return example.scenario_model.toLowerCase() == model.toLowerCase();
    });
}

function getAllExamples(path) {

    var result = [];

    var files = getFiles(path);
    
    files.forEach(function(element) {

        if(element.indexOf('.md') != -1 ) {

            var data = fs.readFileSync(element, 'utf8')
            var content = fm(data);

            var html = md.render(data);
            var root = HTMLParser.parse(html);

            if(content.attributes 
                && content.attributes.scenario_model 
                && content.attributes.scenario_category) 
            {
                var links =  root.querySelectorAll('h3');

                links.forEach(function(link) {
                    var text =  link.rawText;
                    var url  =  "/spmeta2/" + element.split('/spmeta2/')[1].replace(/.md/, '.html').toLowerCase();
                    var anchor =  link.rawText.split(' ').join('-').toLowerCase();

                    var scenario_model = content.attributes.scenario_model;
                    var scenario_category = content.attributes.scenario_category;

                    result.push( {
                        text: text,
                        url: url,
                        anchor: anchor,
                        scenario_model: scenario_model,
                        scenario_category: scenario_category
                    });
                });
            }
        } 

    });

    return result
}

function copyFile(src, dst) {
    var data = fs.readFileSync(src, 'utf8')
    fs.writeFileSync(dst, data, 'utf8');
}

function replaceValueInFile(filePath, oldValue, newValue) {
    var data = fs.readFileSync(filePath, 'utf8')
    data = data.replace(oldValue, newValue)

    fs.writeFileSync(filePath, data, 'utf8');
}

module.exports = {
    generateSPMeta2ScenariosIndex: renderSPMeta2ExamplesMarkup
} 