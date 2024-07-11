namespace CrudTutorial.Models.Product
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
    }
}
