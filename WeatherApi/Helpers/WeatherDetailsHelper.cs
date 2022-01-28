using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace WeatherApi.Helpers
{
    public class WeatherDetailsHelper
    {
        //This three methods used for get five weathers.
        private static dynamic GetJsonFromApi(string city)
        {
            string path = "https://www.metaweather.com/api/location/" + city;
            var json = new WebClient().DownloadString(path);
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);

            return obj;
        }
        public static List<string> GetFiveTemptures(string city)
        {
            var obj = GetJsonFromApi(city);

            string tempture1 = obj["consolidated_weather"][0]["the_temp"].ToString();
            string tempture2 = obj["consolidated_weather"][1]["the_temp"].ToString();
            string tempture3 = obj["consolidated_weather"][2]["the_temp"].ToString();
            string tempture4 = obj["consolidated_weather"][3]["the_temp"].ToString();
            string tempture5 = obj["consolidated_weather"][4]["the_temp"].ToString();
            List<string> temptures = new List<string>() { tempture1, tempture2, tempture3, tempture4, tempture5, };
            return temptures;
        }
        public static List<string> GetFiveDates(string city)
        {
            var obj = GetJsonFromApi(city);

            string date1 = obj["consolidated_weather"][0]["applicable_date"].ToString();
            string date2 = obj["consolidated_weather"][1]["applicable_date"].ToString();
            string date3 = obj["consolidated_weather"][2]["applicable_date"].ToString();
            string date4 = obj["consolidated_weather"][3]["applicable_date"].ToString();
            string date5 = obj["consolidated_weather"][4]["applicable_date"].ToString();
            List<string> dates = new List<string>() { date1, date2, date3, date4, date5 };
            return dates;
        }

        //This three methods used for get a weathers specified for date.
        private static dynamic GetJsonFromApiWithDate(string city, DateTime dateTime)
        {
            string dateType = dateTime.Year.ToString() + "/" + dateTime.Month.ToString() + "/" + dateTime.Day.ToString();
            string pathWithDate = "https://www.metaweather.com/api/location/" + city + "/" + dateType;
            var json = new WebClient().DownloadString(pathWithDate);
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
            return obj;
        }
        public static string GetTempture(string city, DateTime dateTime)
        {
            var obj = GetJsonFromApiWithDate(city, dateTime);

            string oneTemp = obj[0]["the_temp"].ToString();
            return oneTemp;
        }
        public static string GetDate(string city, DateTime dateTime)
        {
            var obj = GetJsonFromApiWithDate(city, dateTime);

            string oneDate = obj[0]["applicable_date"].ToString();
            return oneDate;
        }

    }
}
