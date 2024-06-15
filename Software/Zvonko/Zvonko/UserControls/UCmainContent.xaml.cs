using BusinessLogicLayer;
using DatabaseLayer;
using DatabaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
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
        private DateTime? selectedDate = null;
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
                selectedDate = calendar.SelectedDate;
                txtPickedDate.Text = selectedDate?.ToString("d") ?? "";
            };

            calendarWindow.ShowDialog();
        }


      /* private void ButtonResetColor(Button button) {
            foreach (Button button in spButtonDay.Children)
            {
                button.Background = Brushes.White;
                button.FontWeight = FontWeights.Regular;
            }
            Button clickedButton = sender as Button;
            clickedButton.Background = Brushes.LightGray;
            clickedButton.FontWeight = FontWeights.Bold;
            
        }
      */

    

        private void txtPickedDate_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void btnMonday_Click(object sender, RoutedEventArgs e) {
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);
            List<Event> mondayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();
            foreach (var item in alLEvents) { 
                if(item.monday == true) {
                    mondayEvents.Add(item);
                }
            }
            
            dgRecordings.ItemsSource = mondayEvents;
        }

        private void btnTuesday_Click(object sender, RoutedEventArgs e) {
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);
            List<Event> tuesdayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();
            foreach (var item in alLEvents) {
                if (item.tuesday == true) {
                    tuesdayEvents.Add(item);
                }
            }
            dgRecordings.ItemsSource = tuesdayEvents;
        }


        private void btnWednesday_Click(object sender, RoutedEventArgs e) {
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);
            List<Event> wednesdayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();
            foreach (var item in alLEvents) {
                if (item.wednesday == true) {
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
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);
            List<Event> thursdayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();

            foreach (var item in alLEvents) {
                if (item.thursday == true) {
                    thursdayEvents.Add(item);
                }
            }
            dgRecordings.ItemsSource = thursdayEvents;
        }


        private void btnSaturday_Click(object sender, RoutedEventArgs e) {
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);
            List<Event> saturdayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();
            foreach (var item in alLEvents) {
                if (item.saturday == true) {
                    saturdayEvents.Add(item);
                }
            }
            dgRecordings.ItemsSource = saturdayEvents;
        }

        private void btnFriday_Click(object sender, RoutedEventArgs e) {
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);
            List<Event> fridayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();
            foreach (var item in alLEvents) {
                if (item.friday == true) {
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
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);
            if (selectedEvent != null) {
                bool removed = eventService.RemoveEvent(selectedEvent);
                if (removed) {
                    MessageBox.Show("Event removed successfully");
                } 
            } else {
                MessageBox.Show("Please select the event you want to remove");
            }
        }

        private void btnLoadCalendarDate_Click(object sender, RoutedEventArgs e) {
            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);
            List<Event> selectedDayEvents = new List<Event>();
            var alLEvents = eventService.GetAllEvents();
            if (string.IsNullOrEmpty(txtPickedDate.Text)){
                MessageBox.Show("Choose a date you want to load");
                return;
            }
            List<String> days = new List<String>();
            foreach (var item in alLEvents) {
                days.Clear();
                if ((bool)item.monday) days.Add(DayOfWeek.Monday.ToString());
                if ((bool)item.tuesday) days.Add(DayOfWeek.Tuesday.ToString());
                if ((bool)item.wednesday) days.Add(DayOfWeek.Wednesday.ToString());
                if ((bool)item.thursday) days.Add(DayOfWeek.Thursday.ToString());
                if ((bool)item.friday) days.Add(DayOfWeek.Friday.ToString());
                if ((bool)item.saturday) days.Add(DayOfWeek.Saturday.ToString());
                string date = item.date.ToString(); 
                if (days.Contains(selectedDate.Value.DayOfWeek.ToString()) || date == selectedDate?.ToString()) {
                    selectedDayEvents.Add(item);
                }
            }
            dgRecordings.ItemsSource = selectedDayEvents;
        }
        
        
        
    }
}
