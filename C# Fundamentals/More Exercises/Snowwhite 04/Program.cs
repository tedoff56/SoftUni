using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite_04
{

    class Dwarf
    {
        public string Name { get; set; }

        public string HatColor { get; set; }

        public int Physics { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<Dwarf>> dwarfsData = new Dictionary<string, List<Dwarf>>();
            
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Once upon a time")
                {
                    break;
                }

                string[] data = line.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

                string dwarfName = data[0];
                string dwarfHatColor = data[1];
                int dwarfPhysics = int.Parse(data[2]);

                Dwarf dwarf = new Dwarf()
                {
                    Name = dwarfName,
                    HatColor = dwarfHatColor,
                    Physics = dwarfPhysics
                };
                
                if(!dwarfsData.ContainsKey(dwarfName))
                {
                    dwarfsData.Add(dwarfName, new List<Dwarf>());
                }

                if (!dwarfsData[dwarfName].Any(d=> d.HatColor == dwarfHatColor))
                {
                    dwarfsData[dwarfName].Add(dwarf);
                    continue;
                }

                int currentDwarfPhysics = dwarfsData[dwarfName].Find(d=>d.HatColor == dwarfHatColor).Physics;
                
                dwarfPhysics = dwarfPhysics > currentDwarfPhysics ? dwarfPhysics 
                    : currentDwarfPhysics;

                dwarf = new Dwarf()
                {
                    Name = dwarfName,
                    HatColor = dwarfHatColor,
                    Physics = dwarfPhysics
                };

                int index = dwarfsData[dwarfName].IndexOf(dwarfsData[dwarfName].Find(d=>d.HatColor == dwarfHatColor));
                
                dwarfsData[dwarfName][index].Physics = dwarfPhysics;
            }

            foreach (var kvp in dwarfsData)))
            {
                
            }

            
           
        }
    }
}
        
