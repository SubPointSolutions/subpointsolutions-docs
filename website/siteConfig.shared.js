function sharedSiteConfig(siteConfig, siteName) {

    const docsRepoUrl = 'https://github.com/SubPointSolutions/subpointsolutions-docs';
    const execSync = require('child_process').execSync;
    
    // branch name is always HEAD under CI build, so fetching directly
    // https://stackoverflow.com/questions/6245570/how-to-get-the-current-branch-name-in-git/25397424
    const gitBranch = process.env.APPVEYOR_REPO_BRANCH || execSync("git rev-parse --abbrev-ref HEAD");
    const gitCommit = execSync("git log --pretty=format:%h -n 1");

    console.log("applying shared config:")

    siteConfig.colors = {
        primaryColor: '#1e1e1e',
        secondaryColor: '#039be5',
    };

    siteConfig.scripts = siteConfig.scripts || []
    siteConfig.scripts = siteConfig.scripts.concat([
        'https://cdnjs.cloudflare.com/ajax/libs/clipboard.js/2.0.0/clipboard.min.js',
        '/js/code-block-buttons.js',
        'https://cdnjs.cloudflare.com/ajax/libs/mermaid/7.1.2/mermaid.min.js',
        '/js/mermaid-init.js'
    ])

    // siteConfig.stylesheets = siteConfig.stylesheets || []
    // siteConfig.stylesheets = siteConfig.stylesheets.concat([
    //     '/css/code-block-buttons.css',
    //     '/css/shared.css',
    //     '/css/custom.css'
    // ])

    siteConfig.headerIcon = ''; //img/subpoint-logo-25.png'
    siteConfig.footerIcon = 'img/subpoint-logo-25.png'

    siteConfig.copyright = [
        `<div class='copyright-text'>`,
            `Copyright © ${new Date().getFullYear()} <a href='http://subpointsolutions.com' target="_blank" rel="noreferrer">SubPoint Solutions</a>. `,
            `Built with care, <a href='https://docusaurus.io' target="_blank" rel="noreferrer">Docusaurus</a> and <a href='https://www.netlify.com' target="_blank" rel="noreferrer">Netlify</a>.`,
        `</div>`,
        `<div class='update-meta'>`,
            `On branch <a href="${docsRepoUrl}/tree/${gitBranch}"  target="_blank" rel="noreferrer">${gitBranch}</a>, `,
            `commit <a href="${docsRepoUrl}/commit/${gitCommit}" target="_blank" rel="noreferrer">${gitCommit}</a>, `,
            `updated on ${new Date().toUTCString()}`,
        `</div>`
    ].join('');

    if (siteName) {
        siteConfig.editUrl = `${docsRepoUrl}/tree/dev/${siteName}/`;
        siteConfig.projectName = siteName
        siteConfig.organizationName = "SubPoint Solutions"

        siteConfig.enableUpdateBy   = true;
        siteConfig.enableUpdateTime = true;
    }

    console.log("final config:")
    console.log(siteConfig)
}

module.exports = sharedSiteConfig;