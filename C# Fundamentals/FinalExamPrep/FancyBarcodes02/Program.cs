using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes02
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex barcodeRegex = new Regex(@"^@#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+$");
            Regex digitsRegex = new Regex(@"\d");
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                
                Match barcodeMatch = barcodeRegex.Match(barcode);
                
                MatchCollection digits = digitsRegex.Matches(barcode);

                if (!barcodeMatch.Success)
                {
                    Console.WriteLine($"Invalid barcode");
                    continue;;
                }
                
                string productGroup = String.Empty;

                if (digits.Count != 0)
                {
                    foreach (Match digit in digits)
                    {
                        productGroup += digit.Value;
                    }
                }
                else
                {
                    productGroup = "00";
                }
                
                Console.WriteLine($"Product group: {productGroup}");
            }

        }
    }
}