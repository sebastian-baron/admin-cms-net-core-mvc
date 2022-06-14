using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.Models
{
    public class FilterPages
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }

        [Display(Name = "Only active")]
        public bool IsActive { get; set; }
    }
}
