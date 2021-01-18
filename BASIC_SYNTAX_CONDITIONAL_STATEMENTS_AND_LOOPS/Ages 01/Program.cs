using System;

namespace Ages_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int ages = int.Parse(Console.ReadLine());
            string person = "";
            if (ages >= 0 && ages <= 2)
                person = "baby";
            else if (ages >= 3 && ages <= 13)
                person = "child";
            else if (ages >= 14 && ages <= 19)
                person = "teenager";
            else if (ages >= 20 && ages <= 65)
                person = "adult";
            else if (ages >= 66)
                person = "elder";
            Console.WriteLine(person);
        }
    }
}