<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ASP.NET_Validation_Controls.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="PanelLogonInfo" runat="server" 
            GroupingText="Logon info">
        Username: <asp:TextBox runat="server" ValidationGroup="ValidationGroupLogonInfo"
             ID="TextBoxUsername" />
        <br />
        <asp:RequiredFieldValidator runat="server"  Display="Dynamic" 
            ControlToValidate="TextBoxUsername"
             ValidationGroup="ValidationGroupLogonInfo" ErrorMessage="Username is required"
             EnableClientScript="False" />
        Password: <asp:TextBox runat="server" ValidationGroup="ValidationGroupLogonInfo"
             ID="TextBoxPassword" />
        <br />
        <asp:RequiredFieldValidator runat="server" Display="Dynamic"
             ControlToValidate="TextBoxPassword"
             ValidationGroup="ValidationGroupLogonInfo" 
            ErrorMessage="Password is required" EnableClientScript="False"></asp:RequiredFieldValidator>
        Repeat Password: <asp:TextBox runat="server" 
            ValidationGroup="ValidationGroupLogonInfo" ID="TextBoxRepeatPassword" />
        <br />
        <asp:RequiredFieldValidator runat="server" Display="Dynamic" 
            ControlToValidate="TextBoxRepeatPassword"
              ValidationGroup="ValidationGroupLogonInfo" 
            ErrorMessage="Repeat Password is required"
            EnableClientScript="False"></asp:RequiredFieldValidator>
        <asp:CompareValidator runat="server" Display="Dynamic" 
            ControlToValidate="TextBoxRepeatPassword"
             ValidationGroup="ValidationGroupLogonInfo" ControlToCompare="TextBoxPassword"
              ErrorMessage="Password are not same" 
             EnableClientScript="false" />
            <br />
        <asp:Button runat="server" ValidationGroup="ValidationGroupLogonInfo"
             ID="ButtonLogonInfo" Text="Submit" OnClick="ButtonLogonInfo_Click" />
        </asp:Panel>
        <asp:Panel runat="server" Id="PersonalInfo" GroupingText="Personal info">
        Firstname: <asp:TextBox runat="server" ID="TextBoxFirstname" />
        <br />
        <asp:RequiredFieldValidator runat="server" Display="Dynamic" 
            ControlToValidate="TextBoxFirstname"
             ValidationGroup="PersonalInfo" ErrorMessage="Firstname is required" 
             EnableClientScript="False"></asp:RequiredFieldValidator>
        Lastname: <asp:TextBox runat="server" ID="TextBoxLastname" />
        <br />
        <asp:RequiredFieldValidator runat="server" Display="Dynamic" 
            ControlToValidate="TextBoxLastname"
             ValidationGroup="PersonalInfo" ErrorMessage="Lastname is required" 
             EnableClientScript="False"></asp:RequiredFieldValidator>
        Age: <asp:TextBox runat="server" ID="TextBoxAge" />

        <br />
        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="TextBoxAge"
             ValidationGroup="PersonalInfo" ErrorMessage="Age is required"  
            EnableClientScript="False"></asp:RequiredFieldValidator>
        <asp:RangeValidator runat="server" Display="Dynamic" ControlToValidate="TextBoxAge"
             MinimumValue="18"
             ValidationGroup="PersonalInfo" MaximumValue="81"  Type="Integer"
             ErrorMessage="Age must be between 18 and 81" EnableClientScript="False"></asp:RangeValidator>
        Phone: <asp:TextBox runat="server" ID="TextBoxPhone" />
        <asp:RequiredFieldValidator runat="server" Display="Dynamic" EnableClientScript="false"
             ControlToValidate="TextBoxPhone"
             ValidationGroup="PersonalInfo" ErrorMessage="Phone is required"  />
        <asp:RegularExpressionValidator runat="server" Display="Dynamic" EnableClientScript="false" ControlToValidate="TextBoxPhone"
              ValidationGroup="PersonalInfo" ValidationExpression="\d\d\d-\d\d\d\d\d\d\d"
              ErrorMessage="Phone is invalid" />
        <br />
            <asp:Button runat="server" ValidationGroup="PersonalInfo" ID="ButtonPersonalInfo" Text="Submit" OnClick="ButtonPersonalInfo_Click" />
        </asp:Panel>
        <asp:Panel runat="server" ID="AddressInfo" GroupingText="Address info">
        Address: <asp:TextBox runat="server" ValidationGroup="AddressInfo" ID="TextBoxAddress" />
        <br />
        <asp:RequiredFieldValidator runat="server" Display="Dynamic" 
             ControlToValidate="TextBoxAddress"
             ValidationGroup="AddressInfo" ErrorMessage="Address is required" 
             EnableClientScript="False"></asp:RequiredFieldValidator>
        Email: <asp:TextBox  runat="server" ValidationGroup="AddressInfo" ID="TextBoxEmail" />
        <asp:RequiredFieldValidator runat="server" Display="Dynamic" EnableClientScript="false"
             ControlToValidate="TextBoxEmail"
             ValidationGroup="AddressInfo"  ErrorMessage="Email is required" />
        <asp:RegularExpressionValidator runat="server" Display="Dynamic"
             EnableClientScript="false" ControlToValidate="TextBoxEmail"
             ValidationGroup="AddressInfo"
             ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]{2,6}$"
             ErrorMessage="Email is not valid" />
        <br />
        <asp:Button runat="server" ValidationGroup="AddressInfo" ID="ButtonAddressInfo"
         Text="Submit" OnClick="ButtonAddressInfo_Click" />
        </asp:Panel>
        <br />
        <asp:Panel runat="server" ID="CheckPanel" GroupingText="Check info">
        <asp:CheckBox runat="server" ValidationGroup="ValidationGroupCheckPanel" ID="Checkbox" Text="Accept" />
        <asp:CustomValidator runat="server" Display="Dynamic"
         ValidationGroup="ValidationGroupCheckPanel"
        ErrorMessage="Please accept the terms"
        EnableClientScript="false"
        onservervalidate="Unnamed_ServerValidate"></asp:CustomValidator>
        <br />
        <asp:Button runat="server" ValidationGroup="ValidationGroupCheckPanel" ID="SubmitCheckPanel" Text="Submit" OnClick="SubmitCheckPanel_Click" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
