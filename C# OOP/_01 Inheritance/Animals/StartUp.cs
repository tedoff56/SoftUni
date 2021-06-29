using System;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            StringBuilder sb = new StringBuilder();
            
            while (true)
            {
                string animalType = Console.ReadLine();
                string[] animalData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (animalType == "Beast!")
                {
                    Console.WriteLine(sb.ToString().Trim());
                    break;
                }
                
                Animal animal;
                
                string name = animalData[0];
                int age = int.Parse(animalData[1]);
                string gender = animalData[2];

 
                switch (animalType)
                {
                    case "Cat":
                        animal = new Cat(name, age, gender);
                        break;
                    case "Tomcat":
                        animal = new Tomcat(name, age);
                        break;
                    case "Kitten":
                        animal = new Kitten(name, age);
                        break;
                    case "Dog":
                        animal = new Dog(name, age, gender);
                        break;
                    case "Frog":
                        animal = new Frog(name, age, gender);
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }

                sb.AppendLine($"{animalType}")
                    .AppendLine($"{animal.Name} {animal.Age} {animal.Gender}")
                    .AppendLine(animal.ProduceSound());
            }
        }
    }
}
