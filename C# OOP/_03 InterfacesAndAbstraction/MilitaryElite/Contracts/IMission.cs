using MilitaryElite.Enumerations;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        StateEnum State { get; }

        void CompleteMission();
    }
}