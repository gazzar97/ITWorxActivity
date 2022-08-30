using ITWorxActivity.Entities;
using ITWorxActivity.Services.Contracts;
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
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _repositroy;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _repositroy = categoryRepository;
        }
        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> AllCategories = _repositroy.GetCategories();
            return AllCategories;
        }

    }
}
