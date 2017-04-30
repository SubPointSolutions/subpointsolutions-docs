---
Title: FeatureId attribute
FileName: ListInstanceFeatureId.html
---

### Description
List instance has FeatureId attribute. It should contain Id (Guid) of feature where related list template is defined.
Feature name is displayed in the popup hint when you point mouse to Id and also allows you to change attribute value from the drop-down list.
To build such list reSP grabs all solution features and combines its with SharePoint builtins.
Just use Ctrl+Space shortcut in any position of attribute value. All caret preceded chars are used as filter in the dropdown list.
If the cursor is located in the fist position of attribute value then there is no filter and you will see all available choices.
You can type both Guid and feature name. reSP validate it's correspondingly.
<br/>
<img src="_img/featureid.gif">


