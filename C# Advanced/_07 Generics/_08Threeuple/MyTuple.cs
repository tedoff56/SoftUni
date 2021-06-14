namespace _08Threeuple
{
    public class MyTuple<T,V, U>
    {
        private T _item1;
        private V _item2;
        private U _item3;

        public MyTuple(T item1, V item2, U item3)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
        }
        
        public override string ToString()
        {
            return $"{_item1} -> {_item2} -> {_item3}";
        }
    }
}