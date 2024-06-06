using BusinessLogicLayer;
using DatabaseLayer;
using Microsoft.Win32;
using System;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Zvonko.UserControls {
    /// <summary>
    /// Interaction logic for UCaddSound.xaml
    /// </summary>
    public partial class UCaddSound : UserControl {
        private readonly RecordingService recordingService = new RecordingService();
        private byte[] _storedFile;
        private MediaPlayer mediaPlayer;

        public UCaddSound() {
            InitializeComponent();
            mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
            mediaPlayer.MediaFailed += MediaPlayer_MediaFailed;
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null && parentWindow is MainWindow) {
                MainWindow mainWindow = (MainWindow)parentWindow;
                mainWindow.LoadMainContent();
            }
        }

        private void btnChooseSound_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Audio files (*.mp3, *.wav)|*.mp3;*.wav",
                FilterIndex = 1
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true) {
                string filePath = openFileDialog.FileName;

                if (IsAudioFile(filePath)) {
                    LoadData(filePath);
                } else {
                    MessageBox.Show("Please select an audio file.");
                }
            }
        }

        private bool IsAudioFile(string filePath) {
            string extension = Path.GetExtension(filePath);
            return extension.Equals(".mp3", StringComparison.OrdinalIgnoreCase) ||
                   extension.Equals(".wav", StringComparison.OrdinalIgnoreCase);
        }

        private void LoadData(string filePath) {
            txtSoundName.Text = Path.GetFileName(filePath);

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
                _storedFile = new byte[fs.Length];
                fs.Read(_storedFile, 0, _storedFile.Length);
            }

            try {
                mediaPlayer.Open(new Uri(filePath));
            } catch (Exception ex) {
                MessageBox.Show("Error opening media file: " + ex.Message);
            }
        }

        private void MediaPlayer_MediaOpened(object sender, EventArgs e) {
            if (mediaPlayer.NaturalDuration.HasTimeSpan) {
                TimeSpan duration = mediaPlayer.NaturalDuration.TimeSpan;
                txtSoundLength.Text = duration.ToString(@"hh\:mm\:ss");
            }
        }

        private void MediaPlayer_MediaFailed(object sender, ExceptionEventArgs e) {
            MessageBox.Show("Failed to open media file.");
            mediaPlayer.Close();
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e) {
            mediaPlayer.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            var loggedUser = ((MainWindow)Window.GetWindow(this)).LoggedUser;
            string soundName = txtSoundName.Text;
            string soundDuration = txtSoundLength.Text;
            string eventType = (radioYes.IsChecked == true) ? "emergency" : "audio";

            string assetsDir = "assets";
            if (!Directory.Exists(assetsDir)) {
                Directory.CreateDirectory(assetsDir);
            }

            string soundsDir = Path.Combine(assetsDir, "sounds");
            if (!Directory.Exists(soundsDir)) {
                Directory.CreateDirectory(soundsDir);
            }

            string fileName = Path.GetFileNameWithoutExtension(soundName);
            if (!fileName.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase)) {
                fileName += ".mp3";
            }

            string filePath = Path.Combine(soundsDir, fileName);

            try {
                if (File.Exists(filePath)) {
                    MessageBox.Show("A file with the same name already exists. Please choose a different name.");
                    return;
                }

                File.WriteAllBytes(filePath, _storedFile);

                Recording newRecording = new Recording {
                    id = 100,
                    name = fileName,
                    duration = TimeSpan.Parse(soundDuration),
                    description = eventType,
                    timeCreated = DateTime.Now.ToString(),
                    storedFile = filePath,
                    accountId = null//loggedUser.id
                };

                try {
                    bool isAdded = recordingService.AddRecording(newRecording);
                    if (isAdded) {
                        MessageBox.Show("Sound successfully added!");
                    } else {
                        MessageBox.Show("Error while adding sound. Please try again.");
                    }
                } catch (DbUpdateException ex) {
                    // Log the exception details
                    MessageBox.Show("An error occurred while updating the entries. See the inner exception for details.");
                    Console.WriteLine("DbUpdateException: " + ex.Message);

                    if (ex.InnerException != null) {
                        Console.WriteLine("InnerException: " + ex.InnerException.Message);
                        if (ex.InnerException.InnerException != null) {
                            Console.WriteLine("Inner InnerException: " + ex.InnerException.InnerException.Message);
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message);
                    Console.WriteLine("Exception: " + ex.Message);
                }
            } catch (Exception ex) {
                MessageBox.Show("Error while saving sound: " + ex.Message);
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
