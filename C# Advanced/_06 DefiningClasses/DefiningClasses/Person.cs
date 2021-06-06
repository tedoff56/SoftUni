namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        
        
        public Person(string name, int age) 
        {
            this.name = name;
            this.age = age;
        }
        
        public Person() : this("No name", 1) { }
        
        public Person(int age) : this("No name", age) { }
        
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{name} - {age}";
        }
    }
}