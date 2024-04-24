using BusinessLogicLayer;
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
    /// Interaction logic for UCmainContent.xaml
    /// </summary>
    public partial class UCmainContent : UserControl
    {
        public UCmainContent()
        {
            InitializeComponent();
        }

        private void btnOpenCalendar_Click(object sender, RoutedEventArgs e)
        {
            Window calendarWindow = new Window
            {
                Title = "Select a Date",
                Width = 300,
                Height = 200,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = new Calendar()
            };

            calendarWindow.Closed += (s, args) =>
            {
                Calendar calendar = (Calendar)calendarWindow.Content;
                DateTime? selectedDate = calendar.SelectedDate;
                txtPickedDate.Text = selectedDate?.ToString("d") ?? "";
            };

            calendarWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button button in spButtonDay.Children)
            {
                button.Background = Brushes.White;
                button.FontWeight = FontWeights.Regular;
            }
            Button clickedButton = sender as Button;
            clickedButton.Background = Brushes.LightGray;
            clickedButton.FontWeight = FontWeights.Bold;
        }

        private void LoadRecordings()
        {
            RecordingService recordingService = new RecordingService();
            dgRecordings.ItemsSource = recordingService.GetAllRecordings();
        }
    }
}
