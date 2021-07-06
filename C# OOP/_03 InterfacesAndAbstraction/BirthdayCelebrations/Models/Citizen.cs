using BirthdayCelebrations.Interfaces;

namespace BirthdayCelebrations.Models
{
    public class Citizen : ICheckable, IBirthday
    {
        public Citizen(string name, int age, string id, string birthDay)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDay = birthDay;
        }
        
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string BirthDay { get; private set; }
    }
}