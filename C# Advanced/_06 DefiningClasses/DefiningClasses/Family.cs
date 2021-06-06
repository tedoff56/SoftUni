using System.Collections.Generic;

namespace DefiningClasses
{
    public static class Family
    {
        private static List<Person> _members = new List<Person>();

        public static List<Person> Members
        {
            get => _members;
            set => _members = value;
        }

        public static void AddMember(Person person)
        {
            _members.Add(person);
        }

        public static Person GetOldestMember()
        {
            int minVal = int.MinValue;
            Person currentOldest = new Person();
            foreach (var member in _members)
            {
                if (member.Age > minVal)
                {
                    minVal = member.Age;
                    currentOldest = member;;
                }
            }

            return currentOldest;
        }
    }
}