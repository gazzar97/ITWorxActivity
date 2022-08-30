using ITWorxActivity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITWorxActivity.Services.Contracts
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product GeProductByID(int ProductID);
        public IEnumerable<Product> GetProductByCategoryID(int CategoryID);
        public Task<Product> AddProduct(Product product);
        public Task<Product> UpdateProduct(Product product,int ProductID);
    }
}
