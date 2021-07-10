using WildFarm.Core;
using WildFarm.Core.Contracts;

namespace WildFarm
{
    class StartUp
    {
       private static void Main()
       {
           IEngine engine = new Engine();
           
           engine.Run();
       }
    }
}