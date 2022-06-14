using AdminCMS.Core.Models.Domains;
using AdminCMS.Core.Repositories;
using AdminCMS.Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Persistence.Repositories
{
    public class PageRepository : IPageRepository
    {
        private IApplicationDbContext _context;

        public PageRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Page> Get(string userId, bool isActive = false, int categoryId = 0, string title = null)
        {
            var pages = _context.Pages
                .Include(x => x.Category)
                .Where(x => x.UserId == userId);

            if (isActive)
                pages = pages.Where(x => x.IsActive == isActive);

            if (categoryId != 0)
                pages = pages.Where(x => x.CategoryId == categoryId);

            if (!string.IsNullOrWhiteSpace(title))
                pages = pages.Where(x => x.Name.Contains(title));

            return pages.OrderBy(x => x.CreatedDate).ToList();
        }

        public Page Get(int id, string userId)
        {
            var page = _context.Pages.Single(x => x.Id == id && x.UserId == userId);

            return page;
        }

        public void Add(Page page)
        {
            _context.Pages.Add(page);
        }

        public void Update(Page page)
        {
            var pageToUpdate = _context.Pages.Single(x => x.Id == page.Id);

            pageToUpdate.Name = page.Name;
            pageToUpdate.ShortDescription = page.ShortDescription;
            pageToUpdate.Description = page.Description;
            pageToUpdate.CategoryId = page.CategoryId;
            pageToUpdate.IsActive = page.IsActive;
            pageToUpdate.UpdateDate = DateTime.Now;
        }

        public void Delete(int id, string userId)
        {
            var pageToDelete = _context.Pages.Single(x => x.Id == id && x.UserId == userId);
            _context.Pages.Remove(pageToDelete);
        }

        public void Active(int id, string userId)
        {
            var pageToActive = _context.Pages.Single(x => x.Id == id && x.UserId == userId);
            pageToActive.IsActive = true;
        }

        public void Hide(int id, string userId)
        {
            var pageToHide = _context.Pages.Single(x => x.Id == id && x.UserId == userId);
            pageToHide.IsActive = false;
        }
    }
}
