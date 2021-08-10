using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        public Warrior(string name) 
            : base(name, 100, 50, 40, new Satchel())
        {
            
        }

        public void Attack(Character character)
        {
            bool bothAlive = this.IsAlive && character.IsAlive;
            
            if (!bothAlive)
            {
                return;
            }

            if (this.Equals(character))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }
            
            character.TakeDamage(this.AbilityPoints);
        }
    }
}