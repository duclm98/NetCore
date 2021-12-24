using System.Collections.Generic;

namespace NetCore.Data.Entities
{
    public class Product : Base
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}