using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string _name;
        private int _stamina;
        private ICollection<string> _conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;

            _conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                _name = value;
            }
        }

        public int Stamina
        {
            get => _stamina;
            protected set
            {
                if(_stamina > 10)
                {
                    _stamina = 10;
                }
                else if(_stamina < 0)
                {
                    _stamina = 0;
                }
                else
                {
                    _stamina = value;
                }
            }
        }
        public IReadOnlyCollection<string> ConqueredPeaks
            => _conqueredPeaks.ToList().AsReadOnly();

        public void Climb(IPeak peak)
        {
            if(!_conqueredPeaks.Contains(peak.Name))
            {
                _conqueredPeaks.Add(peak.Name);
            }

            Stamina -= (int)Enum.Parse(typeof(DifficultyLevelsEnum), peak.DifficultyLevel, false);
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            sb.Append("Peaks conquered: ");
            sb.Append(_conqueredPeaks.Count > 0 ? _conqueredPeaks.Count : "no peaks conquered");

            return sb.ToString().TrimEnd();
        }
    }
}
