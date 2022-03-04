namespace NetCore.Data.Entities
{
    public class Invoice : Base
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}