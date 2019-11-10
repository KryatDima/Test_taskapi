using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test_task.Contracts;

namespace Test_task.Domain.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> Get(long id);
        Task<List<ProductDTO>> GetProducts();
        Task<ProductDTO> Add(CreateProductDTO productDTO);
        Task<ProductDTO> Update(UpdateProductDTO dto);
        Task<bool> Delete(long id);
    }
}
