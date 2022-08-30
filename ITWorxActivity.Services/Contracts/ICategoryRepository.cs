using ITWorxActivity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITWorxActivity.Services.Contracts
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
    }
}
