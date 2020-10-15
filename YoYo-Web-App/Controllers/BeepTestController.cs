using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text.Json;
using YoYo_Web_App.Models;
using System.Linq;

namespace YoYo_Web_App.Controllers
{
    public class BeepTestController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;

        public BeepTestController(IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }

        public IActionResult BeepTestView()
        {
            return View();
        }

        [HttpGet]
        public List<FitnessRating> GetFitnessRatings()
        {
            var webRootPath = this.hostingEnvironment.WebRootPath;
            var filePath = this.configuration.GetSection("BeepTestFilePath").Value;
            var data = System.IO.File.ReadAllText(System.IO.Path.Combine(webRootPath, filePath));
            var fitnessRatings = JsonSerializer.Deserialize<List<FitnessRating>>(data)
                                    .OrderBy(x => x.SpeedLevel)
                                    .ThenBy(x => x.ShuttleNo)
                                    .ToList();
            return fitnessRatings;
        }
    }
}
