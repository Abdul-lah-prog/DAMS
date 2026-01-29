using DAMS.Client.Models;
using DAMS.Client.Services;
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace DAMS.Client.ViewModels
{
    public class WeatherStationViewModel : INotifyPropertyChanged
    {
        private readonly WeatherStationService _service;
        private readonly DispatcherTimer _timer;

        private WeatherStationData _data = new WeatherStationData();

        public float WindSpeed
        {
            get => MathF.Round(_data.WindSpeed, 2);
        }

        public float WindDirection
        {
            get => _data.WindDirection;
        }

        public float AirTemperature
        {
            get => MathF.Round(_data.AirTemperature,2);
        }

        public float AirHumidity
        {
            get => MathF.Round(_data.AirHumidity,2);
        }

        public float AirPressure
        {
            get => MathF.Round(_data.AirPressure,0);
        }

        public float Rainfall
        {
            get => MathF.Round(_data.Rainfall,2);
        }

        public float SolarRadiation
        {
            get => MathF.Round(_data.SolarRadiation,2);
        }

        public float UVRadiation
        {
            get => MathF.Round(_data.UVRadiation,2);
        }

        public DateTime Timestamp
        {
            get => _data.Timestamp;
        }

        public WeatherStationViewModel()
        {
            var modbus = new ModbusRtuService("COM11",9600,8, Parity.Even, StopBits.One);
            _service = new WeatherStationService(modbus);

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };

            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            try
            {
                _data = await Task.Run(() => _service.ReadAll());

                OnPropertyChanged(nameof(WindSpeed));
                OnPropertyChanged(nameof(WindDirection));
                OnPropertyChanged(nameof(AirTemperature));
                OnPropertyChanged(nameof(AirHumidity));
                OnPropertyChanged(nameof(AirPressure));
                OnPropertyChanged(nameof(Rainfall));
                OnPropertyChanged(nameof(SolarRadiation));
                OnPropertyChanged(nameof(UVRadiation));
                OnPropertyChanged(nameof(Timestamp));
            }
            catch (Exception ex)
            {
                // Later: log error / show status
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
