using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string _name;

        public Driver(string name)
        {
            Name = name;
        }
        
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                _name = value;
            }
        }
        
        public ICar Car { get; private set; }
        
        public int NumberOfWins { get; private set; }

        public bool CanParticipate => !(Car is null);
        
        public void WinRace()
        {
            NumberOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car is null)
            {
                throw new ArgumentNullException(nameof(ICar), ExceptionMessages.CarInvalid);
            }

            Car = car;
        }
    }
}