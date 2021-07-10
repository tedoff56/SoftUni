using System;
using System.Collections.Generic;

namespace Raiding.Models
{
    public abstract class BaseHero
    {
        private string _type;
        private IReadOnlyDictionary<string, int> _powerByType = new Dictionary<string, int>()
        {
            {"Druid", 80},
            {"Paladin", 100},
            {"Rogue", 80},
            {"Warrior", 100}
        };
        
        protected BaseHero(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; private set; }

        public string Type
        {
            get => _type;
            private set
            {
                if (!_powerByType.ContainsKey(value))
                {
                    throw new Exception("Invalid hero!");
                }

                _type = value;
            }
        }
        public int Power => _powerByType[$"{this.Type}"];

        public virtual string CastAbility()
        {
            if(this.Type == "Druid" || this.Type == "Paladin")
            {
                return $"{Type} - {Name} healed for {Power}";
            }
            else
            {
                return $"{Type} - {Name} hit for {Power} damage";
            }
        }
    }
}