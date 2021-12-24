using System.Collections.Generic;

namespace NetCore.Data.Entities
{
    public class Category : Base
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}