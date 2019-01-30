---
title: SPDataSource.Scope is missed in page
id: resp516902
---

## Description
How’d we know what people want – folder, inside folder, or just items?
SPDataSource has an “affected scope”. It can be one of the follow: 

* Default, Show only the files and subfolders of a specific folder
* Recursive, Show all files of all folders
* RecursiveAll, Show all files and all subfolders of all folders

All enumeration values are covered all possible developer’s intentions. Other words, without specified, SharePoint will use Default value. It is not always correspond develepers needs now or later espetially in case of new folder added. Notify about missing Scope we give developer change to specify it’s architecture approach.

```xml
<SharePoint:SPDataSource runat="server" ID="dsPeople" DataSourceMode="ListItem" UseInternalName="true">
    <SelectParameters>
        <asp:Parameter Name="WebUrl" DefaultValue="/configuration/" />
        <asp:Parameter Name="ListID" DefaultValue="34F91B0C-FCF2-455A-ABBA-67724FB4024A" />
        <asp:Parameter Name="ListItemID" DefaultValue="1" />
    </SelectParameters>
</SharePoint:SPDataSource>

<asp:GridView ID="grdPeople" runat="server" DataSourceID="dsPeople"  AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="FullName" HeaderText="Blogger name" />
        <asp:BoundField DataField="WorkCity" HeaderText="City" />
        <asp:BoundField DataField="Blog_x0020_URL" HeaderText="Blog URL" />
    </Columns>
</asp:GridView>
```

##  Resolution
Specify Scope property.

##  Links
- [SPViewScope enumeration](https://msdn.microsoft.com/en-us/library/microsoft.sharepoint.spviewscope.aspx)
- [SPDataSource.Scope property](https://msdn.microsoft.com/EN-US/library/microsoft.sharepoint.webcontrols.spdatasource.scope.aspx)
