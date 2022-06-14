using AdminCMS.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Core.Service
{
    public interface IApplicationDbContext
    {
        DbSet<Page> Pages { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Article> Articles { get; set; }
        DbSet<Logs> Logs { get; set; }

        int SaveChanges();
    }
}
