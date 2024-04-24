using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        public UCaddSound()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(filePath));
            mediaPlayer.MediaOpened += (sender, e) =>
            {
                if (mediaPlayer.NaturalDuration.HasTimeSpan)
                {
                    TimeSpan duration = mediaPlayer.NaturalDuration.TimeSpan;
                    txtSoundLength.Text = duration.ToString(@"hh\:mm\:ss");
                }
            };
        }
    }
}
