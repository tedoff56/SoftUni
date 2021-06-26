using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> _data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _data = new List<Ski>();
        }
        
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => _data.Count;
        
        public void Add(Ski ski)
        {
            if (Count < Capacity)
            {
                _data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var ski = _data.Find(s => s.Manufacturer == manufacturer && s.Model == model);

            return _data.Remove(ski);
        }
        
        public Ski GetNewestSki()
        {
            return _data.OrderByDescending(s => s.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return _data.Find(s => s.Manufacturer == manufacturer && s.Model == model);
        }
        
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");
            _data.ForEach(s => sb.AppendLine(s.ToString()));

            return sb.ToString().TrimEnd();
        } 
    }
}