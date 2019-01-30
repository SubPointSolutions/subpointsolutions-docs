const SitemapGenerator = require('sitemap-generator');
 
const url = process.env.URL || "http://docs.subpointsolutions.com"

const generator = SitemapGenerator(url, {
  stripQuerystring: false
});
 
generator.start();