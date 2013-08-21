using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Services.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public string School { get; set; }
    }
}