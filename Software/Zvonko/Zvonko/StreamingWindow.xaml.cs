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
            }
        }

        private void StartRecording() {
            if (!isRecording) {
                waveIn.StartRecording();
                isRecording = true;
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
        }

        private void btnStopRecording_Click(object sender, RoutedEventArgs e) {
            StopRecording();
        }

        private void btnStream_Click(object sender, RoutedEventArgs e) {
            if (!isRecording) {
                waveOut = new WaveOut();
                waveOut.Init(bufferedWaveProvider);
                waveOut.Play();
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
            bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e) {
            if (isRecording) {
                try {
                    bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
                } catch (InvalidOperationException ex) {
                    Console.WriteLine("Buffer full: " + ex.Message);
                }
            }
        }
    }
}