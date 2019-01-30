/**
 * Copyright (c) 2017-present, Facebook, Inc.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 */

const React = require('react');

class Footer extends React.Component {
  docUrl(doc, language) {
    const baseUrl = this.props.config.baseUrl;
    const docsUrl = this.props.config.docsUrl;
    const docsPart = `${docsUrl ? `${docsUrl}/` : ''}`;
    const langPart = `${language ? `${language}/` : ''}`;
    return `${baseUrl}${docsPart}${langPart}${doc}`;
  }

  pageUrl(doc, language) {
    const baseUrl = this.props.config.baseUrl;
    return baseUrl + (language ? `${language}/` : '') + doc;
  }

  render() {
    return (
      <footer className="nav-footer" id="footer">
        <section className="sitemap">
          <a href={this.props.config.baseUrl} className="nav-home">
            {this.props.config.footerIcon && (
              <img
                src={this.props.config.baseUrl + this.props.config.footerIcon}
                alt={this.props.config.title}
                width="66"
                height="58"
              />
            )}
          </a>
          <div>
            <h5>Docs</h5>

            <a href='/spmeta2'>
              SPMeta2
            </a>
            <a href='/spmeta2-vs'>
              SPMeta2 Visual Studio Extentions
            </a>

            <a href='/spmeta2-reverse'>
              SPMeta2 Reverse
            </a>
            
          </div>
          <div>
            <h5>Community</h5>
            <a href='https://www.yammer.com/spmeta2feedback' target='_blank' rel="noreferrer" >
              Yammer Network
            </a>
            <a href='https://twitter.com/subpointsocial' target='_blank' rel="noreferrer" >
              Twitter
            </a>
           
            <a href='https://www.linkedin.com/company/subpoint-solutions' target='_blank' rel="noreferrer" >
              LinkedIn
            </a>
          </div>
          <div>
            <h5>More</h5>
            <a href='https://medium.com/@SubPointSocial' target='_blank' rel="noreferrer" >
              Blog @ Medium
            </a>
            <a href='https://github.com/SubPointSolutions' target='_blank' rel="noreferrer" >
              GitHub
            </a>
          
          </div>
        </section>

        {/* <a
          href="https://code.facebook.com/projects/"
          target="_blank"
          rel="noreferrer noopener"
          className="fbOpenSource">
          <img
            src={`${this.props.config.baseUrl}img/oss_logo.png`}
            alt="Facebook Open Source"
            width="170"
            height="45"
          />
        </a> */}
        <section className="copyright" dangerouslySetInnerHTML={{ __html: this.props.config.copyright }}>
          
        </section>
      </footer>
    );
  }
}

module.exports = Footer;
