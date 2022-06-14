using AdminCMS.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.ViewModels
{
    public class CategoryViewModel
    {
        public string Heading { get; set; }
        public Category Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
