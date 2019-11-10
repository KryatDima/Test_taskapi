using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test_task.Data.Entities;
using Test_task.Data.Interfaces;

namespace Test_task.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product> GetFull(long id)
        {
            return await DbContext.Set<Product>().Where(x => x.Id == id)
                .Include(c => c.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetFullList()
        {
            return await DbContext.Set<Product>()
                .Include(c => c.Category)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
