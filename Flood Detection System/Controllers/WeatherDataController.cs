using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;

namespace Flood_Detection_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WeatherDataController : ControllerBase
    {
        [HttpGet("Dummy")]
        public object OpenWeather()
        {

            //string apiUrl = "http://api.openweathermap.org/data/2.5/forecast?id=524901&appid=55c4e47fe289c1dda9c9a7acfba40ce5";
            string apiUrl = "https://api.openweathermap.org/data/2.5/weather?lat=3.4653&lon=62.2159&appid=55c4e47fe289c1dda9c9a7acfba40ce5";
            //string apiUrl = "http://api.openweathermap.org/data/2.5/forecast?id=541414&appid=55c4e47fe289c1dda9c9a7acfba40ce5";


            RestClient client = new RestClient(apiUrl);
            //var request = new RestRequest(action, method);
            var request = new RestRequest(apiUrl);
            request.RequestFormat = DataFormat.Json;

            //request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var response = client.Execute(request);
            return response.Content;
        }

        [HttpGet]
        public object WeatherApi()
        {

            string apiUrl = "https://api.weatherapi.com/v1/forecast.json?key=068bfabb64a443f592b152849222712&q=48.8567,2.3508&days=1&aqi=no&alerts=yes";
            RestClient client = new RestClient(apiUrl);
            var request = new RestRequest(apiUrl);
            request.RequestFormat = DataFormat.Json;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var response = client.Execute(request);
            return response.Content;
        }
        //public string GetWeatherData()
        //{
        //    object response = new object();
        //    response = APIHeko

        //    return Ok(response);

        //}
    }
}
