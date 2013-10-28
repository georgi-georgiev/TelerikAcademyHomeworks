using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoList
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertCategory_Command(object sender, CommandEventArgs e)
        {
            TodosEntities context = new TodosEntities();
            
            var selectedCategoryName = this.NewCategoryName.Text;
            Category newCategory = new Category()
            {
                Name=selectedCategoryName
            };
            context.Categories.Add(newCategory);
            context.SaveChanges();

            this.GridViewCategories.DataBind();
        }

        protected void InsertTodo_Command(object sender, CommandEventArgs e)
        {
            TodosEntities context = new TodosEntities();
            int selectedCategoryId = (int)this.GridViewCategories.SelectedDataKey.Value;
            var selectedCategory = context.Categories.FirstOrDefault(
                c => c.Id == selectedCategoryId);
            TodoList todoList = new TodoList()
            {
                Title = this.NewTodoTitle.Text,
                Body = this.NewTodoBody.Text
            };

            selectedCategory.TodoLists.Add(todoList);
            context.SaveChanges();

            this.GridViewTodoLists.DataBind();
        }
    }
}