namespace _08CarSalesman
{
    public class Engine
    {
        public Engine()
        {
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }
        
        public Engine(string model, int power)
        :this()
        {
            this.Model = model;
            this.Power = power;
        }

        public string Model { get; private set; }

        public int Power { get; private set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            string displacement = this.Displacement == -1 ? "n/a" : $"{this.Displacement}";

            return $"  {this.Model}:\n    Power: {this.Power}\n    Displacement: {displacement}\n    Efficiency: {this.Efficiency}";
        }
    }
}