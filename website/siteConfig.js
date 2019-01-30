/**
 * Copyright (c) 2017-present, Facebook, Inc.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 */

// See https://docusaurus.io/docs/site-config for all the possible
// site configuration options.

const sharedConfig   = require('./siteConfig.shared.js');
const spmeta2Helpers = require('./siteConfig.spmeta2.js')

var cwd = process.cwd();

spmeta2Helpers.generateSPMeta2ScenariosIndex(
  cwd + "/../docs/spmeta2",
  cwd + "/../docs"
);

// List of projects/orgs using your project for the users page.
const users = [
  {
    caption: 'User1',
    // You will need to prepend the image path with your baseUrl
    // if it is not '/', like: '/test-site/img/docusaurus.svg'.
    image: '/img/docusaurus.svg',
    infoLink: 'https://www.facebook.com',
    pinned: true,
  },
];

const siteConfig = {
  title: 'SubPoint Solutions Docs', // Title for your website.
  tagline: 'A website for testing',
  url: 'http://docs.subpointsolutions.com', // Your website URL
  baseUrl: '/', // Base URL for your project */
  // For github.io type URLs, you would set the url and baseUrl like:
  //   url: 'https://facebook.github.io',
  //   baseUrl: '/test-site/',

  // Used for publishing and more
  projectName: '',
  organizationName: 'facebook',
  // For top-level user or org sites, the organization is still the same.
  // e.g., for the https://JoelMarcey.github.io site, it would be set like...
  //   organizationName: 'JoelMarcey'

  // For no header links in the top nav bar -> headerLinks: [],
  headerLinks: [
  
    {
      href: 'http://subpointsolutions.com',
      label: 'Home',
    },

    {
      href: 'https://github.com/SubPointSolutions',
      label: 'GitHub',
    },
  ],

  docsUrl: '',
  docsSideNavCollapsible: false,

  // If you have users set above, you add it here:
  users,

  /* path to images for header/footer */
  headerIcon: 'img/favicon.ico',
  footerIcon: 'img/favicon.ico',
  favicon: 'img/favicon.ico',

  /* Colors for website */
  colors: {
    primaryColor: '#1e1e1e',
    secondaryColor: '#1976d2',
  },

  /* Custom fonts for website */
  /*
  fonts: {
    myFont: [
      "Times New Roman",
      "Serif"
    ],
    myOtherFont: [
      "-apple-system",
      "system-ui"
    ]
  },
  */

  // This copyright info is used in /core/Footer.js and blog RSS/Atom feeds.
  copyright: `Copyright © ${new Date().getFullYear()} SubPoint Solutions`,

  highlight: {
    // Highlight.js theme to use for syntax highlighting in code blocks.
    // https://highlightjs.org/static/demo/
    
    theme: 'atom-one-dark',
    //theme: 'hybrid',
    //theme: 'dracula',
    //theme: 'monokai-sublime'
  },

  // Add custom scripts here that would be placed in <script> tags.
  scripts: ['https://buttons.github.io/buttons.js'],

  // On page navigation for the current documentation page.
  onPageNav: 'separate',
  // No .html extensions for paths.
  cleanUrl: true,

  // Open Graph and Twitter card images.
  ogImage: '', // # 'img/docusaurus.png',
  twitterImage: '', // 'img/docusaurus.png',

  // Show documentation's last contributor's name.
  // enableUpdateBy: true,

  // Show documentation's last update time.
  // enableUpdateTime: true,

  // You may provide arbitrary config keys to be used as needed by your
  // template. For example, if you need your repo's URL...
  //   repoUrl: 'https://github.com/facebook/test-site',
  markdownPlugins: [
    function mermaid(md) {
      md.renderer.rules.fence_custom.mermaid = function(
        tokens,
        idx,
        options,
        env,
        instance,
      ) {
        var currentToken = tokens[idx]
        return `<div class='mermaid' style='text-align:center'>${currentToken.content}</div>`;
      };
    },
  ]
};

sharedConfig(siteConfig, 'docs')

module.exports = siteConfig;
