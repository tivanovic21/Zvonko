using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using NAudio.Wave;

namespace Zvonko {
    public partial class StreamingWindow : Window {
        private DispatcherTimer timer;
        private DispatcherTimer streamingTimer;

        private bool isRecording = false;
        private int countdownSeconds;
        private WaveIn waveIn;
        private WaveOut waveOut;
        private BufferedWaveProvider bufferedWaveProvider;
        private TimeSpan recordingDuration = TimeSpan.Zero;

        public StreamingWindow() {
            InitializeComponent();
            Closing += StreamingWindow_Closing;
        }

        private void btnStartRecording_Click(object sender, RoutedEventArgs e) {
            InitializeTimer();
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
            recordingDuration = TimeSpan.Zero;
            progressBar.Visibility = Visibility.Visible;
            lblDuration.Visibility = Visibility.Visible;

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
                progressBar.Visibility = Visibility.Hidden;

            } else if (waveOut != null) {
                waveOut.Stop();
                isRecording = false;

                recordingDuration = TimeSpan.Zero;
                lblDuration.Content = "Duration: 00:00";
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

                //progressBar
                recordingDuration = bufferedWaveProvider.BufferedDuration;
                streamingTimer = new DispatcherTimer();
                streamingTimer.Interval = TimeSpan.FromSeconds(1);
                streamingTimer.Tick += StreamingTimer_Tick;
                streamingTimer.Start();
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
            bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
            bufferedWaveProvider.BufferDuration = TimeSpan.FromSeconds(bufferSize / (double)waveIn.WaveFormat.AverageBytesPerSecond);
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e) {
            if (isRecording) {
                try {
                    bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);

                    //progressBar
                    double percentageFilled = (bufferedWaveProvider.BufferedDuration.TotalSeconds / bufferedWaveProvider.BufferDuration.TotalSeconds) * 100;
                    progressBar.Value = percentageFilled;

                    //timer
                    recordingDuration = recordingDuration.Add(TimeSpan.FromSeconds(e.BytesRecorded / (double)waveIn.WaveFormat.AverageBytesPerSecond));
                    lblDuration.Content = "Duration: " + recordingDuration.ToString(@"mm\:ss");

                } catch (InvalidOperationException ex) {
                    Console.WriteLine("Buffer full: " + ex.Message);
                }
            }
        }

        private void StreamingTimer_Tick(object sender, EventArgs e) {
            if (recordingDuration >= TimeSpan.Zero) {
                lblDuration.Content = "Duration: " + recordingDuration.ToString(@"mm\:ss");
                recordingDuration = recordingDuration.Subtract(TimeSpan.FromSeconds(1));
            } else {
                StopRecording();
                streamingTimer.Stop();
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