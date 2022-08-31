using ITWorxActivity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWorxActivity.API.Response
{
    public class CategoryResponse : BaseResponse
    {

        public IEnumerable<Category> Categories { get; set; }
    }
}
