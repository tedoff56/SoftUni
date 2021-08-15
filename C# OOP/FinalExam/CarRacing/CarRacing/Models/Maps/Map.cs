using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            
            if(!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            
            if (!racerOne.IsAvailable())
            {
                return string.Format(
                    OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            
            if(!racerTwo.IsAvailable())
            {
                return string.Format(
                    OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }


            string result;
            if (WinningChance(racerOne) > WinningChance(racerTwo))
            {
                result = string.Format(
                    OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                result =  string.Format(
                    OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
            
            racerOne.Race();
            racerTwo.Race();

            return result;
        }
        
        private double WinningChance(IRacer racer)
        {
            double racingBehaviorMultiplier = 0;
            
            if(racer.RacingBehavior == "strict")
            {
                racingBehaviorMultiplier = 1.2;
            }
            else if(racer.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplier = 1.1;
            }

            return racer.Car.HorsePower * racer.DrivingExperience * racingBehaviorMultiplier;
        }
    }
}