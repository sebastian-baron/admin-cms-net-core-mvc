using AdminCMS.Core.Models.Domains;
using AdminCMS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.Service
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetCategories();

        public IEnumerable<Category> Get(string userId, string title);

        public Category Get(int id, string userId);

        public void Delete(int id, string userId);

        public void Add(Category category);

        public void Update(Category category);
    }
}
