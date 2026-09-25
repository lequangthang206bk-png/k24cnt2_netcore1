namespace LQThangShopdochoi.Models
{
    public class CartItem
    {
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }
        public decimal Total => Product.Price * Quantity;
    }
}
