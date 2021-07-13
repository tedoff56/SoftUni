using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Contracts;
using MilitaryElite.Models;

namespace MilitaryElite
{
    class StartUp
    {
        private static void Main(string[] args)
        {

            List<ISoldier> soldiers = new List<ISoldier>();
            
            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens[0] == "End")
                {
                    break;
                }
                
                string division = tokens[0];
                
                string id = tokens[1];
                string firstName = tokens[2];
                string lastName = tokens[3];
                decimal salary = decimal.Parse(tokens[4]);
                
                switch (division)
                {
                    case "Private":
                        soldiers.Add(new Private(id, firstName, lastName, salary));
                        break;
                    
                    case "LieutenantGeneral":
                        string[] ids = tokens.Skip(5).ToArray();
                        var privates = soldiers
                            .Where(s => ids.Any(i => i == s.Id))
                            .Select(s => (IPrivate)s).Reverse().ToArray();
                        
                        soldiers.Add(new LieutenantGeneral(id, firstName, lastName, salary, privates));
                        break;
                    
                    case "Commando":
                        string[] missionsData = tokens.Skip(6).ToArray();
                        
                        List<IMission> missions = new List<IMission>();
                        
                        for (int i = 0; i < missionsData.Length - 1; i += 2)
                        {
                            string codeName = missionsData[i];
                            string missionState = missionsData[i + 1];
                            if (missionState == "inProgress")
                            {
                                missions.Add(new Mission(codeName, missionState));
                            }
                        }
                        soldiers.Add(new Commando(id, firstName, lastName, salary, tokens[5], missions));
                        break;
                    
                    case "Engineer":
                        string[] repairsData = tokens.Skip(6).ToArray();
                        List<IRepair> repairs = new List<IRepair>();
                        
                        for (int i = 0; i < repairsData.Length - 1; i += 2)
                        {
                            string partName = repairsData[i];
                            int hoursWorked = int.Parse(repairsData[i + 1]);
                            repairs.Add(new Repair(partName, hoursWorked));
                        }
                        
                        soldiers.Add(new Engineer(id, firstName, lastName, salary, tokens[5], repairs));
                        break;
                    
                    case "Spy":
                        soldiers.Add(new Spy(id, firstName, lastName, int.Parse(tokens[4])));
                        break;
                }


            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}