using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WeatherApp.Interface;

namespace WeatherApp.Models
{
    public class TextFileOperations : IFactoryReader,IFactoryWriter
    {
        public Dictionary<string, string> ReadFile(string filePath)
        {
            Dictionary<string, string> citydetails = new Dictionary<string, string>();
            using (StreamReader file = new StreamReader(filePath))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    if (line != "")
                        citydetails.Add(line.Split('=')[0], line.Split('=')[1]);
                }
                file.Close();
            }
            return citydetails;
        }

        public bool WriteFile(string Content, string filePath)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine(Content);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}