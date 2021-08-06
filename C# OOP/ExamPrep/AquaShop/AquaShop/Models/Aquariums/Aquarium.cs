using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string _name;
        private ICollection<IDecoration> _decorations;
        private ICollection<IFish> _fish;
        
        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            
            _decorations = new List<IDecoration>();
            _fish = new List<IFish>();
        }
        
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                _name = value;
            }
        }
        
        public int Capacity { get; }

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => _decorations;

        public ICollection<IFish> Fish => _fish;
        
        public void AddFish(IFish fish)
        {
            if (this.Fish.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            
            _fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            return _fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            _decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (IFish fish in _fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            
            string fish = this.Fish.Count == 0 
                ? "none" 
                : string.Join(", ", this.Fish.Select(f => f.Name));
            
            sb.AppendLine($"Fish: {fish}");

            sb.AppendLine($"Decorations: {this.Decorations.Count}");

            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}