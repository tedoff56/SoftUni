﻿using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public  class BaseCamp
    {
        private ICollection<string> _residents;

        public BaseCamp()
        {
            _residents = new List<string>();
        }

        public IReadOnlyCollection<string> Residents 
            => _residents.ToList().AsReadOnly();

        public void ArriveAtCamp(string climberName)
        {
            _residents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            _residents.Remove(climberName);
        }
    }
}
