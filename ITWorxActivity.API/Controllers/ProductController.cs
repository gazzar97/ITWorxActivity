using ITWorxActivity.Entities;
using ITWorxActivity.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWorxActivity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repositroy;
        public ProductController(IProductRepository repository)
        {
            _repositroy = repository;
        }
        [HttpGet]
        public IEnumerable<Product> GetProducts([FromQuery(Name = "categoryID")] string CategoryID)
        {
            if (CategoryID != null)
            {
                return _repositroy.GetProductByCategoryID(Convert.ToInt32(CategoryID));
            }
            else
            {
                return _repositroy.GetProducts();
            }
        }
        [HttpGet("{ProductID}")]
        public Product GetProductByID(string ProductID)
        {
            return _repositroy.GeProductByID(Convert.ToInt32(ProductID));
        }
        [HttpPost]
        public async Task<Object> AddProduct([FromBody]Product product)
        {
            try
            {
                await _repositroy.AddProduct(product);
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPut("{ProductID}")]
        public bool UpdateProduct([FromBody]Product product, string ProductID)
        {
            try
            {
                _repositroy.UpdateProduct(product, Convert.ToInt32(ProductID));
                return true;
            }
            catch
            {
                return false;
            }

        }
        
    }
}
