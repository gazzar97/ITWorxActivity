using System;
using System.Collections.Generic;
using System.Text;

namespace ITWorxActivity.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
