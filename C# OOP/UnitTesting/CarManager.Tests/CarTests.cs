using System;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Make", "Model", 5, 100);
        }

        [Test]
        [TestCase(null, "Model", 5, 100)]
        [TestCase("", "Model", 5, 100)]
        [TestCase("Make", null, 5, 100)]
        [TestCase("Make", "", 5, 100)]
        [TestCase("Make", "Model", -1, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", 5, -1)]
        [TestCase("Make", "Model", 5, 0)]
        
        public void Ctor_ThrowsExceptionIfArgumentsAreInvalid(string make, string model, int fuelConsumption, int fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void Ctor_CreateACarWithValidArguments()
        {
            var make = "Make";
            var model = "Model";
            var fuelConsumption = 5;
            var fuelCapacity = 100.0;

            Car fakeCar = new Car(make, model, fuelConsumption, fuelCapacity);
            
            Assert.That(car.Make, Is.EqualTo(fakeCar.Make));
            Assert.That(car.Model, Is.EqualTo(fakeCar.Model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fakeCar.FuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fakeCar.FuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Refuel_ThrowsExceptionIfProvidedAmountIsZeroOrNegative(int amount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(amount);
            });
        }

        [Test]
        public void Refuel_SetFuelAmountToCapacityWhenExceeded()
        {
            double capacity = car.FuelCapacity;
            car.Refuel(120);
            Assert.That(car.FuelAmount, Is.EqualTo(capacity));
        }

        [Test]
        public void Refuel_RefuelWithHalfOfCapacity()
        {
            double amount = car.FuelCapacity / 2;
            
            car.Refuel(amount);
            
            Assert.That(car.FuelAmount, Is.EqualTo(amount));
        }

        [Test]
        public void Drive_ThrowsExceptionIfThereIsNotEnoughFuel()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(10);
            });
        }

        [Test]
        public void Drive_SuccessfullyDroveTheDistance()
        {
            car.Refuel(car.FuelCapacity);

            double distance = 100;

            double neededFuel = (distance / 100) * car.FuelConsumption;
            
            car.Drive(distance);
            
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity - neededFuel));
        }
    }
}