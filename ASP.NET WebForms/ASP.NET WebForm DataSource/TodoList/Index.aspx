﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TodoList.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:EntityDataSource ID="EntityDataCategories" EnableDelete="true" EnableInsert="true" EnableUpdate="true" runat="server" ConnectionString="name=TodosEntities" DefaultContainerName="TodosEntities" EnableFlattening="False" EntitySetName="Categories">
        </asp:EntityDataSource>
        <br />
        <asp:GridView ID="GridViewCategories" AutoGenerateDeleteButton="true"  AutoGenerateEditButton="true" AutoGenerateSelectButton="true" runat="server" PageSize="2" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="EntityDataCategories">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            </Columns>
        </asp:GridView>
        <asp:TextBox runat="server" ID="NewCategoryName"></asp:TextBox>
        <asp:Button runat="server" ID="InsertCategory" Text="Insert" OnCommand="InsertCategory_Command" />
        <asp:EntityDataSource EnableDelete="true"
             EnableInsert="true" EnableUpdate="true" ID="EntityDataSourceTodoLists" Where="it.categoryId=@catId" runat="server" ConnectionString="name=TodosEntities" DefaultContainerName="TodosEntities" EnableFlattening="False" EntitySetName="TodoLists">
            <WhereParameters>
                <asp:ControlParameter Name="catId" Type="Int32" ControlID="GridViewCategories" />
            </WhereParameters>
        </asp:EntityDataSource>
        <table>
        <asp:GridView ID="GridViewTodoLists" runat="server" ItemType="TodoList.TodoList"
             AllowPaging="True" PageSize="2" AllowSorting="True" AutoGenerateDeleteButton="true"
              AutoGenerateEditButton="true" AutoGenerateSelectButton="true"
             AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="EntityDataSourceTodoLists">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Body" HeaderText="Body" />
            </Columns>
        </asp:GridView>
            <asp:TextBox ID="NewTodoTitle" runat="server"></asp:TextBox>
            <asp:TextBox ID="NewTodoBody" runat="server"></asp:TextBox>
            <asp:Button ID="InsertTodo" runat="server" Text="Insert" OnCommand="InsertTodo_Command" />
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
