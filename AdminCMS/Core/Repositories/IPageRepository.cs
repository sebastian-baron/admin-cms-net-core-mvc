using AdminCMS.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.Repositories
{
    public interface IPageRepository
    {
        public IEnumerable<Page> Get(string userId, bool isActive = false, int categoryId = 0, string title = null);

        public Page Get(int id, string userId);

        public void Add(Page page);

        public void Update(Page page);

        public void Delete(int id, string userId);

        public void Active(int id, string userId);

        public void Hide(int id, string userId);
    }
}
