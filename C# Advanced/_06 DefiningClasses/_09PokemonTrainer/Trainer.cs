using System;
using System.Collections.Generic;
using System.Linq;

namespace _09PokemonTrainer
{
    public class Trainer
    {
        
        public Trainer(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; private set; } = new List<Pokemon>();

        public void CatchPokemon(Pokemon pokemon) => this.Pokemons.Add(pokemon);
        
        public bool CheckPokemonsElements(string element) => this.Pokemons.Exists(p => p.Element == element);

        public void RemoveHealth()
        {
            for (int i = 0; i < this.Pokemons.Count; i++)
            {
                this.Pokemons[i].Health -= 10;
                if (this.Pokemons[i].Health <= 0)
                {
                    this.Pokemons.Remove(this.Pokemons[i]);
                }
            }
        }

        public override string ToString() => $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
    }
}