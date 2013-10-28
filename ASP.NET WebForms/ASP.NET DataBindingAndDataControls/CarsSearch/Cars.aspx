<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="CarsSearch.Cars" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ProducerDropDownList" runat="server" AutoPostBack="true"
            DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ProducerIndexChange">

        </asp:DropDownList>
        <br />
        <asp:DropDownList ID="ModelsDropDownList" runat="server" AutoPostBack="true"
             DataTextField="Type" DataValueField="Id">
        </asp:DropDownList>
        <br />
        <asp:RadioButtonList ID="ExtrasRadioButtonList" runat="server"
            DataTextField="Type" DataValueField="ID">
        </asp:RadioButtonList>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />

        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
