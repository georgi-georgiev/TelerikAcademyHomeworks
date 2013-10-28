<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="EmployeesDetails.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="Employees.aspx">Back</a>
        <br />
        <asp:DetailsView ID="EmployeeDetailsView" runat="server" Height="50px" Width="125px"
            AutoGenerateRows="true" AllowPaging="True">
        </asp:DetailsView>
    </div>
    </form>
</body>
</html>
