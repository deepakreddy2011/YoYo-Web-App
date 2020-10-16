using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using YoYo_Web_App.Core;
using YoYo_Web_App.Utility;

namespace YoYo_Web_App.Infrastructre
{
    public class StubAthleteRepository : IAthleteRepository
    {
        private IConfigurationSettings configurationSettings;

        public StubAthleteRepository(IConfigurationSettings configurationSettings)
        {
            this.configurationSettings = configurationSettings;
        }

        public List<Athlete> GetAll()
        {
            var data = File.ReadAllText(this.configurationSettings.AthletesFilePath);
            var athletes = JsonSerializer.Deserialize<List<Athlete>>(data)
                                   .OrderBy(x => x.Name)
                                   .ToList();
            return athletes;
        }

        public List<FitnessRating> GetFitnessRatings()
        {
            var data = File.ReadAllText(this.configurationSettings.BeepTestFilePath);
            var fitnessRatings = JsonSerializer.Deserialize<List<FitnessRating>>(data)
                                   .ToList();
            return fitnessRatings;
        }

        public void UpdateState(List<AthleteState> athleteStates)
        {
            var data = JsonSerializer.Serialize(athleteStates);
            if (!File.Exists(this.configurationSettings.AthleteStatePath))
            {
                File.Create(this.configurationSettings.AthleteStatePath).Dispose();
            }
            File.WriteAllText(this.configurationSettings.AthleteStatePath, data);

        }

        public List<AthleteState> GetAthleteStates()
        {
            var data = File.ReadAllText(this.configurationSettings.AthleteStatePath);
            var athleteStates = JsonSerializer.Deserialize<List<AthleteState>>(data)
                                   .OrderBy(x => x.Id)
                                   .ToList();
            return athleteStates;
        }
    }
}
