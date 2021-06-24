using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> _players;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _players = new List<Player>(capacity);
        }
        
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => _players.Count;
        
        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                _players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (_players.Remove(_players.Find(p => p.Name == name)))
            {
                return true;
            }
            
            return false;
        }
        
        public void PromotePlayer(string name)
        {
            Player player = _players.Find(p => p.Name == name);

            if (player != null)
            {
                player.Rank = "Member";
            }
        } 
        
        public void DemotePlayer(string name)
        {
            Player player = _players.Find(p => p.Name == name);

            if (player != null)
            {
                player.Rank = "Trial";
            }
        }
        
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] removedPlayers = _players.Where(p => p.Class == @class).ToArray();
            
            _players.RemoveAll(p => p.Class == @class);
            
            return removedPlayers;
        } 
        
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");
            _players.ForEach(p => sb.AppendLine(p.ToString()));

            return sb.ToString().TrimEnd();
        } 
    }
}