using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;

namespace _02Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> _list;
        private int _index;

        public ListyIterator(params T[] elements)
        {
            _list = new List<T>(elements);
            _index = 0;
        }
        public List<T> List1 => _list;
        
        public bool HasNext()
        {
            if (_index + 1 < _list.Count)
            {
                return true;
            }

            return false;
        }
        
        public bool Move()
        {
            if (HasNext())
            {
                _index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (_list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            
            Console.WriteLine(_list[_index]);
        }

        public void PrintAll() => Console.WriteLine(string.Join(" ", _list));

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in _list)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}