using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new Dictionary<string, Ingredient>();
        }
        
        public Dictionary<string, Ingredient> Ingredients;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => Ingredients.Sum(i => i.Value.Alcohol);
        
        public void Add(Ingredient ingredient)
        {
            bool isValid = !Ingredients.ContainsKey(ingredient.Name) && 
                           Ingredients.Count < Capacity &&
                           ingredient.Alcohol <= MaxAlcoholLevel;
            if (isValid)
            {
                Ingredients.Add(ingredient.Name, ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.Remove(name))
            {
                return true;
            }

            return false;
        }
        
        public Ingredient FindIngredient(string name)
        {
            return Ingredients.Where(i => i.Value.Name == name).FirstOrDefault().Value;
        } 
        
        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(i => i.Value.Alcohol).FirstOrDefault().Value;
        }
        
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            
            foreach (var kvp in Ingredients)
            {
                sb.AppendLine(kvp.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        } 
    }
}