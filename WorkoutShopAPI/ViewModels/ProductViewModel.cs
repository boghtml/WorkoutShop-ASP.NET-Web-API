namespace WorkoutShopAPI.ViewModels
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
