using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.Models.Domains
{
    public class Page
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Choose category")]
        public int CategoryId { get; set; }

        [MaxLength(250)]
        [Required(ErrorMessage = "Field Name is required")]
        public string Name { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        [Display(Name = "Sort Order")]
        public int SortOrder { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Meta title")]
        public string MetaTitle { get; set; }
        [Display(Name = "Meta keywords")]
        public string MetaKeywords { get; set; }
        [Display(Name = "Meta description")]
        public string MetaDescription { get; set; }
        public string UserId { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }

        public Category Category { get; set; }
        public ApplicationUser User { get; set; }

    }
}
