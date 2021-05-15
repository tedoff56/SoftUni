using System;

namespace Bonus_Scoring_System_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalStudents = int.Parse(Console.ReadLine());
            int lecturesInTheCourse = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());
            
            decimal maxBonusPoints = 0;
            int bestStudentAttendances = int.MinValue;
            
            if (totalStudents > 0 && totalStudents <= 50 
            && lecturesInTheCourse > 0 && lecturesInTheCourse <= 50
            && initialBonus >= 0 && initialBonus <= 100)
            {

                for (int i = 0; i < totalStudents; i++)
                {
                    int studentAttendances = int.Parse(Console.ReadLine());
                    decimal totalBonus = (decimal)studentAttendances / lecturesInTheCourse * (5 + initialBonus);
                    if (studentAttendances > bestStudentAttendances)
                    {
                        maxBonusPoints = totalBonus;
                        bestStudentAttendances = studentAttendances;
                    }
                }
                
                Console.WriteLine($"Max Bonus: {Math.Round(maxBonusPoints, MidpointRounding.ToPositiveInfinity):F0}.");
                Console.WriteLine($"The student has attended {bestStudentAttendances} lectures.");

            }
        }
    }
}