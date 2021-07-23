using System;
using System.Collections.Generic;
using System.Linq;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
        private DecorationRepository _decorations;
        private ICollection<IAquarium> _aquariums;

        public Controller()
        {
            _aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if(aquariumType == "FreshwaterAquarium")
            {
                _aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                _aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = CreateDecoration(decorationType);

            _decorations.Add(decoration);
            
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = _aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IDecoration decoration = _decorations.FindByType(decorationType);
            
            aquarium.AddDecoration(decoration);
            if (!_decorations.Remove(decoration))
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDecoration);
            }

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            throw new System.NotImplementedException();
        }

        public string FeedFish(string aquariumName)
        {
            throw new System.NotImplementedException();
        }

        public string CalculateValue(string aquariumName)
        {
            throw new System.NotImplementedException();
        }

        public string Report()
        {
            throw new System.NotImplementedException();
        }

        private IDecoration CreateDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return decoration;
        }
    }
}