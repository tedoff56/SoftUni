namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int OxyLevel = 120;

        public FreeDiver(string name)
            : base(name, OxyLevel)
        {

        }

        public override void Miss(int timeToCatch)
        {
            this.OxygenLevel -= (int)Math.Round(timeToCatch * 0.6, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            this.OxygenLevel = OxyLevel;
        }
    }
}
