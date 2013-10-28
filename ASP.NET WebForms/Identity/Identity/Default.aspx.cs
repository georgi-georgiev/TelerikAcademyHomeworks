using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Identity.Account;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Identity
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var manager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));
            //manager.Roles.CreateRoleAsync(new Role("Moderator"));
            //manager.Roles.AddUserToRoleAsync("54fbcab5-d65b-47d4-b517-2eba10002e21", "186c2138-de27-42a6-94f0-8b830c2e8b9c");
            var manager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));
            if (!manager.Logins.HasLocalLogin(User.Identity.GetUserId()))
            {
                grdMessages.EmptyDataTemplate = null;
                if (grdMessages.FooterRow != null)
                {
                    grdMessages.FooterRow.Visible = false;
                }
            }
            else
            {
                var userId = User.Identity.GetUserId();

                var db = new ApplicationDbContext();
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    if (user.Roles.Any(r => r.Role.Name == "Moderator"))
                    {
                        grdMessages.Columns[2].Visible = true;
                    }
                    else if (user.Roles.Any(r => r.Role.Name == "Administrator"))
                    {
                        grdMessages.Columns[2].Visible = true;
                        grdMessages.Columns[3].Visible = true;
                    }
                }
            }
        }

        public IQueryable grdMessagesLoadData()
        {
            var db = new ApplicationDbContext();
            return db.Messages.Include("User").AsQueryable();
        }

        protected void grdMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Control control = null;
            switch (e.CommandName)
            {
                case "AddFromFooter":
                    control = grdMessages.FooterRow;
                    break;
                default:
                    control = grdMessages.Controls[0].Controls[0];
                    break;
            }
            if (control != null)
            {
                var textBox = control.FindControl("txtMessage") as TextBox;
                if (textBox != null)
                {
                    string message = textBox.Text;
                    
                    var db = new ApplicationDbContext();
                    db.Messages.Add(new MessageModel()
                    {
                        Message = message,
                        UserId = User.Identity.GetUserId()
                    });
                    db.SaveChanges();
                    grdMessages.DataBind();
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void grdMessages_DeleteItem(int id)
        {
            var db = new ApplicationDbContext();
            var item = db.Messages.Find(id);
            if (item != null)
            {
                db.Messages.Remove(item);
                db.SaveChanges();
                grdMessages.DataBind();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void grdMessages_UpdateItem(int id)
        {
            var db = new ApplicationDbContext();
            var item = db.Messages.Find(id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                db.SaveChanges();
                grdMessages.DataBind();
            }
        }
    }
}