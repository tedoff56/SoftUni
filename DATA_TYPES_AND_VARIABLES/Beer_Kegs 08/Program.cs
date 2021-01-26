using System;
using System.IO;

namespace Beer_Kegs_08
{
    class Program
    {
        static void Main(string[] args)
        {

            int nKegs = int.Parse(Console.ReadLine());
            string biggestKeg = " ";
            double lastVolume = int.MinValue;
            for (int i = 0; i < nKegs; i++)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());
                double volume = Math.PI * Math.Pow(kegRadius, 2) * kegHeight;

                if (volume > lastVolume)
                {
                    lastVolume = volume;
                    biggestKeg = kegModel;
                }
                
            }

            Console.WriteLine(biggestKeg);
            
        }
    }
}