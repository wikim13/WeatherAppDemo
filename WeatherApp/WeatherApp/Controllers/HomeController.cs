using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using WeatherApp.Models;
using System.Configuration;
using WeatherApp.Interface;


namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        //Used : factory Pattern, so that I/O can be done from different file types in the future 
        IFactoryReader ReadtxtFile = new TextFileOperations();
        IFactoryWriter WritetxtFile = new TextFileOperations();
        //Used: Singleton File pattern for logging
        dynamic logger = Logger.GetInstance();

        [HttpGet]
        public ActionResult Index()
        {            
            try
            {               
                var cities = ReadtxtFile.ReadFile(ConfigurationManager.AppSettings["CityInputSource"]);
                logger.Log("process started!!");
                foreach (KeyValuePair<string, string> city in cities)
                {
                    WritetxtFile.WriteFile(JsonConvert.SerializeObject(GetWeather(city.Key)), GetFilePath(ConfigurationManager.AppSettings["CityOutputDest"].ToString(), city.Value));
                }
                logger.Log("process Completed!!");
                return Content("files creation completed!!");
            }
            catch (Exception e){
                logger.Error(e.Message);
            }
            return Content("***Error: Files Cannot be created.***");
        }
        /// <summary>
        /// returns the output file path, created so as to accomodate changes in folderstructure in the future.
        /// </summary>
        /// <param name="baseFolder"></param>
        /// <param name="nameParameter"></param>
        /// <returns>output file path</returns>
        public string GetFilePath(string baseFolder, string nameParameter)
        {          
            string FolderName = baseFolder + "\\" + DateTime.Now.ToString("dd-MMM-yyyy");
            string FileName = FolderName + "\\" + nameParameter + ".txt";
            bool exists = System.IO.Directory.Exists(FolderName);

            if (!exists)
                System.IO.Directory.CreateDirectory(FolderName);
            return FileName;
        }

        public ResponseWeather GetWeather(string cityID)
        {
            string apiKey = ConfigurationManager.AppSettings["APIKey"].ToString();
            HttpWebRequest apiRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?id=" + cityID + "&appid=" + apiKey + "&units=metric") as HttpWebRequest;

            string apiResponse = "";
            try
            {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                }

                ResponseWeather WeatherDetails = JsonConvert.DeserializeObject<ResponseWeather>(apiResponse);
                return WeatherDetails;
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return null;
        }
    }
}
