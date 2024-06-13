using System;
using System.Windows;
using System.Windows.Threading;
using BusinessLogicLayer;

namespace Zvonko {
    public partial class StreamingWindow : Window {
        private StreamService streamService;
        private bool isStreaming = false;
        private DispatcherTimer timer;
        private TimeSpan streamingDuration = TimeSpan.Zero;
        private TimeSpan delay = TimeSpan.FromSeconds(2);

        public StreamingWindow() {
            InitializeComponent();
            streamService = new StreamService(delay);
            Closing += StreamingWindow_Closing;
        }

        private void btnStartStreaming_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show("Start streaming now?", "Start Streaming", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes && !isStreaming) {
                StartStreaming();
            }
        }

        private void StartStreaming() {
            InitializeTimer();
            streamService.OnStartStreaming();
            btnStartStreaming.IsEnabled = false;
            btnStopStreaming.IsEnabled = true;
            isStreaming = true;
            timer.Start();
        }

        private void InitializeTimer() {
            streamingDuration = TimeSpan.Zero;
            lblDuration.Content = "Duration: 00:00";
            lblDuration.Visibility = Visibility.Visible;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void btnStopStreaming_Click(object sender, RoutedEventArgs e) {
            streamService.OnStopStreaming();
            btnStartStreaming.IsEnabled = true;
            btnStopStreaming.IsEnabled = false;
            lblDuration.Content = "";
            //lblDuration.Visibility = Visibility.Collapsed;
            isStreaming = false;
            timer.Stop();
        }

        private void StreamingWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (isStreaming) {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to stop streaming?", "Confirm Action", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No) {
                    e.Cancel = true;
                } else {
                    streamService.OnStopStreaming();
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e) {
            streamingDuration = streamingDuration.Add(TimeSpan.FromSeconds(1));
            lblDuration.Content = "Duration: " + streamingDuration.ToString(@"mm\:ss");
        }
    }
}