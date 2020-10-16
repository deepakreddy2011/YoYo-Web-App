using System;
using System.Collections.Generic;
using System.Linq;

namespace YoYo_Web_App.Core
{
    public class AthleteService : IAthleteService
    {
        private IAthleteRepository athleteRepository;

        public AthleteService(IAthleteRepository athleteRepository)
        {
            this.athleteRepository = athleteRepository;
        }

        public List<Athlete> GetAthletes()
        {
            var athletes = this.athleteRepository.GetAll();
            return athletes;
        }

        public List<FitnessRating> GetFitnessRatings()
        {
            var fitnessRatings = this.athleteRepository.GetFitnessRatings()
                                    .Select(x => new FitnessRating
                                    {
                                        AccumulatedShuttleDistance = x.AccumulatedShuttleDistance,
                                        ApproxVo2Max = x.ApproxVo2Max,
                                        CommulativeTime = (Convert.ToInt32(x.CommulativeTime.Split(':')[0]) * 60 + Convert.ToInt32(x.CommulativeTime.Split(':')[1])).ToString(),
                                        LevelTime = x.LevelTime,
                                        ShuttleNo = x.ShuttleNo,
                                        Speed = x.Speed,
                                        SpeedLevel = x.SpeedLevel,
                                        StartTime = (Convert.ToInt32(x.StartTime.Split(':')[0]) * 60 + Convert.ToInt32(x.StartTime.Split(':')[1])).ToString()
                                    })
                                     .OrderBy(x => Convert.ToInt32(x.SpeedLevel))
                                    .ThenBy(x => Convert.ToInt32(x.ShuttleNo))
                                    .ToList();
            return fitnessRatings;
        }

        public void UpdateState(List<AthleteState> athleteStates)
        {
            this.athleteRepository.UpdateState(athleteStates);
        }

        public List<AthleteState> GetAthleteStates()
        {
           return this.athleteRepository.GetAthleteStates();
        }
    }
}
