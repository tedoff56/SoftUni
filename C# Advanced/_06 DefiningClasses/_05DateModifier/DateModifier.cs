using System;
using System.Linq;

namespace _05DateModifier
{
    public class DateModifier
    {
        public static int GetDifference(string date1, string date2)
        {
            int[] date1Tokens = date1.Split().Select(int.Parse).ToArray();
            int[] date2Tokens = date2.Split().Select(int.Parse).ToArray();

            DateTime dt1 = new DateTime(date1Tokens[0], date1Tokens[1], date1Tokens[2]);
            DateTime dt2 = new DateTime(date2Tokens[0], date2Tokens[1], date2Tokens[2]);

            return (int)Math.Abs((dt1 - dt2).TotalDays);
        }
        
    }
}