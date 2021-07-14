using System;
using System.Collections.Generic;
using System.Linq;

using MilitaryElite.Contracts;
using MilitaryElite.Exceptions;
using MilitaryElite.Models;

namespace MilitaryElite
{
    class StartUp
    {
        static void Main(string[] args)
        {

            List<ISoldier> soldiers = new List<ISoldier>();
            
            while (true)
            {
                string[] soldierData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (soldierData[0] == "End")
                {
                    break;
                }
                
                string division = soldierData[0];
                string id = soldierData[1];
                string firstName = soldierData[2];
                string lastName = soldierData[3];
                decimal salary = decimal.Parse(soldierData[4]);
                

                ISoldier soldier = null;
                if (division == "Private")
                {
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (division == "LieutenantGeneral")
                {
                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                    string[] privatesIds = soldierData.Skip(5).ToArray();

                    foreach (var privateId in privatesIds)
                    {
                        lieutenantGeneral.AddPrivate(soldiers.Find(s => s.Id == privateId));
                    }

                    soldier = lieutenantGeneral;
                }
                else if (division == "Engineer")
                {
                    string corps = soldierData[5];

                    IEngineer engineer;
                    try
                    {
                        engineer = new Engineer(id, firstName, lastName, salary, corps);
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }

                    string[] repairsData = soldierData.Skip(6).ToArray();
                    for (int i = 0; i < repairsData.Length - 1; i += 2)
                    {
                        string partName = repairsData[i];
                        int hoursWorked = int.Parse(repairsData[i + 1]);

                        engineer.AddRepair(new Repair(partName, hoursWorked));
                    }

                    soldier = engineer;
                }
                else if (division == "Commando")
                {
                    string corps = soldierData[5];

                    ICommando commando;
                    try
                    {
                        commando = new Commando(id, firstName, lastName, salary, corps);
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }

                    string[] missionsData = soldierData.Skip(6).ToArray();
                    for (int i = 0; i < missionsData.Length - 1; i++)
                    {
                        string codeName = missionsData[i];
                        string state = missionsData[i + 1];

                        IMission mission;
                        try
                        {
                            mission = new Mission(codeName, state);
                        }
                        catch (InvalidStateException ise)
                        {
                            continue;
                        }

                        commando.AddMission(mission);
                    }

                    soldier = commando;
                }
                else if (division == "Spy")
                {
                    int codeNumber = int.Parse(soldierData[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                soldiers.Add(soldier);
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}