namespace _01GenericBoxOfString
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