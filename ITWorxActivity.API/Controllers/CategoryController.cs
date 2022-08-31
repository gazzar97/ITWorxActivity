using ITWorxActivity.API.Response;
using ITWorxActivity.Entities;
using ITWorxActivity.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWorxActivity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _repositroy;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _repositroy = categoryRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Category> AllCategories = _repositroy.GetCategories();
            BaseResponse categoryResponse;
            try
            {
                categoryResponse = new CategoryResponse
                {
                    Success = true,
                    Message = "There is no errors",
                    Categories = AllCategories
                };

            return Ok(categoryResponse);

            }
            catch
            {
                categoryResponse = new BaseResponse()
                {
                    Message = "There is not categories",
                    Success = false
                };
                return NotFound(categoryResponse);
            }
        }

    }
}
