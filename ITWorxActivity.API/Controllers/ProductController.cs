using ITWorxActivity.API.Response;
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
        public IActionResult GetProducts([FromQuery(Name = "categoryID")] string CategoryID)
        {
            ProductResponse response;
            IEnumerable<Product> allProducts;
            if (CategoryID != null)
            {
                allProducts = _repositroy.GetProductByCategoryID(Convert.ToInt32(CategoryID));

            }
            else
            {
                 allProducts = _repositroy.GetProducts();
                
             }
            if(allProducts != null)
            {
                response = new ProductResponse()
                {
                    Success = true,
                    Message = "No Error Message",
                    Products = allProducts
                };
                return Ok(response);
            }
            else
            {
                response = new ProductResponse()
                {
                    Success = false,
                    Message = "Your url is incorrect or you miss something"
                };
                return Ok(response);

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
