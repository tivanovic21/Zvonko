using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using NAudio.Wave;

namespace Zvonko {
    public partial class StreamingWindow : Window {
        private DispatcherTimer timer;
        private bool isRecording = false;
        private int countdownSeconds;
        private WaveIn waveIn;
        private WaveOut waveOut;
        private BufferedWaveProvider bufferedWaveProvider;

        public StreamingWindow() {
            InitializeComponent();
            InitializeTimer();
            Closing += StreamingWindow_Closing;
        }

        private void btnStartRecording_Click(object sender, RoutedEventArgs e) {
            StartCountdown();
            InitializeWaveIn();
        }

        private void StartCountdown() {
            MessageBoxResult result = MessageBox.Show("Start streaming now?", "Start Streaming", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes && !isRecording) {
                countdownSeconds = 3;
                timer.Start();
            }
        }

        private void Timer_Countdown(object sender, EventArgs e) {
            if (countdownSeconds >= 0) {
                if (countdownSeconds == 0) {
                    StartRecording();
                }
                lblCountdown.Content = countdownSeconds.ToString();
                countdownSeconds--;
            } else {
                timer.Stop();
                lblCountdown.Content = "";
            }
        }

        private void StartRecording() {
            if (!isRecording) {
                waveIn.StartRecording();
                isRecording = true;
                btnStartRecording.IsEnabled = false;
                btnStopRecording.IsEnabled = true;
                btnStream.IsEnabled = false;

                progressBar.Value = 0;
            }
        }

        private void StopRecording() {
            if (isRecording) {
                waveIn.StopRecording();
                isRecording = false;
            }else {
                waveOut.Stop();
                isRecording = false;
            }
            btnStartRecording.IsEnabled = true;
            btnStopRecording.IsEnabled = false;
            btnStream.IsEnabled = true;

            progressBar.Value = 0;
        }

        private void btnStopRecording_Click(object sender, RoutedEventArgs e) {
            StopRecording();
        }

        private void btnStream_Click(object sender, RoutedEventArgs e) {
            if (!isRecording) {
                waveOut = new WaveOut();
                waveOut.Init(bufferedWaveProvider);
                waveOut.Play();
                btnStartRecording.IsEnabled = false;
                btnStopRecording.IsEnabled = true;
                btnStream.IsEnabled = false;
            }
        }

        private void InitializeTimer() {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Countdown;
        }

        private void InitializeWaveIn() {
            waveIn = new WaveIn();
            waveIn.WaveFormat = new WaveFormat(44100, 1);
            waveIn.DataAvailable += WaveIn_DataAvailable;

            
            int bufferSize = 44100 * 2 * 120;
            bufferedWaveProvider = new BufferedWaveProvider (waveIn.WaveFormat);
            bufferedWaveProvider.BufferDuration = TimeSpan.FromSeconds (bufferSize/(double)waveIn.WaveFormat.AverageBytesPerSecond);
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e) {
            if (isRecording) {
                try {
                    bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);

                    double percentageFilled = (bufferedWaveProvider.BufferedDuration.TotalSeconds / bufferedWaveProvider.BufferDuration.TotalSeconds) * 100;
                    progressBar.Value = percentageFilled;
                } catch (InvalidOperationException ex) {
                    Console.WriteLine("Buffer full: " + ex.Message);
                }
            }
        }

        private void StreamingWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (isRecording || (bufferedWaveProvider != null && bufferedWaveProvider.BufferedDuration.TotalSeconds > 0)) {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to stop the current action?", "Confirm Action", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No) {
                    e.Cancel = true;
                } else {
                    StopRecording();
                }
            } else {
                StopRecording();
            }
        }
    }
}