using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test_task.Data.Entities;

namespace Test_task.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetFull(long id);
        Task<List<Product>> GetFullList();
    }
}
