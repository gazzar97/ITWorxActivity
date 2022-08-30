using ITWorxActivity.Entities;
using ITWorxActivity.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ITWorxActivity.Services.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ITWorxActivityDbContext dbContext;
        public CategoryRepository(ITWorxActivityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Category> GetCategories()
        {
            try
            {
                return dbContext.Categories.ToList();
            }
            catch(Exception ex)
            {

                throw;
            }
        }
    }
}
