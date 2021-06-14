namespace _07Tuple
{
    public class MyTuple<T,V>
    {
        private T _item1;
        private V _item2;

        public MyTuple(T item1, V item2)
        {
            _item1 = item1;
            _item2 = item2;
        }
        
        public override string ToString()
        {
            return $"{_item1} -> {_item2}";
        }
    }
}