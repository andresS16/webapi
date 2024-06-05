using System.Text.Json.Serialization;


namespace WebApi.Models
{
    public class Stock
    {      
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }

        [JsonIgnore] 
        public Product Product { get; set; } 

        public Stock(int amount , int idproduct)
        {
             this.Amount = amount;
            this.IdProduct = idproduct;
        }
        public Stock()
        {        
        }
    }
}
