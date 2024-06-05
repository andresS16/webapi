namespace WebApi.Models
{
    public class TypeProduct
    {       
        public int Id { get; set; }
        public string? Description { get; set; } 
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public TypeProduct(string description)
        {
            this.Description =  description;        
        }
        public TypeProduct() { }
    }
}
