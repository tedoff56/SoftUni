using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MultiplyBigNumber05
{
    class Program
    {
        static void Main(string[] args)
        {

            string bigNumber = Console.ReadLine();
            int digit = int.Parse(Console.ReadLine());

            StringBuilder product = new StringBuilder();
            
            int lastIndex = bigNumber.Length - 1;
            int remainder = 0;
            for (int i = lastIndex; i >= 0 ; i--)
            {
                if (digit == 0)
                {
                    product.Append(0);
                    break;
                }
                int currentNumber = (int)char.GetNumericValue(bigNumber[i]);
                int currentProduct = digit * currentNumber + remainder;

                remainder = currentProduct / 10;
                int lastDigit = currentProduct % 10;

                product.Append(lastDigit);
            }
            
            if(remainder != 0)
            {
                product.Append(remainder);
            }

            var bigNumberProduct = product.ToString().Reverse().ToArray();
            
            Console.WriteLine(bigNumberProduct);
        }
    }
}