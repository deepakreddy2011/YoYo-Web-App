using System;
using System.Collections.Generic;
using System.Text;

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
            var fitnessRatings = this.athleteRepository.GetFitnessRatings();
            return fitnessRatings;
        }
    }
}
