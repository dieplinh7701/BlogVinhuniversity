//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class BlogNew
    {
        public int BlogId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public System.DateTime ModifiedBy { get; set; }
        public bool IsNew { get; set; }
        public bool Highlights { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
