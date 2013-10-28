﻿using NorthwindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesRepeater
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NorthwindEntities context = new NorthwindEntities();
            var employees =
                (from employee in context.Employees
                select employee).ToList();
            this.EmployeesRepeater.DataSource = employees;
            this.EmployeesRepeater.DataBind();
        }
    }
}