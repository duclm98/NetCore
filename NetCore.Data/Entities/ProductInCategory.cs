namespace NetCore.Data.Entities;

public class ProductInCategory : Base
{
    public int ProductInCategoryId { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }

    public Product Product { get; set; }
    public Category Category { get; set; }
}