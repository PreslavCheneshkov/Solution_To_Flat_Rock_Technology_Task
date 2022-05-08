using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FlatRockWebScraping
{
    public static class ProductInfoParser
    {
        public static string ParseName(string value)
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
        public static decimal ParsePrice(string value)
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
        public static decimal ParseRating(string value)
        {
            decimal rating = decimal.Parse(value);
            if (rating > 5 && rating <= 10)
            {
                rating /= 2;
            }
            return rating;
        }
    }
}
