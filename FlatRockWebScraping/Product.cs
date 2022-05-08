using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FlatRockWebScraping
{
    public class Product
    {
        public Product(string name, decimal price, decimal rating)
        {
            this.Name = name;
            this.Price = price;
            this.Rating = rating;
        }
        private string name;
        private decimal price;
        private decimal rating;

        public string Name 
        {   get => this.name; 
            private set
            {
                this.name = value;
            }
        }
        public decimal Price 
        {
            get => this.price; 
            private  set
            {
                this.price = value;
            }
        }
        public decimal Rating 
        { get => this.rating;
            private set
            {
                this.rating = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  {");
            sb.AppendLine($"    \"productName\": \"{this.Name}\",");
            sb.AppendLine($"    \"price\": \"{this.Price}\",");
            sb.AppendLine($"    \"rating\": \"{this.Rating}\"");
            sb.AppendLine("  }");
            return sb.ToString().TrimEnd();
        }
    }
}
