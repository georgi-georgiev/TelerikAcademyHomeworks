<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesTreeView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="source">
           <DataBindings>
                <asp:TreeNodeBinding TargetField="#InnerText"  TextField="#Name"/>
                <asp:TreeNodeBinding DataMember="genre" TextField="name" />
                <asp:TreeNodeBinding DataMember="book" TextField="ISBN" />
                <asp:TreeNodeBinding DataMember="userComment" TargetField="#InnerText" TextField="rating" />
                <asp:TreeNodeBinding DataMember="comments" TextField="#Name" />
             </DataBindings>
        </asp:TreeView>
        <asp:XmlDataSource ID="source" runat="server" DataFile="~/review.xml"></asp:XmlDataSource>
    </div>
    </form>
</body>
</html>
