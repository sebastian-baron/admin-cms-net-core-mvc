using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.Models.Domains
{
    public class Category
    {
        public Category()
        {
            Page = new Collection<Page>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Name is requirede")]
        public string Name { get; set; }

        public bool IsActive { get; set; }
        [Display(Name = "Parent category")]
        public int ParentId { get; set; }
        public int SortOrder { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string UserId { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Page> Page { get; set; }
    }
}
