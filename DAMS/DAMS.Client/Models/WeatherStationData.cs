using System;
using System.Collections.Generic;
using System.Text;

namespace DAMS.Client.Models
{
    public class WeatherStationData
    {
        public float WindSpeed { get; set; }
        public float WindDirection { get; set; }

        public float AirTemperature { get; set; }
        public float AirHumidity { get; set; }
        public float AirPressure { get; set; }

        public float Rainfall { get; set; }
        public float SolarRadiation { get; set; }
        public float UVRadiation { get; set; }

        public DateTime Timestamp { get; set; }
    }
}

