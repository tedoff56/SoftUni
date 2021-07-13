using System;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string _corps;
        
        protected SpecialisedSoldier(
            string id, 
            string firstName, 
            string lastName, 
            decimal salary,
            string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => _corps;
            private set
            {
                bool isValid = value == "Airforces" || value == "Marines";
                if(!isValid)
                {
                    return;
                }
                
                _corps = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{Environment.NewLine}Corps: {this.Corps}";
        }
    }
}