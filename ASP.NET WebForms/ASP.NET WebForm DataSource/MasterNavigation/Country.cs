//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterNavigation
{
    using System;
    using System.Collections.Generic;
    
    public partial class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContinentId { get; set; }
        public string Language { get; set; }
        public Nullable<int> Population { get; set; }
    
        public virtual Continent Continent { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
    }
}
