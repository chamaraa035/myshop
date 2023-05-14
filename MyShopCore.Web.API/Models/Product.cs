namespace MyShopCore.Web.API.Models
{
    public class Product
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int OrderAfter { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
