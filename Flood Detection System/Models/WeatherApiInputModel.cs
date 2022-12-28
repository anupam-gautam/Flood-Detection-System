namespace Flood_Detection_System.Models
{
    public class WeatherApiInputOutputModel
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public int forecastDays { get; set; }
        public bool airQualityIndex { get; set; }
        public bool alert { get; set; }
    }

    public class WeatherOutput
    {
        public WeatherLocation location { get; set; }
        public WeatherForecast forecast { get; set; }
    }

    public class WeatherLocation
    {
        public string name { get; set; }
        public string region { get; set; }
        public string localtime { get; set; }
    }

    public class WeatherForecast
    {
        public List<ForecastDay> forecastday { get; set; }
    }

    public class ForecastDay
    {
        public Day day { get; set; }
    }

    public class Day
    {
        public float maxtemp_c { get; set; }
        public float mintemp_c { get; set; }
        public float totalprecip_mm { get; set; }
    }
}


