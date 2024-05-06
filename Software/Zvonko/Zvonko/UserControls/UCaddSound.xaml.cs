using BusinessLogicLayer;
using DatabaseLayer;
using Microsoft.Win32;
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
    /// Interaction logic for UCaddSound.xaml
    /// </summary>
    public partial class UCaddSound : UserControl
    {
        RecordingService recordingService = new RecordingService();
        private byte[] _storedFile;
        public UCaddSound()
        {
            InitializeComponent();
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

        private void btnChooseSound_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Audio files (*.mp3, *.wav)|*.mp3;*.wav";
            openFileDialog.FilterIndex = 1;

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = openFileDialog.FileName;

                if (IsAudioFile(filePath))
                {
                    LoadData(filePath);
                } else
                {
                    MessageBox.Show("Please select an audio file.");
                }
            }
        }

        private bool IsAudioFile(string filePath)
        {
            string extension = System.IO.Path.GetExtension(filePath);
            return extension.Equals(".mp3", StringComparison.OrdinalIgnoreCase) ||
                   extension.Equals(".wav", StringComparison.OrdinalIgnoreCase);
        }

        private void LoadData(string filePath)
        {
            txtSoundName.Text = System.IO.Path.GetFileName(filePath);

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                _storedFile = new byte[fs.Length];
                fs.Read(_storedFile, 0, _storedFile.Length);
            }

            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaOpened += (sender, e) =>
            {
                if (mediaPlayer.NaturalDuration.HasTimeSpan)
                {
                    TimeSpan duration = mediaPlayer.NaturalDuration.TimeSpan;
                    txtSoundLength.Text = duration.ToString(@"hh\:mm\:ss");
                }
            };

            mediaPlayer.MediaFailed += (sender, e) =>
            {
                MessageBox.Show("Failed to open media file.");
                mediaPlayer.Close();
            };

            mediaPlayer.MediaEnded += (sender, e) =>
            {
                mediaPlayer.Close();
            };

            try
            {
                mediaPlayer.Open(new Uri(filePath));
            } catch (Exception ex)
            {
                MessageBox.Show("Error opening media file: " + ex.Message);
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string soundName = txtSoundName.Text;
            string soundDuration = txtSoundLength.Text;
            string description = System.IO.Path.GetExtension(soundName);
            var loggedUser = ((MainWindow)Window.GetWindow(this)).LoggedUser;

            Recording newRecording = new Recording
            {
                name = soundName,
                duration = TimeSpan.Parse(soundDuration),
                description = description,
                timeCreated = DateTime.Now.ToString(),
                storedFile = "dwadaw"/*_storedFile*/,
                Account = loggedUser
            };

            bool isAdded = recordingService.AddRecording(newRecording);
            if (isAdded)
            {
                MessageBox.Show("Sound successfully added!");
            } else
            {
                MessageBox.Show("Error while adding sound. Please try again.");
            }
        }
    }
}
