using System;
using System.Collections;
using System.Collections.Generic;

namespace _03Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> _elements;

        public MyStack()
        {
            _elements = new List<T>();
        }
        
        public void Push(params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                _elements.Add(elements[i]);
            }
        }

        public T Pop()
        {
            if (_elements.Count == 0)
            {
                Console.WriteLine("No elements");
                return default;
            }
            
            T element = _elements[_elements.Count - 1];
            
            _elements.RemoveAt(_elements.Count - 1);

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _elements.Count - 1; i >= 0 ; i--)
            {
                yield return _elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}