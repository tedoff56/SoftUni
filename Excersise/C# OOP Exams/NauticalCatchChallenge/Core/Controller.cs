using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System.Data;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> _divers;
        private IRepository<IFish> _fish;

        public Controller()
        {
            _divers = new DiverRepository();
            _fish = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            var diver = _divers.GetModel(diverName);
            var fish = _fish.GetModel(fishName);

            if (diver is null)
            {
                return string.Format(OutputMessages.DiverNotFound, _divers.GetType().Name, diverName);
            }

            if (fish is null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(fish);
                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);
                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            else
            {
                diver.Hit(fish);
                return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
            }

        }

        public string CompetitionStatistics()
        {
            var sortedDivers = _divers.Models
                .Where(d => !d.HasHealthIssues)
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name)
                .Select(d => d.ToString())
                .ToList();

            var sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in sortedDivers)
            {
                sb.AppendLine(diver);
            }

            return sb.ToString().Trim();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            var type = Type.GetType($"NauticalCatchChallenge.Models.{diverType}");

            if (type is null)
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (_divers.Models.Any(d => d.Name == diverName))
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, _divers.GetType().Name);
            }

            IDiver diver = new FreeDiver(diverName);

            if (diverType == "ScubaDiver")
            {
                diver = new ScubaDiver(diverName);
            }

            _divers.AddModel(diver);

            return string.Format(OutputMessages.DiverRegistered, diverName, _divers.GetType().Name);
        }

        public string DiverCatchReport(string diverName)
        {
            var diver = _divers.GetModel(diverName);

            var sb = new StringBuilder();

            sb.AppendLine($"Diver [ Name: {diver.Name}, Oxygen left: {diver.OxygenLevel}, Fish caught: {diver.Catch.Count}, Points earned: {diver.CompetitionPoints} ]");
            sb.AppendLine("Catch Report:");

            foreach (var fishName in diver.Catch)
            {
                var fish = _fish.GetModel(fishName);

                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            int cnt = 0;

            foreach (var diver in _divers.Models.Where(d => d.HasHealthIssues))
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
                cnt++;
            }

            return string.Format(OutputMessages.DiversRecovered, cnt);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {

            var type = Type.GetType($"NauticalCatchChallenge.Models.{fishType}");

            if (type is null)
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (_fish.Models.Any(f => f.Name == fishName))
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, _fish.GetType().Name);
            }

            IFish createdFish = new PredatoryFish(fishName, points);

            if (fishType == "DeepSeaFish")
            {
                createdFish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == "ReefFish")
            {
                createdFish = new ReefFish(fishName, points);
            }

            _fish.AddModel(createdFish);

            return string.Format(OutputMessages.FishCreated, fishName);
        }
    }
}
