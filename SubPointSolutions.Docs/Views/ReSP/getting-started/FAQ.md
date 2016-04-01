---
Title: FAQ
FileName: faq.html
---

### How is it possible to check all solution projects?

In case of "bulk" analyse R# exposes the list of incidents in the separate windows. 

<img src="_img/bulk_inspection.gif">


### How to change rule severity in the ReSharper?
* 1 approach:

Open ReSharper | Option dialog and select Code Inspection | Inspection Severity
Click on the reSP title
Click on the colored box with curent severity level.

* 2 approach:
<img src="_img/disable_rule.gif" >


### How can I read more about highlighting?
Open context menu, select Options for "name of issue" and select "Why is reSP suggestion this?". The help page will be opened immediatelly in the browser.
<img class="alignright size-full wp-image-6671" src="_img/get_help.png">


You can read more about ReSharper code inspection [here](https://www.jetbrains.com/resharper/help/Code_Analysis__Index.html).


### How can I do something more with ReSharper?
  Read [this](http://sadomovalex.blogspot.ru/search/label/ReSharper) article to know about live templates.

### Where I can find the quick access key map in for ReSharper?
  Check out this [guide](http://www.jetbrains.com/resharper/docs/ReSharper80DefaultKeymap_IDEA_scheme.pdf) PDF.

### How can I enable/disable ReSharper code analysis for specific files?

  - Ctrl-8 for the current file, for the current session.
  - Ctrl-Alt-8 for disabling Resharper code analysis.

### List of excluded libraries
You can configure lists of ignored files using regular expression or wildcards in the ReSharper | Options dialog.

<img class="alignright size-full wp-image-11291" src="_img/settings.png" alt="settings" width="775" height="480">