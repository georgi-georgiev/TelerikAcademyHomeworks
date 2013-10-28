using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesDetails
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var employeeId = int.Parse(Request.QueryString["id"]);
            NorthwindEntities context = new NorthwindEntities();
            var emp =
                (from employee in context.Employees
                where employee.EmployeeID == employeeId
                select employee).ToList();
            this.EmployeeDetailsView.DataSource = emp;
            this.EmployeeDetailsView.DataBind();
        }
    }
}