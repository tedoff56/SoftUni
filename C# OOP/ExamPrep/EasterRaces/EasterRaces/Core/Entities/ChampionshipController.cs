using System;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> _drivers;
        private readonly IRepository<ICar> _cars;
        private readonly IRepository<IRace> _races;
        
        public ChampionshipController()
        {
            _drivers = new DriverRepository();
            _cars = new CarRepository();
            _races = new RaceRepository();
        }
        
        public string CreateDriver(string driverName)
        {
            IDriver driver = _drivers.GetByName(driverName);
            
            if (!(driver is null))
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.DriversExists, driverName));
            }
            
            _drivers.Add(new Driver(driverName));
            
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = _cars.GetByName(model);
            
            if (!(car is null))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
            }
            
            _cars.Add(car);
            
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = _races.GetByName(name);

            if (!(race is null))
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceExists, name));
            }
            
            _races.Add(new Race(name, laps));

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = _races.GetByName(raceName);
            IDriver driver = _drivers.GetByName(driverName);

            if (race is null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driver is null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            
            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = _drivers.GetByName(driverName);
            ICar car = _cars.GetByName(carModel);

            if (driver is null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (car is null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            
            driver.AddCar(car);
            
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string StartRace(string raceName)
        {
            IRace race = _races.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            string[] winners = _drivers.GetAll()
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Select(d => d.Name).ToArray();

            _races.Remove(race);
            
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winners[0], raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winners[1], raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, winners[2], raceName));

            return sb.ToString().TrimEnd();
        }
    }
}