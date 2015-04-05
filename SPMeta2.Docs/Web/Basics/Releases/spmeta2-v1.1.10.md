<properties
	pageTitle="SPMeta2 1.1.10, Nov 2014"
    pageName="spmeta2-v1110"
    parentPageId="3761"
/>

### Summary
A new "SPMeta2.Core.Standard" NuGet package is introduce to address artifact definitions for Standard editions of SharePoint. Other "Standard" packages were updated accordingly. Please use "SPMeta2.CSOM.Standard" or "SPMeta2.SSOM.Standard" NuGet packages once you deal with SharePoint standart+ features, for instance, publishing or taxonomy.

### New definitions

* TextFieldDefinition
* NoteFieldDefinition
* CurrencyFieldDefinition
* ChoiceFieldDefinition
* MultiChoiceFieldDefinition
* DateTimeFieldDefinition
* UserFieldDefinition
* LookupFieldDefinition

These definitions help with model typing enabling better provision of a particular field properties. For instance, additional properties for UserFieldDefinition or ability to setup choices for ChoiceFieldDefinition / MultiChoiceFieldDefinition is one of the handiest feature among others.
It is also one of the preliminary steps toward a bigger portal provision framework and *.wsp -> code based provision migration we are planning to get done soon.

### Improvements & enhancements

* Improved SPMeta2.Enumerations namespace
* BuiltInBasePermissions enumeration
* BuiltInDateTimeFieldFormatType enumeration
* BuiltInDateTimeFieldFriendlyFormatType enumeration
* ListViewDefinition.Url prop
* SecurityGroupDefinition.OnlyAllowMembersViewMembership prop

### Regression test coverage
* 40+ regression tests