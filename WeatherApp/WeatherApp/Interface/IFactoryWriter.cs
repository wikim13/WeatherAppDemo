﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Interface
{
    interface IFactoryWriter
    {
        bool WriteFile(string Content, string filePath);
    }
}
