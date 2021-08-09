using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string _name;
        private int _laps;
        private readonly ICollection<IDriver> _drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            _drivers = new List<IDriver>();
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
        
        public int Laps
        {
            get => _laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }

                _laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => (IReadOnlyCollection<IDriver>) _drivers;
        
        public void AddDriver(IDriver driver)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(nameof(IDriver), ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            
            if(Drivers.Any(d => d.Name == driver.Name))
            {
                throw new ArgumentNullException(nameof(IDriver), 
                    string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, Name));
            }

            _drivers.Add(driver);
        }
    }
}