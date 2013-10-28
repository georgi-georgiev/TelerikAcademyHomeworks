<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesRepeater.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Repeater ID="EmployeesRepeater" runat="server">
            <HeaderTemplate>
                <table>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#: Eval("FirstName") + " " + Eval("LastName") %></td>
                </tr>
                <tr>
                    <td><%#: Eval("Title") %></td>
                </tr>
                <tr>
                    <td><%#: Eval("City") %></td>
                </tr>
                <tr>
                    <td><%#: Eval("Address") %></td>
                </tr>
                <tr>
                    <td><%#: Eval("Notes") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    
    </div>
    </form>
</body>
</html>
