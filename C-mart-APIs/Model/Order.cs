namespace C_mart_APIs.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public string? Product { get; set; }
        public DateTime DateTime { get; set; }
        public int Price { get; set; }
    }
}
