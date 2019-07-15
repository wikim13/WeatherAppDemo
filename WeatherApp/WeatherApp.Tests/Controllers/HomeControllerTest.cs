using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApp;
using WeatherApp.Controllers;
using System.Configuration;
using System;
using WeatherApp.Models;

namespace WeatherApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void GetWeather()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            WeatherApp.Models.ResponseWeather result = controller.GetWeather("292223");

            // Assert
            Assert.IsNotNull(result);            
        }

        [TestMethod]
        public void GetFilePath()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            string result = controller.GetFilePath(ConfigurationManager.AppSettings["CityOutputDest"].ToString(),"Berlin");

            // Assert
            Assert.IsNotNull(result);
            string path = ConfigurationManager.AppSettings["CityOutputDest"].ToString() + "\\" + DateTime.Now.ToString("dd-MMM-yyyy") + "\\Berlin.txt";
            Assert.AreEqual(result, path);
        }

        [TestMethod]
        public void TestWrite()
        {
            // Arrange
            TextFileOperations operations = new TextFileOperations();
            string path = ConfigurationManager.AppSettings["CityOutputDest"].ToString() + "\\" + DateTime.Now.ToString("dd-MMM-yyyy") + "\\Berlin.txt";

            // Act
            bool result = operations.WriteFile("test text",path);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, true);
        }
    }
}
