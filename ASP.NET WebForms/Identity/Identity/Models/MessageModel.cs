using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}