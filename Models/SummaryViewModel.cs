namespace OnlineShoppingApp.Models
{
    public class SummaryViewModel
    {
        public List<CartItem> Items { get; set; } = new();
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}