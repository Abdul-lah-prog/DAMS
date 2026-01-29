using System;
using System.Collections.Generic;
using System.Text;

namespace DAMS.Client.ViewModels
{
    public class MainDashboardViewModel
    {
        public WeatherStationViewModel Weather { get; set; }
      //  public PowerMeterViewModel Power { get; set; }
      //  public DataRecorderViewModel Recorder { get; set; }
      //  public CameraViewModel Cameras { get; set; }

        public MainDashboardViewModel()
        {
            Weather = new WeatherStationViewModel();
          //  Power = new PowerMeterViewModel();
          //  Recorder = new DataRecorderViewModel();
          //  Cameras = new CameraViewModel();
        }
    }

}
