using BusinessLogicLayer;
using DatabaseLayer;
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

namespace Zvonko.UserControls {
    /// <summary>
    /// Interaction logic for UCmainContent.xaml
    /// </summary>
    public partial class UCmainContent : UserControl {
        public UCmainContent() {
            InitializeComponent();
            DefineDataGridColumns();
        }

        private void btnOpenCalendar_Click(object sender, RoutedEventArgs e) {
            Window calendarWindow = new Window {
                Title = "Select a Date",
                Width = 300,
                Height = 200,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = new Calendar()
            };

            calendarWindow.Closed += (s, args) => {
                Calendar calendar = (Calendar)calendarWindow.Content;
                DateTime? selectedDate = calendar.SelectedDate;
                txtPickedDate.Text = selectedDate?.ToString("d") ?? "";
            };

            calendarWindow.ShowDialog();
        }


        private void Button_Click(object sender, RoutedEventArgs e) {
            /*
            foreach (Button button in spButtonDay.Children)
            {
                button.Background = Brushes.White;
                button.FontWeight = FontWeights.Regular;
            }
            Button clickedButton = sender as Button;
            clickedButton.Background = Brushes.LightGray;
            clickedButton.FontWeight = FontWeights.Bold;
            */
        }

    

        private void txtPickedDate_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void btnMonday_Click(object sender, RoutedEventArgs e) {
            EventService eventService = new EventService();
            List<Event> mondayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();
            foreach (var item in alLEvents) {
                var days = item.day_of_the_week;
                if (days.Contains("Monday")) {
                    mondayEvents.Add(item);
                }
            }
            dgRecordings.ItemsSource = mondayEvents;
        }

        private void btnTuesday_Click(object sender, RoutedEventArgs e) {
            EventService eventService = new EventService();
            List<Event> tuesdayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();
            foreach (var item in alLEvents) {
                var days = item.day_of_the_week;
                if (days.Contains("Tuesday")) {
                    tuesdayEvents.Add(item);
                }
            }
            dgRecordings.ItemsSource = tuesdayEvents;
        }


        private void btnWednesday_Click(object sender, RoutedEventArgs e) {
            EventService eventService = new EventService();
            List<Event> wednesdayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();
            foreach (var item in alLEvents) {
                var days = item.day_of_the_week;
                if (days.Contains("Wednesday")) {
                    wednesdayEvents.Add(item);
                }
            }
            dgRecordings.ItemsSource = wednesdayEvents;
        }

        private void DefineDataGridColumns() {
            dgRecordings.AutoGenerateColumns = false;

            DataGridTextColumn nameColumn = new DataGridTextColumn();
            nameColumn.Header = "Name";
            nameColumn.Binding = new Binding("name");

            DataGridTextColumn durationColumn = new DataGridTextColumn();
            durationColumn.Header = "Starting Time";
            durationColumn.Binding = new Binding("starting_time");

        }

        private void btnThursday_Click(object sender, RoutedEventArgs e) {
            EventService eventService = new EventService();
            List<Event> thursdayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();

            foreach (var item in alLEvents) {
                var days = item.day_of_the_week;
                if (days.Contains("Thursday")) {
                    thursdayEvents.Add(item);
                }
            }
            dgRecordings.ItemsSource = thursdayEvents;
        }


        private void btnSaturday_Click(object sender, RoutedEventArgs e) {
            EventService eventService = new EventService();
            List<Event> saturdayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();
            foreach (var item in alLEvents) {
                var days = item.day_of_the_week;
                if (days.Contains("Saturday")) {
                    saturdayEvents.Add(item);
                }
            }
            dgRecordings.ItemsSource = saturdayEvents;
        }

        private void btnFriday_Click(object sender, RoutedEventArgs e) {
            EventService eventService = new EventService();
            List<Event> fridayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();
            foreach (var item in alLEvents) {
                var days = item.day_of_the_week;
                if (days.Contains("Friday")) {
                    fridayEvents.Add(item);
                }
            }
            dgRecordings.ItemsSource = fridayEvents;
        }

        private Event GetSelectedEvent() {
            return dgRecordings.SelectedItem as Event;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e) {
            Event selectedEvent = GetSelectedEvent();
            EventService eventService = new EventService();
            if (selectedEvent != null) {
                bool removed = eventService.RemoveEvent(selectedEvent);
                if (removed) {
                    MessageBox.Show("Event removed successfully");
                } 
            } else {
                MessageBox.Show("Please select the event you want to remove");
            }
        }

        
    }
}
