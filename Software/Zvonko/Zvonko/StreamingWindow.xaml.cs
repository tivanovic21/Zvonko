using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Zvonko {
    /// <summary>
    /// Interaction logic for StreamingWindow.xaml
    /// </summary>
    public partial class StreamingWindow : Window {
        private DispatcherTimer timer;
        private int countdownSeconds;

        public StreamingWindow() {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer() {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void btnStartStreaming_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            MessageBoxResult result = MessageBox.Show("Start streaming now?", "Start Streaming", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes) {
                StartCountdown();
            }
        }

        private void StartCountdown() {
            countdownSeconds = 3;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            if (countdownSeconds >= 0) {
                if (countdownSeconds == 0) {
                    return;
                }
                lblCountdown.Content = countdownSeconds.ToString();
                countdownSeconds--;
            } else {
                timer.Stop();
            }
        }
    }
}
