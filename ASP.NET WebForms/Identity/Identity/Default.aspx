<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Identity._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:GridView ID="grdMessages" runat="server" SelectMethod="grdMessagesLoadData" UpdateMethod="grdMessages_UpdateItem" DeleteMethod="grdMessages_DeleteItem"
        AutoGenerateColumns="False"
        ShowFooter="True" DataKeyNames="Id" ItemType="Identity.Models.MessageModel" OnRowCommand="grdMessages_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <%#: Item.User.FirstName %> <%#: Item.User.LastName %> 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Messages">
                <EditItemTemplate>
                    <asp:TextBox ID="txtMessage" runat="server" Text="<%#: BindItem.Message %>"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="btnAddNewMessage" runat="server" CommandName="AddFromFooter">Add New Message</asp:LinkButton>
                </FooterTemplate>
                <ItemTemplate>
                    <%#: Item.Message %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" Visible="False" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" Visible="False" />
        </Columns>
        <EmptyDataTemplate>
            <table class="grdMessagesEmptyTemplate">
                <tr>
                    <th>Messages</th>
                    <th>Add New</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:LinkButton ID="btnAddNewMessage" runat="server" CommandName="EmptyDataTemplate">Add New Message</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
    

</asp:Content>
