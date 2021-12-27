namespace NetCore.API.Dto.Product
{
    public class ProductDto : BaseDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}