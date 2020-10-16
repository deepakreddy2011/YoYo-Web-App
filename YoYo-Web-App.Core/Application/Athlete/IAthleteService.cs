using System;
using System.Collections.Generic;
using System.Text;

namespace YoYo_Web_App.Core
{
    public interface IAthleteService
    {
        List<Athlete> GetAthletes();
        List<FitnessRating> GetFitnessRatings();
        void UpdateState(List<AthleteState> athleteStates);
        List<AthleteState> GetAthleteStates();
    }
}
