using AdminCMS.Core.Models.Domains;
using AdminCMS.Core.Repositories;
using AdminCMS.Core.Service;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Persistence.Repositories
{
    [Authorize]
    public class CategoryRepository : ICategoryRepository
    {
        private IApplicationDbContext _context;

        public CategoryRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(x => x.Name).ToList();
        }

        public IEnumerable<Category> Get(string userId, string title)
        {
            var categories = _context.Categories.Where(x => x.UserId == userId);

            if (!string.IsNullOrWhiteSpace(title))
                categories = categories.Where(x => x.Name.Contains(title));

            return categories.OrderBy(x => x.CreatedDate).ToList();
        }

        public Category Get(int id, string userId)
        {
            var category = _context.Categories.Single(x => x.Id == id && x.UserId == userId);

            return category;
        }

        public void Delete(int id, string userId)
        {
            var categoryToDelete = _context.Categories.Single(x => x.Id == id && x.UserId == userId);

            _context.Categories.Remove(categoryToDelete);
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            var categoryToUpdate = _context.Categories.Single(x => x.Id == category.Id);

            categoryToUpdate.Name = category.Name;
            categoryToUpdate.IsActive = category.IsActive;
            categoryToUpdate.UpdateDate = DateTime.Now;
        }
    }
}
