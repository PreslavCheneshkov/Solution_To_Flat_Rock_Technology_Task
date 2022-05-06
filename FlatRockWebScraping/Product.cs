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
        public Product(string name, string price, string rating)
        {
            this.Name = this.ParseName(name);
            this.Price = this.ParsePrice(price);
            this.Rating = this.ParseRating(rating);
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
        private string ParseName(string value)
        {
            string toReturn = string.Empty;
            string[] names = value.Split();
            foreach (var name in names)
            {
                bool isValid = true;
                foreach (var character in name)
                {
                    if (!char.IsLetterOrDigit(character))
                    {
                        isValid = false;
                    }
                }
                if (isValid)
                {
                    toReturn += name + " ";
                }
                else
                {
                    toReturn += HttpUtility.HtmlDecode(name) + " ";
                }
            }
            toReturn = toReturn.TrimEnd();
            if (toReturn.EndsWith('"'))
            {
                toReturn = toReturn.Remove(toReturn.Length - 1, 1);
            }
            return toReturn;
        }
        private decimal ParsePrice(string value)
        {
            string stringDecimal = string.Empty;
            foreach (var character in value)
            {
                if (char.IsDigit(character))
                {
                    stringDecimal += character;
                }
                else if (character == ',')
                {
                    continue;
                }
                else if (character == '.')
                {
                    stringDecimal += character;
                }
            }

            return decimal.Parse(stringDecimal);
        }
        private decimal ParseRating(string value)
        {
            decimal rating = decimal.Parse(value);
            if (rating > 5 && rating <= 10)
            {
                rating /= 2;
            }
            return rating;
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
