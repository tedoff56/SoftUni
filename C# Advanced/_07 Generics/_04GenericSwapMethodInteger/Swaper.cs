using System.Collections.Generic;
using System.Text;

namespace _04GenericSwapMethodInteger
{
    public class Swaper<T>
    {
        private List<T> _list;
        
        public Swaper()
        {
            _list = new List<T>();
        }
        
        public void Swap(int firstIndex, int secondIndex)
        {
            T oldElement = _list[firstIndex];
            _list[firstIndex] = _list[secondIndex];
            _list[secondIndex] = oldElement;
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in _list)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}