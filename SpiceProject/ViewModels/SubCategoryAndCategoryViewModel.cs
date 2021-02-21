using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spice.DomainModel;

namespace SpiceProject.ViewModels
{
    public class SubCategoryAndCategoryViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<string> SubCategoryList { get; set; }
        public string StatusMessage { get; set; }
    }
}