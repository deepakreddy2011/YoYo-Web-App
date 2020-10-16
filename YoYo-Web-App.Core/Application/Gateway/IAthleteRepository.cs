using System.Collections.Generic;

namespace YoYo_Web_App.Core
{
    public interface IAthleteRepository
    {
        List<Athlete> GetAll();
        List<FitnessRating> GetFitnessRatings();
        void UpdateState(List<AthleteState> athleteStates);
        List<AthleteState> GetAthleteStates();
    }
}
