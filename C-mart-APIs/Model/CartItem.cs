namespace C_mart_APIs.Model
{
    public class CartItem
    {
        public int UserId { get; set; }
        public int productId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
