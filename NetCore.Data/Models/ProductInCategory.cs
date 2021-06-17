using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.Models
{
    public class ProductInCategory
    {
        public long ProductID { get; set; }
        public Product Product { get; set; }
        public long CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
