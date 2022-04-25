using NetCore.Helpers.Models;

namespace NetCore.API.Dto.Product
{
    public class ProductQuery : Pagination
    {
        public string ProductName { get; set; }
    }
}