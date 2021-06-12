namespace _02GenericBoxOfInteger
{
    public class Box<T>
    {
        private readonly T _value;

        public Box(T value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {_value}";
        }
        
    }
}