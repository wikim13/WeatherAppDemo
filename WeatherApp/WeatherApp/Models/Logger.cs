using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using WeatherApp.Interface;

namespace WeatherApp.Models
{
    public class Logger
    {
        //Our single instance of the singleton
        private static Logger instance = null;
        private static string FileName = ConfigurationManager.AppSettings["Loglocation"].ToString();
        //Private constructor to deny instance creation of this class from outside
        private Logger() { }

        //GetInstace method to be used to create or reach the single resource (instance)
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        //Implement functionality as public instance methods
        public void Log(string message)
        {
            StreamWriter mLogFile = new StreamWriter(FileName);
            mLogFile.WriteLine($"[{DateTime.Now}]: {message }", true);
            mLogFile.Close();
        }
        public void Error(string message)
        {
            StreamWriter mLogFile = new StreamWriter(FileName);
            mLogFile.WriteLine($"Error: [{DateTime.Now}]: {message }", true);
            mLogFile.Close();
        }
    }
}
