using AdminCMS.Core.Repositories;
using AdminCMS.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.Service
{
    public interface IUnitOfWork
    {
        IPageRepository Page { get; }
        ICategoryRepository Category { get; }
        void Complete();
    }
}
