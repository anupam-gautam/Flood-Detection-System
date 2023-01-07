using Flood_Detection_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flood_Detection_System.IService;
using Flood_Detection_System.Service;

namespace Flood_Detection_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("ValidateUser")]
        public ActionResult ValidateUser(string email, string password)
        {
            if(email == "anupam@gmail.com" || email == "roshan@gmail.com" || email == "bhawishya@gmail.com")
            {
                WeatherApiInputOutputModel weatherApiInputOutputModel = new WeatherApiInputOutputModel();
                weatherApiInputOutputModel.airQualityIndex = true;
                weatherApiInputOutputModel.lat = 65;
                weatherApiInputOutputModel.lon = 48;
                weatherApiInputOutputModel.alert = true;
                weatherApiInputOutputModel.forecastDays = 1;
                var res = LoginPreview.PreviewPage(weatherApiInputOutputModel);
                return Ok(res);
            }
           
            return BadRequest();
        }

        [HttpPost]
        public ActionResult AddUser(int name)
        {
            //_context.TblUserDetails.Add(userDetail);
            //_context.SaveChanges();
            //return Ok(_context.TblUserDetails.ToList());
            return Ok();
        }

    }
}
