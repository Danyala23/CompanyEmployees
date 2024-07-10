using Contracts;
using Contracts_;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<string> Get()
        //{
        //    _repository.Company.
        //}
    }
}
