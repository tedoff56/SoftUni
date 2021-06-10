namespace _08CarSalesman
{
    public class Car
    {
        public Car()
        {
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine)
        :this()
        {
            this.Model = model;
            this.Engine = engine;
        }

        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            string weight = this.Weight == -1 ? "n/a" : $"{this.Weight}";
            
            return $"{this.Model}:\n{this.Engine}\n  Weight: {weight}\n  Color: {this.Color}";
        }
    }
}