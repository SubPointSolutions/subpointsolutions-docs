<properties 
	  pageTitle="SecurityGroupDefinition" 
    pageName="SecurityGroupDefinition"
    parentPageId="12771"
/>

###Provision scenario
We should be able to enable/disable SharePoint features.

###Scope
Should be deployed under farm, web application, site or web.

Farm, web application, site and web are supported by SSOM.
Site and web are supported by CSOM.

###Implementation
Security group provision is enabled via SecurityGroupDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if security group exists looking up it by Name property, then creates a new security group. You can deploy either single security group or a set of the security groups using AddSecurityGroup() extension method as per following examples.

[LIST.SAMPLES]