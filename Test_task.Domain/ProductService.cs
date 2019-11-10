using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test_task.Contracts;
using Test_task.Data.Entities;
using Test_task.Data.Interfaces;
using Test_task.Domain.Interfaces;
using Test_task.Domain.Mapping;

namespace Test_task.Domain
{
    public class ProductService : IProductService
    {
        private IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        private async Task<Product> GetProductEntity(long id)
        {
            var product = await unitOfWork.ProductRepository.GetFull(id);
            return product;
        }

        public async Task<ProductDTO> Add(CreateProductDTO productDTO)
        {
            if (productDTO == null) return null;

            var p = ProductConverter.Convert(productDTO);
            
            var product = await unitOfWork.Repository<Product>().Add(p);
            product.Category = await unitOfWork.Repository<Category>().Get(product.CategoryId);
            return ProductConverter.Convert(product);
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await unitOfWork.ProductRepository.GetFull(id);
            if (entity == null) return false;
            var b =  unitOfWork.Repository<Product>().Delete(entity);
            return b;
        }

        public async Task<ProductDTO> Get(long id)
        {
            var product = await unitOfWork.ProductRepository.GetFull(id);

            //if (product.Category == null) product.Category = await unitOfWork.Repository<Category>().Get(product.CategoryId);

            if (product == null) return null;
            return ProductConverter.Convert(product);
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            var dtos = await unitOfWork.ProductRepository.GetFullList();

            //foreach(var d in dtos)
            //{
            //    if (d.Category == null) d.Category = await unitOfWork.Repository<Category>().Get(d.CategoryId);

            //}

            return ProductConverter.Convert(dtos);
        }

        public async Task<ProductDTO> Update(UpdateProductDTO updateDto)
        {
            if (updateDto == null) return null;
            var dto = ProductConverter.Convert(updateDto);
            dto.Category = await unitOfWork.Repository<Category>().Get(dto.CategoryId);
            //var product = ProductConverter.Convert(dto);
            var product = ProductConverter.Convert(await unitOfWork.Repository<Product>().Update(dto));
            //product = ProductConverter.Convert(await unitOfWork.ProductRepository.GetFull(dto.Id));
            return product;
        }
    }
}
