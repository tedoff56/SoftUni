using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private ICollection<IPeak> _peaks;

        public PeakRepository()
        {
            _peaks = new List<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All => _peaks.ToList().AsReadOnly();

        public void Add(IPeak model)
        {
            _peaks.Add(model);
        }

        public IPeak Get(string name)
        {
            return _peaks.FirstOrDefault(p => p.Name == name);
        }
    }
}
