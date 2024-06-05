using NSwag.Annotations;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Product
    {    
        public int Id { get; set; }

        [OpenApiIgnore]
        public int? IdTypeProduct { get; set; } 

        public string Name { get; set; } = "name";
        public int Price { get; set; } = 1;


        [JsonIgnore] 
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();

        [OpenApiIgnore]
        public TypeProduct? TypeProduct { get; set; } 

        public Product(string name, int price, int idTypeProduct)
        {
            this.Name = name;
            this.Price = price;
            this.IdTypeProduct = idTypeProduct;
        }
        public Product() { }
    }
}
