using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_task.Contracts;
using Test_task.Domain.Interfaces;

namespace Test_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var dto = await service.Get(id);
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var dto = await service.GetProducts();
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("{add}")]
        public async Task<IActionResult> Add(CreateProductDTO createDto)
        {
            var productDto = await service.Add(createDto);
            if (productDto != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest($"{nameof(productDto)} is null");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDTO dto)
        {
            var productDto = await service.Update(dto);
            if (productDto != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest($"{nameof(productDto)} is null");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (await service.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}