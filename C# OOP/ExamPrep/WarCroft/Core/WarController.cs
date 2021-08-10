using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly ICollection<Character> _characterParty;
		private readonly Stack<Item> _itemPool;
		
		public WarController()
		{
			_characterParty = new List<Character>();
			_itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string charType = args[1];
			string charName = args[2];
			
			switch (charType)
			{
				case nameof(Warrior):
					_characterParty.Add(new Warrior(charName));
					break;
				case nameof(Priest):
					_characterParty.Add(new Priest(charName));
					break;
				default:
					throw new ArgumentException(
						string.Format(ExceptionMessages.InvalidCharacterType, charType));
			}

			return string.Format(SuccessMessages.JoinParty, charName);
		}

		public string AddItemToPool(string[] args)
		{
			string itemType = args[1];

			switch (itemType)
			{
				case nameof(FirePotion):
					_itemPool.Push(new FirePotion());
					break;
				case nameof(HealthPotion):
					_itemPool.Push(new HealthPotion());
					break;
				default:
					throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemType));
			}

			return string.Format(SuccessMessages.AddItemToPool, itemType);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[1];
			
			Character character = _characterParty.FirstOrDefault(c => c.Name == characterName);
			
			if (character is null)
			{
				throw new ArgumentException(
					string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			if (!_itemPool.Any())
			{
				throw new InvalidOperationException(
					ExceptionMessages.ItemPoolEmpty);
			}

			Item item = _itemPool.Pop();
			character.Bag.AddItem(item);
			
			return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[1];
			string itemName = args[2];

			Item item = _itemPool.FirstOrDefault(i => i.GetType().Name == itemName);
			
			Character character = _characterParty.FirstOrDefault(c => c.Name == characterName);

			if (character is null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			throw new NotImplementedException();
		}

		public string Attack(string[] args)
		{
			throw new NotImplementedException();
		}

		public string Heal(string[] args)
		{
			throw new NotImplementedException();
		}
	}
}
