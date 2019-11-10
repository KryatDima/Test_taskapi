using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test_task.Contracts;
using Test_task.Data.Entities;

namespace Test_task.Domain.Mapping
{
    public class CategoryConverter
    {
        public static CategoryDTO Convert(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));

            var dto = new CategoryDTO
            {
                Id = category.Id,
                Title = category.Title,
            };
            
            return dto;
        }

        public static Category Convert(CategoryDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var category = new Category
            {
                Id = dto.Id,
                Title = dto.Title
            };
            return category;
        }

        public static List<CategoryDTO> Convert(List<Category> categories)
        {
            if (categories == null) throw new ArgumentNullException(nameof(categories));

            var dtos = categories.Select(p => Convert(p)).ToList();
            return dtos;
        }
    }
}
