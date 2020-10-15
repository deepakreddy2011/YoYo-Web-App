using System.Collections.Generic;
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
            var data = System.IO.File.ReadAllText(this.configurationSettings.AthletesFilePath);
            var athletes = JsonSerializer.Deserialize<List<Athlete>>(data)
                                   .OrderBy(x => x.Name)
                                   .ToList();
            return athletes;
        }

        public List<FitnessRating> GetFitnessRatings()
        {
            var data = System.IO.File.ReadAllText(this.configurationSettings.BeepTestFilePath);
            var fitnessRatings = JsonSerializer.Deserialize<List<FitnessRating>>(data)
                                   .OrderBy(x => x.SpeedLevel)
                                    .ThenBy(x => x.ShuttleNo)
                                   .ToList();
            return fitnessRatings;
        }
    }
}
