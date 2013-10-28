using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Validation_Controls
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitCheckPanel_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                Response.Write("Check info is valid");
            }
        }

        protected void Unnamed_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.Checkbox.Checked;
        }

        protected void ButtonAddressInfo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Write("Address info is valid");
            }
        }

        protected void ButtonLogonInfo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Write("Logon info is valid");
            }
        }

        protected void ButtonPersonalInfo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Write("Personal info is valid");
            }
        }
    }
}