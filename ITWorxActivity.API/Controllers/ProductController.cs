using ITWorxActivity.API.Response;
using ITWorxActivity.Entities;
using ITWorxActivity.Services.Contracts;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("AllowOrigin")]
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
        public IActionResult GetProductByID(string ProductID)
        {
            var product = _repositroy.GeProductByID(Convert.ToInt32(ProductID));
            List<Product> products = new List<Product>();
            products.Add(product);
            BaseResponse productResponse;
            if (product != null)
            {
                productResponse = new ProductResponse
                {
                    Success = true,
                    Message = "Everything is okay",
                    Products = products
                };

                return Ok(productResponse);
            }

            else
            {
                productResponse = new BaseResponse
                {
                    Success = false,
                    Message = $"there is not product with the following id : {ProductID} "
                   
                };


                return NotFound(productResponse);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            BaseResponse productResponse;
            try
            {
                var obj = await _repositroy.AddProduct(product);
                List<Product> products = new List<Product>();
                products.Add(obj);
                 productResponse = new ProductResponse
                {
                    Message = "product has been added",
                    Success = true,
                    Products = products
                };
                return Ok(productResponse);
            }
            catch
            {

                productResponse = new BaseResponse()
                {
                    Message = "The product is not added successfully",
                    Success = false
                };
                return NotFound(productResponse);
            }
        }
        [HttpPut("{ProductID}")]
        public async Task<IActionResult> UpdateProduct([FromBody]Product product, string ProductID)
        {
            BaseResponse productResponse;
            try
            {
                var obj = await _repositroy.UpdateProduct(product, Convert.ToInt32(ProductID));
                List<Product> products = new List<Product>();
                products.Add(obj);
                productResponse = new ProductResponse()
                {
                    Message = $"the prodcut has been updated with ID : {ProductID}",
                    Success = true,
                    Products = products

                };
                return Ok(productResponse);
            }
            catch
            {
                productResponse = new BaseResponse()
                {
                    Message = $"There is not product with the following ID:{ProductID}",
                    Success = false
                };
                return NotFound(productResponse);
            }

        }
        
    }
}
