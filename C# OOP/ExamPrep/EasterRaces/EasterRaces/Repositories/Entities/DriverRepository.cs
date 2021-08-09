using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly ICollection<IDriver> _drivers;

        public DriverRepository()
        {
            _drivers = new List<IDriver>();
        }
        
        public IDriver GetByName(string name) => _drivers.FirstOrDefault(d => d.Name == name);

        public IReadOnlyCollection<IDriver> GetAll() => (IReadOnlyCollection<IDriver>) _drivers;

        public void Add(IDriver model) => _drivers.Add(model);

        public bool Remove(IDriver model) => _drivers.Remove(model);
    }
}