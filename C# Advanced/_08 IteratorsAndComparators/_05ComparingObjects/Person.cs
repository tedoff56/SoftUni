using System;

namespace _05ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string _name;
        private int _age;
        private string _town;

        public Person(string name, int age, string town)
        {
            _name = name;
            _age = age;
            _town = town;
        }

        public string Name => _name;
        public int Age => _age;
        public string Town => _town;
        
        public int CompareTo(Person other)
        {
            int result = _name.CompareTo(other.Name);
            if (result == 0)
            {
                result = _age.CompareTo(other.Age);
            }

            if (result == 0)
            {
                result = _town.CompareTo(other.Town);
            }

            return result;
        }
    }
}