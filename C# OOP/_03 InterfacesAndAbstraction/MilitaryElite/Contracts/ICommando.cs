using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ICommando
    {
        public ICollection<IMission> Missions { get; }
    }
}