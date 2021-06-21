using System.Collections;
using System.Collections.Generic;

namespace _04Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private List<T> _stones;

        public Lake(params T[] elements)
        {
            _stones = new List<T>(elements);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return _stones[i];
                }
            }
            
            for (int i = _stones.Count - 1; i >= 0 ; i--)
            {
                if (i % 2 != 0)
                {
                    yield return _stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}