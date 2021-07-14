using System;
using System.Text;

using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = CorpsTryParse(corps);
        }

        public CorpsEnum Corps { get; private set; }

        private CorpsEnum CorpsTryParse(string corpsText)
        {
            bool isValid = Enum.TryParse(corpsText, out CorpsEnum corps);
            if (!isValid)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps.ToString()}");

            return sb.ToString().TrimEnd();
        }
    }
}