
const blc = require('broken-link-checker')
const colors = require('colors');

const siteUrl = process.env.SITE_URL || "http://localhost:3000";
const reportStep = parseInt(process.env.REPORT_STEP) || 1000;

var options = {
    excludedKeywords: [
        'linkedin',
        'https://github.com/SubPointSolutions/subpointsolutions-docs',

        // external links
        'http://www.ncrunch.net/',

        // our nuget/myget links
        'https://www.myget.org/F/subpointsolutions-staging/api/v2',
        'https://www.nuget.org/profiles/SubPointSupport',

        // local test links
        'http://contoso-intranet.local',
        'http://portal/',

        // very old blog posts, leaving for the time being
        'trentacular.com',
        'projectserver2010blog.com',
        'ericgregorich.com',
        'josharepoint.com',
        'sharepoint-tips.com',
        'extreme-sharepoint.com',
        'josharepoint.com',
        '1stquad.com',
        'hersheytech.com',
        'blogs.msdn.com',
        'hekstra.org'

    ]
}

var failResults = [];
var validResults = [];

var linksCount = 0;

var siteChecker = new blc.SiteChecker(options, {
    link: function(result, customData){
        var broken = result.broken;

        var base = result.base.resolved;
        var target =  result.url.resolved

        if(broken == true) {
            failResults.push(result);

            console.log( base.yellow);
            console.log( ("[-] "  +target).yellow );
            // console.log( result.http );
        } else {
            validResults.push(result);

            // console.log(base.green);
            // console.log( ("[+] " + target).green);
        }      

        if(linksCount > 0 && linksCount % reportStep == 0) {
            console.log(`Processed links: ${linksCount}`.gray);
        }

        linksCount++;
    },
    site: function(){        
        console.log(`scanned links: ${linksCount}`);
        console.log(`ok   : ${validResults.length}`.green);
        console.log(`fails: ${failResults.length}`.yellow);

        if(failResults.length > 0) {
            console.log("FAIL".red);
            throw "FAIL"
        } else {
            console.log("OK!".green);
        }
    }
});

console.log(`Scanning site: ${siteUrl}, updating progress after every ${reportStep} links`.green)
siteChecker.enqueue(siteUrl);