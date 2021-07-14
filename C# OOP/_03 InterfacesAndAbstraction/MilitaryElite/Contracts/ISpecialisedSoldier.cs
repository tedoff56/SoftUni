using MilitaryElite.Enumerations;

namespace MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        CorpsEnum Corps { get; }
    }
}