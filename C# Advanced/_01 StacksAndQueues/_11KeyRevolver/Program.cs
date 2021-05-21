using System;
using System.Collections.Generic;
using System.Linq;

namespace _11KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int intelligence = int.Parse(Console.ReadLine());

            int bulletsCount = 0;
            int totalBulletsShot = 0;
            
            while (locks.Count > 0)
            {
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }
                
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                
                bulletsCount++;
                totalBulletsShot++;
                
                if (bulletsCount == gunBarrelSize && bullets.Count > 0) 
                {
                    bulletsCount = 0;
                    Console.WriteLine("Reloading!");
                }
            }

            Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (totalBulletsShot * bulletPrice)}");

        }
    }
}