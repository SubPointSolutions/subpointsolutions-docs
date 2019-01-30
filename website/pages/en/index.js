/**
 * Copyright (c) 2017-present, Facebook, Inc.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 */

const React = require('react');

const CompLibrary = require('../../core/CompLibrary.js');

const MarkdownBlock = CompLibrary.MarkdownBlock; /* Used to read markdown */
const Container = CompLibrary.Container;
const GridBlock = CompLibrary.GridBlock;

class HomeSplash extends React.Component {
  render() {
    const {siteConfig, language = ''} = this.props;
    const {baseUrl, docsUrl} = siteConfig;
    const docsPart = `${docsUrl ? `${docsUrl}/` : ''}`;
    const langPart = `${language ? `${language}/` : ''}`;
    const docUrl = doc => `${baseUrl}${docsPart}${langPart}${doc}`;

    const SplashContainer = props => (
      <div className="homeContainer">
        <div className="homeSplashFade">
          <div className="wrapper homeWrapper">{props.children}</div>
        </div>
      </div>
    );

    const ItemContainer = props => (
      <div className="homeContainer">
        <div className="homeSplashFade">
          <div className="wrapper homeWrapper">{props.children}</div>
        </div>
      </div>
    );

    const Logo = props => (
      <div className="projectLogo">
        <img src={props.img_src} alt="Project Logo" />
      </div>
    );

    const ProjectTitle = () => (
      <h2 className="projectTitle">
        {siteConfig.title}
        <small>{siteConfig.tagline}</small>
      </h2>
    );

    const PromoSection = props => (
      <div className="section promoSection">
        <div className="promoRow">
          <div className="pluginRowBlock">{props.children}</div>
        </div>
      </div>
    );

    const Button = props => (
      <div className="pluginWrapper buttonWrapper">
        <a className="button" href={props.href} target={props.target}>
          {props.children}
        </a>
      </div>
    );

    return (
      <SplashContainer>
        <Logo img_src={`${baseUrl}img/docusaurus.svg`} />
        <div className="inner">
          <ProjectTitle siteConfig={siteConfig} />
          <PromoSection>
            <Button href="#try">Try It Out</Button>
            <Button href={docUrl('doc1.html')}>Example Link</Button>
            <Button href={docUrl('doc2.html')}>Example Link 2</Button>
          </PromoSection>
        </div>
      </SplashContainer>
    );
  }
}

class Index extends React.Component {
  render() {
    const {config: siteConfig, language = ''} = this.props;
    const {baseUrl} = siteConfig;

    const Block = props => (
      <Container
        padding={['bottom', 'top']}
        id={props.id}
        background={props.background}>
        <GridBlock
          align="center"
          contents={props.children}
          layout={props.layout}
        />
      </Container>
    );

    const BlockLeft = props => (

      <Container
        padding={['bottom', 'top']}
        id={props.id}
        background={props.background}
        className={props.className}
      >
         <React.Fragment>
            <div className="opensource-callout">
              <h2>{props.title}</h2>
            </div>
            <br/>
         
       </React.Fragment>

        <GridBlock
          align="left"
          contents={props.children}
          layout={props.layout}
        />
      </Container>
    );

    const FeatureCallout = () => (
      <div
        className="productShowcaseSection paddingBottom"
        style={{textAlign: 'center'}}>
        <h1>Documentation</h1>
        <p>Documentation for <a href='/spmeta2'>SPMeta2</a>, <a href='/metapack'>Metapack</a>, and other projects </p>
      </div>
    );

    const TryOut = () => (
      <Block id="try">
        {[
          {
            content: 'Talk about trying this out',
            image: `${baseUrl}img/docusaurus.svg`,
            imageAlign: 'left',
            title: 'Try it Out',
          },
        ]}
      </Block>
    );

    const Description = () => (
      <Block background="lightBackground">
        {[
          {
            content:
              'This is another description of how this project is useful',
            image: `${baseUrl}img/docusaurus.svg`,
            imageAlign: 'right',
            title: 'Description',
          },
        ]}
      </Block>
    );

    const LearnHow = () => (
      <Block background="light">
        {[
          {
            content: 'Talk about learning how to use this',
            image: `${baseUrl}img/docusaurus.svg`,
            imageAlign: 'right',
            title: 'Learn How',
          },
        ]}
      </Block>
    );

        
    const OpenSourceCallout = props => (
      <div className="wrapper">
        <div className="opensource-callout">
        <h2>{props.title}</h2>
        </div>
      </div>
    );

   
    const ProjectAppPackaging = props  => (
      <BlockLeft layout="oneColumn" title={props.title}  className="one-column ">
        {[
          {
            content: [
              'The open source package manager to create and share SharePoint customizations.',
              "<br/>",
              "<br/>",
              "<a href='/metapack'>GET STARTED</a>",
            ].join(''),
            imageAlign: 'top',
            title: "<h2>Metapack (beta)</h2>",
          }
        ]}
      </BlockLeft>
    );

    const ProjectDev = props  => (
      <BlockLeft layout="fourColumn"  title={props.title}  className="one-column white-smoke">
        {[
          {
            content: [
              "Hassle-free SharePoint artifact provisioning framework for SharePoint Online, SP2019, SP2016, and SP2013.",
              "<br/>",
              "<br/>",
              "<a href='/spmeta2'>GET STARTED</a>"
            ].join(''),
            imageAlign: 'top',
            title: "<h2>SPMeta2</h2>",
          },

          {
            content: [
              "Useful Visual Studio snippets, project and item templates to bootstrap SPMeta2 based projects.",
              "<br/>",
              "<br/>",
              "<a href='/spmeta2-vs'>GET STARTED</a>"
            ].join(''),
            imageAlign: 'top',
            title: "<h2>SPMeta2 VS Extensions</h2>",
          },

          {
            content: [
              "A library to provide reverse engineering of the existing SharePoint sites into SPMeta2 models.",
              "<br/>",
              "<br/>",
              "<a href='/spmeta2-reverse'>GET STARTED</a>"
            ].join(''),
            imageAlign: 'top',
            title: "<h2>SPMeta2 Reverse (beta)</h2>",
          },
          
          {
            content: [
              'ReSharper plugin that helps to write SharePoint related code faster and better.',
              "<br/>",
              "<br/>",
              "<a href='/resp'>GET STARTED</a>"
            ].join(''),
            imageAlign: 'top',
            title: "<h2>reSharePoint</h2>",
          }

        ]}
      </BlockLeft>
    );

    const ProjectInfra = props => (
      <BlockLeft layout="fourColumn" title={props.title}  className="one-column">
        {[
          {
            content: [
              'Ready-to-use Vagrant boxes to create disposable and repeatable SharePoint infrastructure in minutes.',
              "<br/>",
              "<br/>",
              "<a href='/spmeta2'>GET STARTED</a> "
            ].join(''),
            imageAlign: 'top',
            title: "<h2>Uplift</h2>",
          },

      
        ]}
      </BlockLeft>
    );

    const Showcase = () => {
      if ((siteConfig.users || []).length === 0) {
        return null;
      }

      const showcase = siteConfig.users
        .filter(user => user.pinned)
        .map(user => (
          <a href={user.infoLink} key={user.infoLink}>
            <img src={user.image} alt={user.caption} title={user.caption} />
          </a>
        ));

      const pageUrl = page => baseUrl + (language ? `${language}/` : '') + page;

      return (
        <div className="productShowcaseSection paddingBottom">
          <h2>Who is Using This?</h2>
          <p>This project is used by all these people</p>
          <div className="logos">{showcase}</div>
          <div className="more-users">
            <a className="button" href={pageUrl('users.html')}>
              More {siteConfig.title} Users
            </a>
          </div>
        </div>
      );
    };

    return (
      <div>
        {/* <HomeSplash siteConfig={siteConfig} language={language} /> */}
        <div className="mainContainer">

          <FeatureCallout /> 

          {/* <ProjectInfra title='Infrastructure automation' /> */}
          <ProjectDev  title='Artifact provision and development' />
          <ProjectAppPackaging title='Application packaging' />
         
        </div>
      </div>
    );
  }
}

module.exports = Index;
