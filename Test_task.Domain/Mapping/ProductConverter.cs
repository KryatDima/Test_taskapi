using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test_task.Contracts;
using Test_task.Data.Entities;

namespace Test_task.Domain.Mapping
{
    public class ProductConverter
    {
        public static ProductDTO Convert(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new ProductDTO
            {
                Id = product.Id,
                Title = product.Title,
                CategoryId = product.CategoryId,
                Category= CategoryConverter.Convert(product.Category)
            };
        }

        public static Product Convert(CreateProductDTO product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new Product
            {
                Title = product.Title,
                CategoryId = product.CategoryId,
                //Category= CategoryConverter.Convert(product.CategoryDTO)
            };
        }

        public static Product Convert(ProductDTO product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new Product
            {
                Id = product.Id,
                Title = product.Title,
                CategoryId = product.CategoryId,
                Category= CategoryConverter.Convert(product.Category)
            };
        }

        public static Product Convert(UpdateProductDTO product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            return new Product
            {
                Id = product.Id,
                Title = product.Title,
                CategoryId = product.CategoryId
            };
        }

        public static List<ProductDTO> Convert(List<Product> products)
        {
            if (products == null) throw new ArgumentNullException(nameof(products));

            var dtos = products.Select(p => Convert(p)).ToList();
            return dtos;
        }
    }
}
