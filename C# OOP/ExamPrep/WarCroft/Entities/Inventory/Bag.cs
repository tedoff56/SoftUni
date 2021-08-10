using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly ICollection<Item> _items;
        
        protected Bag(int capacity)
        {
            _items = new List<Item>();
            
            this.Capacity = capacity;
        }

        public int Capacity { get; set; } = 100;

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection<Item>) _items;
        
        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            _items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Load == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = _items.FirstOrDefault(i => i.GetType().Name == name);

            if (item is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            _items.Remove(item);

            return item;
        }
    }
}