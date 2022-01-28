using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Helpers;

namespace WeatherApi.Controllers
{
    public class WeatherController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string city, DateTime dateTime)
        {

            if (dateTime.Year < 2000 && dateTime.Year != 1 || city == null)
            {
                if (city == null)
                {
                    ViewBag.Error = "Şehir boş olamaz.";
                }
                else
                {
                    ViewBag.Error = "Yıl 2000'den küçük olamaz.";
                }

                return View();
            }

            //Query for a specific date.
            else if (dateTime.Year > 2000)
            {
                ViewBag.Temp = WeatherDetailsHelper.GetTempture(city, dateTime).Substring(0, 3);
                ViewBag.Date = WeatherDetailsHelper.GetDate(city, dateTime);
                ViewBag.City = CityHelper.GetCityName(city);
                return View();

            }

            //Weather query without any spesific date for the selected city.
            else
            {
                ViewBag.City = CityHelper.GetCityNameFromApi(city);
                ViewBag.Temps = WeatherDetailsHelper.GetFiveTemptures(city);
                ViewBag.Dates = WeatherDetailsHelper.GetFiveDates(city);
                ViewBag.Count = WeatherDetailsHelper.GetFiveTemptures(city).Count();

                return View();
            }

        }
    }
}
