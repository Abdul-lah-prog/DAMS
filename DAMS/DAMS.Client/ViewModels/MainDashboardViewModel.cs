using CameraWpfApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Media3D;

namespace DAMS.Client.ViewModels
{
    public class MainDashboardViewModel
    {
        public WeatherStationViewModel Weather { get; set; }
        
        //  public PowerMeterViewModel Power { get; set; }
        //  public DataRecorderViewModel Recorder { get; set; }
          public CameraViewModel Camera { get; }

        public MainDashboardViewModel()
        {
            Weather = new WeatherStationViewModel();
            //  Power = new PowerMeterViewModel();
            //  Recorder = new DataRecorderViewModel();
                Camera = new CameraViewModel();
        }
    }

}
