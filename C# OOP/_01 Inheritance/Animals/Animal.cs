using System;

namespace Animals
{
    public abstract class Animal
    {
        private int _age;
        private string _gender;
        
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }

        public int Age 
        {
            get => _age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                _age = value;
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                bool isValid = value == "Male" || value == "Female";
                if(!isValid)
                {
                    throw new ArgumentException("Invalid input!");
                }

                _gender = value;
            }
        }

        public abstract string ProduceSound();
    }
}
