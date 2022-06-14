using AdminCMS.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.ViewModels
{
    public class PageViewModel
    {
        public string Heading { get; set; }
        public Page Page { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
