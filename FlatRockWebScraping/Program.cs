using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FlatRockWebScraping
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
           
            using (StreamReader reader = new StreamReader(@"..\..\..\htmlSource.txt"))
            {
                string htmlSource = reader.ReadToEnd();
                Regex regex = new Regex(@"(?s)rating = ""(?<rating>\d\.?\d?)"".*?img alt.*?""(?<name>(\w+\s?-?\w)+ \S*\s?\w* \S*\s?\w*).*?<\/a>.*?\$(?<price>\d*,?\d+\.\d{2})<");

                
                MatchCollection matches = regex.Matches(htmlSource);
                foreach (Match match in matches)
                {
                    string productName = ProductInfoParser.ParseName(match.Groups["name"].Value);
                    decimal productPrice = ProductInfoParser.ParsePrice(match.Groups["price"].Value);
                    decimal productRating = ProductInfoParser.ParseRating(match.Groups["rating"].Value);
                    Product product = new Product(productName, productPrice, productRating);
                    products.Add(product);
                }
            }
            Console.WriteLine("[");
            for (int i = 0; i < products.Count; i++)
            {
                if (i == products.Count - 1)
                {
                    Console.WriteLine(products[i].ToString());
                }
                else
                {
                    Console.WriteLine(products[i].ToString() + ",");
                }
            }
            Console.WriteLine("]");
        }
    }
}
