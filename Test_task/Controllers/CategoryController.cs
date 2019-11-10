using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_task.Domain.Interfaces;

namespace Test_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
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
            var dto = await service.GetCategories();
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return NoContent();
            }
        }
    }
}