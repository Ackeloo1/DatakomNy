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
			// Generera och returnera några slumpmässiga väderprognoser här
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
			// Här kan du hantera logiken för att lägga till en ny väderprognos i systemet.
			// Exempelvis spara prognosen i en databas.

			// Om det går bra kan du returnera en bekräftelse eller ett resultat.
			return Ok("Väderprognos har lagts till");
		}
	}
}