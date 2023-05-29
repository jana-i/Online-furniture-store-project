namespace EShopAdminApp.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public double ProductRating { get; set; }
    }
}
