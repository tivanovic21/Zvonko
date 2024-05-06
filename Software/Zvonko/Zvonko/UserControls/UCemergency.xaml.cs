using BusinessLogicLayer;
using DatabaseLayer;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zvonko.UserControls
{
    /// <summary>
    /// Interaction logic for UCemergency.xaml
    /// </summary>
    public partial class UCemergency : UserControl
    {
        private WaveOutEvent _waveOut;
        private WaveFileReader _waveFileReader;
        private Mp3FileReader _mp3FileReader;
        public UCemergency()
        {
            InitializeComponent();
            FillComboBox();

            var audioDevices = GetAudioDevices();
        }

        public static List<(string name, int deviceNumber)> GetAudioDevices()
        {
            var audioDevices = new List<(string name, int deviceNumber)>();

            for (int deviceNumber = 0; deviceNumber < WaveOut.DeviceCount; deviceNumber++)
            {
                var deviceName = WaveOut.GetCapabilities(deviceNumber).ProductName;
                audioDevices.Add((deviceName, deviceNumber));
            }

            return audioDevices;
        }


        private void FillComboBox()
        {
            RecordingService recordingService = new RecordingService();
            var emergencySounds = recordingService.GetEmergencyRecordings();

            if (emergencySounds != null && emergencySounds.Any())
            {
                cbEmergency.ItemsSource = emergencySounds;
                cbEmergency.DisplayMemberPath = "name";
                cbEmergency.SelectedItem = emergencySounds.FirstOrDefault();
            } else
            {
                MessageBox.Show("Please add emergency sounds.");
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            var selectedSound = cbEmergency.SelectedItem as Recording;
            if (selectedSound != null)
            {
                PlayRecording(selectedSound);
            } else
            {
                MessageBox.Show("Please select a sound.");
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            StopSound();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null && parentWindow is MainWindow)
            {
                MainWindow mainWindow = (MainWindow)parentWindow;
                mainWindow.LoadMainContent();
            }
        }

        private void PlayRecording(Recording recording)
        {
            try
            {
                if (recording.name.EndsWith(".wav"))
                {
                    using (MemoryStream ms = new MemoryStream(recording.storedFile))
                    {
                        _waveFileReader = new WaveFileReader(ms);
                        _waveOut = new WaveOutEvent();
                        _waveOut.Init(_waveFileReader);
                        _waveOut.Play();
                    }
                } else if (recording.name.EndsWith(".mp3"))
                {
                    using (MemoryStream ms = new MemoryStream(recording.storedFile))
                    {
                        _mp3FileReader = new Mp3FileReader(ms);
                        _waveOut = new WaveOutEvent();
                        _waveOut.Init(_mp3FileReader);
                        _waveOut.Play();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error playing recording: " + ex.Message);
            }
        }


        private void StopSound()
        {
            try
            {
                if (_waveOut != null && _waveOut.PlaybackState == PlaybackState.Playing)
                {
                    _waveOut.Stop();
                    _waveOut.Dispose(); 
                    _waveOut = null; 
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error stopping recording: " + ex.Message);
            }
        }
    }
}
