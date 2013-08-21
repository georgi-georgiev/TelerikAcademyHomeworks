using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Services.Models
{
    public class MarkFullModel:MarkModel
    {
        public ICollection<StudentModel> Students { get; set; }
    }
}