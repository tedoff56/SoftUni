using System;
using System.Collections.Generic;
using System.Linq;

class Piece
{
    public string Name{ get; set; }
    
    public string Composer { get; set; }

    public string Key { get; set; }
    
}
namespace ThePianist_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string composer = tokens[1];
                string key = tokens[2];
                
                Piece piece = new Piece()
                {
                    Name = name,
                    Composer = composer,
                    Key = key
                };
                
                if (!pieces.ContainsKey(name))
                {
                    pieces.Add(name, piece);
                }

                pieces[name] = piece;
                
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Stop")
                {
                    break;
                }

                string[] tokens = line.Split("|", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string name = tokens[1];
                
                
                if (command == "Add")
                {
                    if (pieces.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} is already in the collection!");
                        continue;
                    }

                    string composer = tokens[2];
                    string key = tokens[3];
                    
                    Piece piece = new Piece()
                    {
                        Name = name,
                        Composer = composer,
                        Key = key
                    };
                    
                    pieces.Add(name, piece);

                    Console.WriteLine($"{name} by {composer} in {key} added to the collection!");
                }
                else if (command == "Remove")
                {
                    if (!pieces.ContainsKey(name))
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                        continue;
                    }

                    pieces.Remove(name);
                    Console.WriteLine($"Successfully removed {name}!");
                }
                else if (command == "ChangeKey")
                {
                    string newKey = tokens[2];
                    if (!pieces.ContainsKey(name))
                    {
                        Console.WriteLine($"Invalid operation! {name} does not exist in the collection.");
                        continue;
                    }

                    pieces[name].Key = newKey;
                    Console.WriteLine($"Changed the key of {name} to {newKey}!");
                }
            }

            Dictionary<string, Piece> result = pieces
                .OrderBy(p => p.Value.Name)
                .ThenBy(p => p.Value.Composer)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value.Composer}, Key: {kvp.Value.Key}");
            }

        }
    }
}