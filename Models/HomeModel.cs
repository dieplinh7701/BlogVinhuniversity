using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Context;

namespace WebApplication1.Models
{
    public class HomeModel
    {
        public List<BlogNew> ListBlogNew { get;set; }
        public List<Category> ListCategory { get; set; }
        public List<Banner> ListBanner { get; set; }
        public List<User> ListUser { get; set; }
    }
}