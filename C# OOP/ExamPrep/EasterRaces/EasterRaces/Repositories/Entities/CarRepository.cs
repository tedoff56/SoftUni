using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> _cars;

        public CarRepository()
        {
            _cars = new List<ICar>();
        }
        
        public ICar GetByName(string name) => _cars.FirstOrDefault(c => c.Model == name);

        public IReadOnlyCollection<ICar> GetAll() => (IReadOnlyCollection<ICar>) _cars;

        public void Add(ICar model) => _cars.Add(model);

        public bool Remove(ICar model) => _cars.Remove(model);
        
    }
}