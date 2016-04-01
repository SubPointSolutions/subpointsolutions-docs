---
Title: TemplateType attribute
FileName: ListInstanceTemplateType.html
---

### Description
List instance has TemplateType attribute. It should contain list template type which is positive number. Having more than two custom list templates in the project or solution developer can forgive their numbers.
We need to navigate and validate it each time managing list instance.
Although the Visual Studio wizard helps us at the first time, we create list instance but later we must keep this relation in mind.
reSP visualizes this relation. Template name is displayed in the popup hint when you point mouse to number and also allows you to change attribute value from the drop-down list.
To build such list reSP grabs all solution declared list templates and combines its with SharePoint builtins.
Just use Ctrl+Space shortcut in any position of attribute value. All caret preceded chars are used as filter in the dropdown list.
If the caret is located on the fist attribute value position there is no filter and you will see all available choices.
You can type both number and template display name. reSP validate it's correspondingly.
<br/>
<img src="_img/templatetype.gif">


