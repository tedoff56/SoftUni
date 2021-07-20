using System.Collections.Generic;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        public IReadOnlyCollection<IDecoration> Models { get; }
        
        public void Add(IDecoration model)
        {
            
        }

        public bool Remove(IDecoration model)
        {
            throw new System.NotImplementedException();
        }

        public IDecoration FindByType(string type)
        {
            throw new System.NotImplementedException();
        }
    }
}