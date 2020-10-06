using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedPagination.Core;
using Microsoft.EntityFrameworkCore;

namespace AdvancedPagination
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync();
        public DbSet<Customer> Customers { get; set; }
    }
}
