using BusinessLogicLayer;
using DatabaseLayer;
using DatabaseLayer.Repositories;
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
using Path = System.IO.Path;

namespace Zvonko.UserControls
{
    /// <summary>
    /// Interaction logic for UCemergency.xaml
    /// </summary>
    public partial class UCemergency : UserControl
    {
        private WaveOutEvent _waveOut;
        public UCemergency()
        {
            InitializeComponent();
            FillComboBox();
        }


        private void FillComboBox()
        {
            RecordingRepository recRepository = new RecordingRepository();
            RecordingService recordingService = new RecordingService(recRepository);
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
                MessageBoxResult result = MessageBox.Show("Are you sure you want to play an emergency sound?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    PlayRecording(selectedSound);
                }
            } else
            {
                MessageBox.Show("Please select a sound.");
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            StopRecording();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (_waveOut != null)
            {
                StopRecording();
            }
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null && parentWindow is MainWindow)
            {
                MainWindow mainWindow = (MainWindow)parentWindow;
                mainWindow.LoadMainContent();
            }
        }

        private void PlayRecording(Recording recording)
        {
            if(_waveOut != null)
            {
                StopRecording();//A
            }

            if (File.Exists(recording.storedFile))
            {
                _waveOut = new WaveOutEvent();
                var audioFileReader = new AudioFileReader(recording.storedFile);
                _waveOut.Init(audioFileReader);
                _waveOut.Play();
                playingIndicator.Text = "Playing"; // for testing 
            } else
            {
                playingIndicator.Text = ""; // for testing 
                //MessageBox.Show("File not found!");
            }
        }


        private void StopRecording()
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
