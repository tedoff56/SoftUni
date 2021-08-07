using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    this.aquariums.Add(new FreshwaterAquarium(aquariumName));
                    break;
                case "SaltwaterAquarium":
                    this.aquariums.Add(new SaltwaterAquarium(aquariumName));
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            switch (decorationType)
            {
                case "Ornament":
                    this.decorations.Add(new Ornament());
                    break;
                case "Plant":
                    this.decorations.Add(new Plant());
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {

            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            IDecoration decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);
            
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {

            bool isFishTypeValid = fishType == nameof(FreshwaterFish) || fishType == nameof(SaltwaterFish);
            
            if (!isFishTypeValid)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            
            IFish fish = null;
            
            if (aquarium.GetType().Name == "FreshwaterAquarium" && fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (aquarium.GetType().Name == "SaltwaterAquarium" && fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }
            
            aquarium.AddFish(fish);
            
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            
            aquarium.Feed();;

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }
        

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal sum = aquarium.Fish.Sum(f => f.Price) + 
                          aquarium.Decorations.Sum(d => d.Price);
            
            return string.Format(OutputMessages.AquariumValue, aquariumName, sum);
        }
        
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (IAquarium aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}