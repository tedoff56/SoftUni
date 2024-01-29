namespace NauticalCatchChallenge
{
    using NauticalCatchChallenge.Core;
    using NauticalCatchChallenge.Core.Contracts;
    using System.Globalization;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}