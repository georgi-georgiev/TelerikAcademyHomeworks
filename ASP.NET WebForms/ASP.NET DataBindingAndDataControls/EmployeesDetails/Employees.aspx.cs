using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NorthwindData;

namespace EmployeesDetails
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NorthwindEntities context = new NorthwindEntities();
                var employees =
                    (from employee in context.Employees
                    select new { employee.EmployeeID, employee.FirstName, employee.LastName }).ToList();

                this.EmployeesGrid.DataSource = employees;
                this.EmployeesGrid.DataBind();
            }
        }
    }
}