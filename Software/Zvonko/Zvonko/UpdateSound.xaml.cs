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
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Zvonko
{
    /// <summary>
    /// Interaction logic for UpdateSound.xaml
    /// </summary>
    public partial class UpdateSound : Window
    {
        private Recording _selectedRecording;
        private byte[] _storedFile;

        public UpdateSound(Recording selectedRecording)
        {
            InitializeComponent();
            _selectedRecording = selectedRecording;
            LoadData(_selectedRecording);
        }

        private void LoadData(Recording selectedRecording)
        {
            txtSoundName.Text = selectedRecording.name;
            txtSoundLength.Text = (selectedRecording.duration).ToString();
            if(selectedRecording.description == "emergency")
            {
                rbYes.IsChecked = true;
            }
            else
            {
                rbNo.IsChecked = true;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            RecordingService recordingService = new RecordingService();
            string filePath = null;

            if (_storedFile != null)
            {
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

                filePath = Path.Combine(soundsDir, txtSoundName.Text);

                try
                {
                    File.WriteAllBytes(filePath, _storedFile);
                } catch (Exception ex)
                {
                    MessageBox.Show("Error while saving new sound file: " + ex.Message);
                    return;
                }
            }

            Recording recording = new Recording
            {
                id = _selectedRecording.id,
                name = txtSoundName.Text,
                duration = TimeSpan.Parse(txtSoundLength.Text),
                storedFile = filePath ?? _selectedRecording.storedFile,
                timeCreated = _selectedRecording.timeCreated,
                description = rbYes.IsChecked == true ? "emergency" : "regular",
                Account = _selectedRecording.Account
            };

            bool isUpdated = recordingService.UpdateRecording(recording);
            if (isUpdated)
            {
                MessageBox.Show("Sound successfully updated!");
                this.Close();
            } else
            {
                MessageBox.Show("Error while updating sound. Please try again.");
            }
        }


        private void LoadNewData(string filePath)
        {
            txtSoundName.Text = Path.GetFileName(filePath);

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
                    LoadNewData(filePath);
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
    }
}
