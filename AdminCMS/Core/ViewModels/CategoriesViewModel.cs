using AdminCMS.Core.Models;
using AdminCMS.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.ViewModels
{
    public class CategoriesViewModel
    {
        public string Heading { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public FilterCategories FilterCategories { get; set; }
    }
}
