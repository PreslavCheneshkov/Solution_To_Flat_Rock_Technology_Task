using System;
using System.Text;

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

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public decimal Rating { get; private set; }
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
