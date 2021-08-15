using System;
using System.Collections.Generic;
using System.Linq;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>) this.cars;
        
        public void Add(ICar model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            this.cars.Add(model);
        }

        public bool Remove(ICar model)
        {
            return this.cars.Remove(model);
        }

        public ICar FindBy(string property)
        {
            return this.cars.FirstOrDefault(c => c.VIN == property);
        }
    }
}