using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_MVC_AJAX.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }

        public string LeadingMRole { get; set; }
        public string LeadingFRole { get; set; }

        public int LeadingMRoleAge { get; set; }
        public int LeadingFRoleAge { get; set; }
        public string Studio { get; set; }
        public string StudioAddress { get; set; }
    }

}