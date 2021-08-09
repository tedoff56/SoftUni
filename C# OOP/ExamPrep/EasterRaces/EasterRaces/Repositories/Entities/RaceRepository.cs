using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private ICollection<IRace> _races;

        public RaceRepository()
        {
            _races = new List<IRace>();
        }
        public IRace GetByName(string name) => _races.FirstOrDefault(r => r.Name == name);

        public IReadOnlyCollection<IRace> GetAll() => (IReadOnlyCollection<IRace>) _races;

        public void Add(IRace model) => _races.Add(model);

        public bool Remove(IRace model) => _races.Remove(model);
    }
}