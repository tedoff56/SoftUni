using System;

using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = StateTryParse(state);
        }

        public string CodeName { get; }
        public StateEnum State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == StateEnum.inProgress)
            {
                this.State = StateEnum.Finished;
            }
        }
        
        private StateEnum StateTryParse(string state)
        {
            bool isValid = Enum.TryParse(state, out StateEnum stateEnum);
            if (!isValid)
            {
                throw new InvalidStateException();
            }

            return stateEnum;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }
    }
}