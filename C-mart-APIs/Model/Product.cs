namespace C_mart_APIs.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; } = null!;
        public int NoOfItems { get; set; }
    }
}
