using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test_task.Contracts;

namespace Test_task.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> Get(long id);
        Task<List<CategoryDTO>> GetCategories();
    }
}
