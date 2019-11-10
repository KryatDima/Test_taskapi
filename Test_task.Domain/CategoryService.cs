using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task.Contracts;
using Test_task.Data.Entities;
using Test_task.Data.Interfaces;
using Test_task.Domain.Interfaces;
using Test_task.Domain.Mapping;

namespace Test_task.Domain
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CategoryDTO> Get(long id)
        {
            var category = await unitOfWork.Repository<Category>().Get(id);
            if (category == null) return null;
            return CategoryConverter.Convert(category);
        }

        public async Task<List<CategoryDTO>> GetCategories()
        {
            var categories = unitOfWork.Repository<Category>().GetQueryable().ToList();
            if (categories == null) return null;
            return await Task.FromResult(CategoryConverter.Convert(categories));
        }
    }
}
