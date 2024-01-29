using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        private string _name;
        private double _points;
        private int _timeToCatch;

        protected Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            _timeToCatch = timeToCatch;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }

                _name = value;
            }
        }

        public double Points
        {
            get => _points;
            private set
            {
                if (value < 1 && value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.PointsNotInRange);
                }

                _points = value * 1.0;
            }
        }

        public int TimeToCatch
        {
            get => _timeToCatch;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";

        }
    }
}
