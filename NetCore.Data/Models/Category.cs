using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.Models
{
    public class Category
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
