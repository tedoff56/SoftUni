using BirthdayCelebrations.Interfaces;

namespace BirthdayCelebrations.Models
{
    public class Pet : IBirthday
    {
        public Pet(string name, string birthDay)
        {
            Name = name;
            BirthDay = birthDay;
        }
        
        public string Name { get; private set; }

        public string BirthDay { get; private set; }
    }
}