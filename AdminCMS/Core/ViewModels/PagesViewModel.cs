using AdminCMS.Core.Models;
using AdminCMS.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.ViewModels
{
    public class PagesViewModel
    {
        public IEnumerable<Page> Pages { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public FilterPages FilterPages { get; set; }

    }
}
