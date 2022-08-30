using System;
using System.Collections.Generic;
using System.Text;

namespace ITWorxActivity.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qunatity { get; set; }
        public string ImageURL { get; set; }
        public int CategoryID { get; set; }
        public  Category Category { get; set; }
    }
}
