using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> _cars;
        private int _capacity;

        public Parking(int capacity)
        {
            _cars = new List<Car>();
            _capacity = capacity;
        }

        public int Capacity => _capacity;
        
        public int Count => _cars.Count;

        public string AddCar(Car car)
        {
            if (CarExists(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (_cars.Count == _capacity)
            {
                return "Parking is full!";
            }

            _cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!CarExists(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            _cars.Remove(FindCar(registrationNumber));

            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return FindCar(registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            _cars = _cars.Where(c => !registrationNumbers.Contains(c.RegistrationNumber)).ToList();
        }

        private bool CarExists(string registrationNumber)
        {
            return _cars.Exists(c => c.RegistrationNumber == registrationNumber);
        }

        private Car FindCar(string registrationNumber)
        {
            return _cars.Find(c => c.RegistrationNumber == registrationNumber);
        }

    }
}