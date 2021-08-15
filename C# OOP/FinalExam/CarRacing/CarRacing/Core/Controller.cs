using System;
using System.Linq;
using System.Text;
using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private readonly CarRepository cars;
        private readonly RacerRepository racers;
        private readonly IMap map;
        
        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }
        
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            switch (type)
            {
                case nameof(SuperCar):
                    car = new SuperCar(make, model, VIN, horsePower);
                    break;
                case nameof(TunedCar):
                    car = new TunedCar(make, model, VIN, horsePower);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            
            this.cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, car.Make, car.Model, car.VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this.cars.FindBy(carVIN);
            if (car is null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            
            IRacer racer;
            switch (type)
            {
                case nameof(ProfessionalRacer):
                    racer = new ProfessionalRacer(username, car);
                    break;
                case nameof(StreetRacer):
                    racer = new StreetRacer(username, car);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            
            this.cars.Remove(car);
            this.racers.Add(racer);
    
            return string.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);
            
            if (racerOne is null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            if (racerTwo is null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            
            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var result = this.racers.Models
                .OrderByDescending(r => r.DrivingExperience)
                .ThenBy(r => r.Username);

            StringBuilder sb = new StringBuilder();
            
            foreach (IRacer racer in result)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}