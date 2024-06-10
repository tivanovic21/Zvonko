using BusinessLogicLayer;
using DatabaseLayer;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Zvonko.UserControls
{
    /// <summary>
    /// Interaction logic for UCaddSound.xaml
    /// </summary>
    public partial class UCaddSound : UserControl
    {
        private readonly RecordingService recordingService = new RecordingService();
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
                    try
                    {
                        LoadData(filePath);
                    } catch (ArgumentException exception)
                    {
                        ClearSuccess();
                        SetError(exception.Message);
                    }

                } else
                {
                    MessageBox.Show("Please select an audio file.");
                }
            }
        }

        private bool IsAudioFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return extension.Equals(".mp3", StringComparison.OrdinalIgnoreCase) ||
                   extension.Equals(".wav", StringComparison.OrdinalIgnoreCase);
        }

        private bool FindNonEnglishChars(string soundName)
        {
            string pattern = @"[^\x00-\x7F]";
            return System.Text.RegularExpressions.Regex.IsMatch(soundName, pattern);
        }

        private void LoadData(string filePath)
        {
            string soundName = Path.GetFileName(filePath);
            if (!FindNonEnglishChars(soundName))
            {
                txtSoundName.Text = soundName;
            } else
            {
                throw new ArgumentException("Sound name contains invalid characters!");
            }

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
            var loggedUser = ((MainWindow)Window.GetWindow(this)).LoggedUser;
            string soundName = txtSoundName.Text;
            string soundDuration = txtSoundLength.Text;
            string eventType = (radioYes.IsChecked == true) ? "emergency" : "audio";

            string assetsDir = "assets";
            if (!Directory.Exists(assetsDir))
            {
                Directory.CreateDirectory(assetsDir);
            }

            string soundsDir = Path.Combine(assetsDir, "sounds");
            if (!Directory.Exists(soundsDir))
            {
                Directory.CreateDirectory(soundsDir);
            }

            string fileName = Path.GetFileNameWithoutExtension(soundName);
            if (!fileName.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".mp3";
            }

            string filePath = Path.Combine(soundsDir, fileName);

            try
            {
                if (File.Exists(filePath))
                {
                    ClearSuccess();
                    MessageBox.Show("A file with the same name already exists. Please choose a different name.");
                    return;
                }

                File.WriteAllBytes(filePath, _storedFile);

                Recording newRecording = new Recording
                {
                    name = fileName,
                    duration = TimeSpan.Parse(soundDuration),
                    description = eventType,
                    timeCreated = DateTime.Now.ToString(),
                    storedFile = filePath,
                    AccountId = loggedUser.id
                };

                bool isAdded = recordingService.AddRecording(newRecording);
                if (isAdded)
                {
                    ClearError();
                    SetSuccess("Success!");
                    //MessageBox.Show("Sound successfully added!", "Success");
                } else
                {
                    ClearSuccess();
                    MessageBox.Show("Error while adding sound. Please try again.");
                }
            } catch (Exception ex)
            {
                ClearSuccess();
                MessageBox.Show("Error while saving sound: " + ex.Message);
            }
        }
        private void SetSuccess(string errMessage)
        {
            txtSuccessMessage.Text = errMessage;
            txtSuccessMessage.Visibility = Visibility.Visible;
        }

        private void ClearSuccess()
        {
            txtSuccessMessage.Text = "";
            txtSuccessMessage.Visibility = Visibility.Collapsed;
        }

        private void SetError(string errMessage)
        {
            txtErrorMessage.Text = errMessage;
            txtErrorMessage.Visibility = Visibility.Visible;
        }

        private void ClearError()
        {
            txtErrorMessage.Text = "";
            txtErrorMessage.Visibility = Visibility.Collapsed;
        }
    }
}