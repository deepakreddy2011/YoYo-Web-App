using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YoYo_Web_App.Core;

namespace YoYo_Web_App.Controllers
{
    public class BeepTestController : Controller
    {
        private readonly IAthleteService athleteService;

        public BeepTestController(IAthleteService athleteService)
        {
            this.athleteService = athleteService;
        }

        public IActionResult BeepTestView()
        {
            return View();
        }

        [Route("api/BeepTest/GetAthletes")]
        [HttpGet]
        public List<Athlete> GetAthletes()
        {
            var athletes = this.athleteService.GetAthletes();
            return athletes;
        }

        [Route("api/BeepTest/GetFitnessRatings")]
        [HttpGet]
        public List<FitnessRating> GetFitnessRatings()
        {
            var fitnessRatings = this.athleteService.GetFitnessRatings();
            return fitnessRatings;
        }
    }
}
