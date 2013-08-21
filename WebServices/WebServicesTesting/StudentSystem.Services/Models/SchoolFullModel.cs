using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Services.Models
{
    public class SchoolFullModel : SchoolModel
    {
        public ICollection<StudentModel> Students { get; set; }
    }
}