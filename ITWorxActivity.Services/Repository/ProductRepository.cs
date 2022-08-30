using ITWorxActivity.Entities;
using ITWorxActivity.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ITWorxActivity.Services.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ITWorxActivityDbContext _context;
        public ProductRepository(ITWorxActivityDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
               
             var obj =  await _context.Products.AddAsync(product);
            _context.SaveChanges();
            return obj.Entity;

        }

        public Product GeProductByID(int ProductID)
        {
            try
            {
                return _context.Products.SingleOrDefault(p => p.ProductID == ProductID);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Product> GetProductByCategoryID(int CategoryID)
        {
            try
            {
                return _context.Products.Where(p => p.CategoryID == CategoryID).ToList();
            }
            catch(Exception ex) { throw; }
        }

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<Product> UpdateProduct(Product product,int ProductID)
        {
            var obj = _context.Products.SingleOrDefault(p => p.ProductID == ProductID);
            if(obj != null)
            {
                obj.Name = product.Name;
                obj.Price = product.Price;
                obj.Qunatity = product.Qunatity;
                obj.ImageURL = product.ImageURL;
                obj.CategoryID = product.CategoryID;
           await _context.SaveChangesAsync();
            return obj;
            }
            return null;
        }
    }
}
