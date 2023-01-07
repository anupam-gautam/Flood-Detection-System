using Flood_Detection_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace Flood_Detection_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WeatherDataController : ControllerBase
    {

        [HttpPost]
        [Route("WeatherApi")]
        public object WeatherApi(WeatherApiInputOutputModel weatherApiInputModel)
        {
            weatherApiInputModel.lat = 28.3949;
            weatherApiInputModel.lon = 84.1240;
            string aqi = weatherApiInputModel.airQualityIndex ? "yes" : "no";
            string alerts = weatherApiInputModel.airQualityIndex ? "yes" : "no";
            string apiUrl = "https://api.weatherapi.com/v1/forecast.json?key=068bfabb64a443f592b152849222712&q=" + weatherApiInputModel.lat + "," + weatherApiInputModel.lon + "&days=" + weatherApiInputModel.forecastDays + "&aqi=" + aqi + "&alerts=" + alerts;
            RestClient client = new RestClient(apiUrl);
            var request = new RestRequest(apiUrl);
            request.RequestFormat = DataFormat.Json;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var response = client.Execute(request);
            var res = JsonSerializer.Deserialize<WeatherOutput>(response.Content);
            return response.Content;
        }
   
    }
}
