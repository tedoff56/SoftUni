using System;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {

        private string _state;
        
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; }

        public string State
        {
            get => _state;
            private set
            {
                bool isValid = value == "finished" || value == "inProgress";
                if (!isValid)
                {
                    _state = value;
                }

                _state = "inProgress";
            }
        }

        public void CompleteMission()
        {
            this.State = "finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}