using System.Text;

using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Code Number: {CodeNumber}");
            
            return sb.ToString().TrimEnd();
        }
    }
}