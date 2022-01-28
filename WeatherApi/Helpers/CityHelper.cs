using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WeatherApi.Helpers
{
    public class CityHelper
    {
        //This method still need 'woeid' for get a city name...
        public static string GetCityNameFromApi(string city)
        {

            string path = "https://www.metaweather.com/api/location/" + city;
            var json = new WebClient().DownloadString(path);
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);

            string location = obj["title"].ToString();
            return location;
        }

        //This two methods works local, not connected with api.
        public static string GetCityName(string city)
        {
            var cities = GetCities();

            foreach (var a in cities)
            {
                if (a.Key == city)
                {
                    return a.Value;
                }
            }
            return "Unknown";
        }


        private static Dictionary<string, string> GetCities()
        {
            Dictionary<string, string> cities = new Dictionary<string, string>();
            cities.Add("2344116", "İstanbul");
            cities.Add("2344117", "İzmir");
            cities.Add("2343732", "Ankara");
            cities.Add("44418", "Londra");
            cities.Add("721943", "Roma");
            cities.Add("676757", "Münih");
            cities.Add("614274", "Monako");
            cities.Add("753692", "Barselona");

            return cities;
        }



    }
}
