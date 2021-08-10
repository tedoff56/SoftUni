using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters
{
    public abstract class Character
    {
	    private string _name;
		private double _health;
		private double _armor;

		protected Character(
			string name, 
			double baseHealth, 
			double baseArmor, 
			double abilityPoints, 
			Bag bag)
		{
			this.Name = name;
			
			this.Health = baseHealth;
			this.BaseHealth = this.Health;
			
			this.Armor = baseArmor;
			this.BaseArmor = this.Armor;
			
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
		}
		
		public bool IsAlive { get; private set; } = true;

		public string Name
		{
			get => _name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(
						ExceptionMessages.CharacterNameInvalid);
				}

				_name = value;
			}
		}

		public double BaseHealth { get; }
		public double Health
		{
			get => _health;
			set
			{
				if (value > this.BaseHealth)
				{
					_health = this.BaseHealth;
				}
				else if (value <= 0)
				{
					this.IsAlive = false;
					_health = 0;
				}
				else
				{
					_health = value;
				}
			}
		}

		public double BaseArmor { get; }

		public double Armor
		{
			get => _armor;
			private set
			{
				if (value > this.BaseArmor)
				{
					_armor = this.BaseArmor;
				}
				else if (value <= 0)
				{
					_armor = 0;
				}
				else
				{
					_armor = value;
				}
			}
		}

		public double AbilityPoints { get; }

		public Bag Bag { get; }

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(
					ExceptionMessages.AffectedCharacterDead);
			}
		}
		
		public void TakeDamage(double hitPoints)
		{
			this.EnsureAlive();
			
			double damageToTake = this.Armor - hitPoints;
			if (damageToTake <= 0)
			{
				this.Health -= Math.Abs(damageToTake);
			}

			this.Armor -= hitPoints;
		}
		
		public void UseItem(Item item)
		{
			item.AffectCharacter(this);
		}
	}
}