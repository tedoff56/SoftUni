﻿using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private ICollection<IDiver> _models;

        public DiverRepository()
        {
            _models = new List<IDiver>();
        }

        public IReadOnlyCollection<IDiver> Models => _models.ToList().AsReadOnly();

        public void AddModel(IDiver model)
        {
            _models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return _models.FirstOrDefault(d => d.Name == name);
        }
    }
}
