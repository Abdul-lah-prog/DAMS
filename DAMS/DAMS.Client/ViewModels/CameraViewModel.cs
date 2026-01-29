using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace CameraWpfApp.ViewModels
{
    public class CameraViewModel : INotifyPropertyChanged
    {
        private VideoCapture _capture;
        private DispatcherTimer _timer;

        private BitmapSource? _cameraFrame;
        public BitmapSource? CameraFrame
        {
            get => _cameraFrame;
            set
            {
                _cameraFrame = value;
                OnPropertyChanged();
            }
        }

        public CameraViewModel()
        {
            string ipCameraUrl = "rtsp://admin:123456@192.168.160.108:554/stream1";

            // Initialize camera capture
            _capture = new VideoCapture(ipCameraUrl);

            // Timer to update camera frames
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(30)
            };
            _timer.Tick += CaptureFrame;
            _timer.Start();
        }

        private void CaptureFrame(object? sender, EventArgs e)
        {
            if (_capture == null || !_capture.IsOpened())
                return;

            using var frame = new Mat();
            _capture.Read(frame);

            if (!frame.Empty())
            {
                CameraFrame = frame.ToBitmapSource();
            }
        }


        // Property changed event for binding
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
