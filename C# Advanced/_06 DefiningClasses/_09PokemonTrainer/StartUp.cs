using System;
using System.Collections.Generic;
using System.Linq;

namespace _09PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = GetTrainers();

            string element = Console.ReadLine();
            while (element?.ToLower() != "end")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.CheckPokemonsElements(element))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.RemoveHealth();
                    }
                }
            
                element = Console.ReadLine();
            }
            
            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine(trainer);
            }
        }

        private static List<Trainer> GetTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();

            string line = Console.ReadLine();
            while (line?.ToLower() != "tournament")
            {
                string[] data = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = data[0];
                
                if (!trainers.Any(t => t.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                Trainer findTrainer = trainers.Find(t => t.Name == trainerName);

                findTrainer.CatchPokemon(new Pokemon(data[1], data[2], int.Parse(data[3])));

                line = Console.ReadLine();
            }

            return trainers;
        }
    }
}