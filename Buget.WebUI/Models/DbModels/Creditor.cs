//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Buget.WebUI.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Creditor
    {
        public Creditor()
        {
            this.Duties = new HashSet<Dutie>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Dutie> Duties { get; set; }
    }
}
