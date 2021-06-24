using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        
        private List<Racer> _racers;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _racers = new List<Racer>();
        }
        
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => _racers.Count;
        
        public void Add(Racer racer)
        {
            if (_racers.Count < Capacity)
            {
                _racers.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            if (_racers.Remove(_racers.Find(r => r.Name == name)))
            {
                return true;
            }

            return false;
        }
        
        public Racer GetOldestRacer()
        {
            return _racers.OrderByDescending(r => r.Age).First();
        }

        public Racer GetRacer(string name)
        {
            return _racers.Find(r => r.Name == name);
        }
        
        public Racer GetFastestRacer()
        {
            return _racers.OrderByDescending(r => r.Car.Speed).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Racers participating at {Name}:");
            _racers.ForEach(r => sb.AppendLine(r.ToString()));

            return sb.ToString().TrimEnd();
        }
        
        
    }
}