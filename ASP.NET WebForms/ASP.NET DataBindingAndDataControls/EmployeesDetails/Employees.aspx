<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EmployeesDetails.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="EmployeesGrid" runat="server" AutoGenerateColumns="False" 
            AllowPaging="True" DataKeyNames="EmployeeID">
            <Columns>
                <asp:HyperLinkField runat="server"  DataTextField="FirstName" DataNavigateUrlFields="EmployeeID"
                    DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" />
                <asp:HyperLinkField runat="server" DataTextField="LastName" DataNavigateUrlFields="EmployeeID"
                    DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
