using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureProject.Database.Model
{
    public class OriginDataModel
    {
        public int ID { get; set; }
        public string Data { get; set; }
        public string Czujnik1 { get; set; }
        public string Czujnik2 { get; set; }
        public string Czujnik3 { get; set; }

    }
}
