using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TempSignalRServer.Models;

namespace TempSignalRServer.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{
			// Generera och returnera n�gra slumpm�ssiga v�derprognoser h�r
			var rng = new Random();
			var forecasts = new List<WeatherForecast>();
			for (var i = 1; i <= 5; i++)
			{
				var forecast = new WeatherForecast
				{
					Date = DateTime.Now.AddDays(i),
					TemperatureC = rng.Next(-20, 55),
					Summary = "Sunny",
				};
				forecasts.Add(forecast);
			}
			return forecasts;
		}

		[HttpPost(Name = "AddWeatherForecast")]
		public IActionResult Post(WeatherForecast forecast)
		{
			// H�r kan du hantera logiken f�r att l�gga till en ny v�derprognos i systemet.
			// Exempelvis spara prognosen i en databas.

			// Om det g�r bra kan du returnera en bekr�ftelse eller ett resultat.
			return Ok("V�derprognos har lagts till");
		}
	}
}