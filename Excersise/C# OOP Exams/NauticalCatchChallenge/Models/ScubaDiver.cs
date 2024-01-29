namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int OxyLevel = 540;

        public ScubaDiver(string name)
            : base(name, OxyLevel)
        {

        }

        public override void Miss(int timeToCatch)
        {
            this.OxygenLevel -= (int)Math.Round(timeToCatch * 0.3, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            this.OxygenLevel = OxyLevel;
        }
    }
}
