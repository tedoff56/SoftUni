using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string _name;
        private int _oxygenLevel;
        private double _competitionPoints;
        private bool _hasHealthIssues;
        private ICollection<string> _catches;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            _oxygenLevel = oxygenLevel;
            _competitionPoints = 0;
            _hasHealthIssues = false;

            _catches = new List<string>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }

                _name = value;
            }
        }

        public int OxygenLevel
        {
            get => _oxygenLevel;
            protected set
            {
                if (value <= 0)
                {
                    _oxygenLevel = 0;
                    HasHealthIssues = true;
                }

                _oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch => _catches.ToList().AsReadOnly();

        public double CompetitionPoints
        {
            get => Math.Round(_competitionPoints, 1);
            private set
            {
                _competitionPoints = value;
            }
        }

        public bool HasHealthIssues
        {
            get => _hasHealthIssues;
            private set
            {
                _hasHealthIssues = value;
            }
        }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            _catches.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int timeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
