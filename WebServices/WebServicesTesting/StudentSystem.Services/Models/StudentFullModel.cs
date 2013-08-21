using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Services.Models
{
    public class StudentFullModel : StudentModel
    {
        public ICollection<MarkModel> Marks { get; set; }
    }
}