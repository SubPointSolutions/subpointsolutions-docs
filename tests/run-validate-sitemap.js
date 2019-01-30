const colors  = require('colors');
const Batch = require('batch')
const batch = new Batch;

const request = require('request');
const fs = require('fs')
const xml2js = require('xml2js');

const siteUrl = process.env.SITE_URL || "http://localhost:3000"
const siteUrlPrefix = process.env.URL_PREFIX || "/"
const siteUrlDelimiter =  process.env.URL_DELIMITER || "http://docs.subpointsolutions.com"

const sitemapXmlFile = process.env.SITE_MAP || "data/sitemap-docs.subpointsolutions.com.xml"
    
function logInfo(message) {
    console.log(message.green)
}   

function logWarn(message) {
    console.log(message.yellow)
}

function logError(message) {
    console.log(message.red)
}

logInfo(`Validating sitemap file: ${sitemapXmlFile}`)
logInfo(`Validating site URL: ${siteUrl}`)

function processLinks(linksData) {
    var ok    = 0;
    var notOk = 0;

    var links = linksData.urlset.url;
    var linksCount = links.length;
    var index = 0;

    logInfo(`Count: ${linksCount}`)
    
    batch.concurrency(10);

    links.forEach(function(link){
        batch.push(function(done){
            
            index = index + 1;

            var rawUrl = link.loc[0]
            var url = rawUrl.split(siteUrlDelimiter)[1]

            if(!url.startsWith(siteUrlPrefix)) {
                done();
            }

            var targetUrl = siteUrl + url;

            request(targetUrl, function (error, response, body) {
                
                var hasMatch = response.statusCode == 200;
                var status = hasMatch == true ? '[+]' : '[-]'
                
                if(hasMatch == true ) {
                    logInfo(`${index}/${linksCount} ${status} ${url}`)
                    ok = ok + 1;
                } else {
                    logError(`${index}/${linksCount} ${status} ${url}`)
                    notOk = notOk + 1;
                }
                
                done();
            });
            
        });
    });

    batch.on('progress', function(e){
       
    });

    batch.end(function(err, data){
        logInfo(`Completed!`)

        logInfo(`${ok}/${notOk} from ${linksCount}`)

        if(notOk > 0) {
            throw "FAIL"
        }
    });

    logInfo(`batching...`)
}

var parser = new xml2js.Parser();
fs.readFile(sitemapXmlFile, function(err, data) {
    parser.parseString(data, function (err, result) {
        processLinks(result);
    });
});
