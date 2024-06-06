using BusinessLogicLayer;
using DatabaseLayer;
using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace Zvonko
{
    public partial class UpdateSound : Window
    {
        private readonly Recording _selectedRecording;
        private byte[] _storedFile;
        private Account _loggedAccount;

        public UpdateSound(Recording selectedRecording, Account loggedAccount)
        {
            InitializeComponent();
            _selectedRecording = selectedRecording;
            _loggedAccount = loggedAccount;
            LoadData(_selectedRecording);
        }

        private void LoadData(Recording selectedRecording)
        {
            txtSoundName.Text = selectedRecording.name;
            txtSoundLength.Text = String.Format("{0:hh\\:mm\\:ss}", selectedRecording.duration);
            rbYes.IsChecked = (selectedRecording.description == "emergency");
            rbNo.IsChecked = !rbYes.IsChecked;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string filePath = null;

            if (_storedFile != null)
            {
                filePath = SaveFile();
                if (filePath == null)
                    return;
            }

            RecordingService recordingService = new RecordingService();

            Recording recording = new Recording
            {
                id = _selectedRecording.id,
                name = txtSoundName.Text,
                duration = TimeSpan.Parse(txtSoundLength.Text),
                storedFile = filePath ?? _selectedRecording.storedFile,
                timeCreated = _selectedRecording.timeCreated,
                description = (rbYes.IsChecked == true) ? "emergency" : "regular"
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

        private string SaveFile()
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

            string fileName = Path.GetFileNameWithoutExtension(txtSoundName.Text);
            if (!fileName.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".mp3";
            }

            string filePath = Path.Combine(soundsDir, fileName);

            try
            {
                if (File.Exists(filePath))
                {
                    MessageBoxResult result = MessageBox.Show("A file with the same name already exists. Do you want to replace it?", "Confirm Save", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No)
                        return null;
                    else
                        File.Delete(filePath);
                }

                File.WriteAllBytes(filePath, _storedFile);
                return filePath;
            } catch (Exception ex)
            {
                MessageBox.Show("Error while saving new sound file: " + ex.Message);
                return null;
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

        private void LoadNewData(string filePath)
        {
            txtSoundName.Text = Path.GetFileName(filePath);

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                _storedFile = new byte[fs.Length];
                fs.Read(_storedFile, 0, _storedFile.Length);
            }

            using(var audioFile = new AudioFileReader(filePath))
            {
                txtSoundLength.Text = audioFile.TotalTime.ToString(@"hh\:mm\:ss");
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
