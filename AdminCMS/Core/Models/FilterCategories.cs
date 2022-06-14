using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.Models
{
    public class FilterCategories
    {
        [Display(Name = "Name of category")]
        public string Title { get; set; }
    }
}
