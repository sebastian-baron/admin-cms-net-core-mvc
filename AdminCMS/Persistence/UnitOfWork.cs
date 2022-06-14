using AdminCMS.Core.Repositories;
using AdminCMS.Core.Service;
using AdminCMS.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Page = new PageRepository(context);
            Category = new CategoryRepository(context);
        }

        public IPageRepository Page { get; set; }
        public ICategoryRepository Category { get; set; }


        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
