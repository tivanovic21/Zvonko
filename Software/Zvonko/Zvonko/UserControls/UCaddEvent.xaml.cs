using BusinessLogicLayer;
using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    /// Interaction logic for UCaddEvent.xaml
    /// </summary>
    public partial class UCaddEvent : UserControl {
        private string selectedDays = null;
        
        private DateTime? nonReccuringEventDate = null;
        public UCaddEvent() {
            InitializeComponent();
            GetAllRecordings();
            DefineDataGridColumns();
        }

        private /*async*/ void GetAllRecordings() {
            RecordingService recordingService = new RecordingService();
            dgRecordings.ItemsSource = /*await*/ recordingService.GetAllRecordings();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null && parentWindow is MainWindow) {
                MainWindow mainWindow = (MainWindow)parentWindow;
                mainWindow.LoadMainContent();
            }
        }

        private Recording GetSelectedRecording() {
            return dgRecordings.SelectedItem as Recording;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            string name = txtNameOfEvent.Text;
            string description = txtDescriptionOfEvent.Text;
            int recordingId = GetSelectedRecording().id;
            int isReoccuring = 0;
            if (rbReoccuring.IsChecked == true) {
                selectedDays = GetSelectedDays();
                isReoccuring = 1;
            } else if (rbNonReocurring.IsChecked == true) {
                isReoccuring = 2;
            }
            TimeSpan startingTime;
            if (TimeSpan.TryParse(txtStartingTime.Text, out startingTime)) {
                EventService eventService = new EventService();

                Event newEvent = new Event {
                    name = name,
                    description = description,
                    starting_time = startingTime,
                    day_of_the_week = string.Join(", ", selectedDays),
                    accountId = 1,
                    recordingId = recordingId,
                    typeOfEventId = isReoccuring,
                    date = nonReccuringEventDate
                };

                bool isAdded = eventService.AddEvent(newEvent);
                if (isAdded) {
                    MessageBox.Show("Event successfully added!");
                } else {
                    MessageBox.Show("Error while adding event. Please try again.");
                }
            } else {
                MessageBox.Show("Invalid starting time format. Please enter time in valid format (HH:mm:ss).");
            }
        }

        private void DefineDataGridColumns() {
            dgRecordings.AutoGenerateColumns = false;

            DataGridTextColumn nameColumn = new DataGridTextColumn();
            nameColumn.Header = "Name";
            nameColumn.Binding = new Binding("name");

            DataGridTextColumn durationColumn = new DataGridTextColumn();
            durationColumn.Header = "Duration";
            durationColumn.Binding = new Binding("duration");

            DataGridTextColumn descriptionColumn = new DataGridTextColumn();
            descriptionColumn.Header = "Description";
            descriptionColumn.Binding = new Binding("description");

            DataGridTextColumn timeCreatedColumn = new DataGridTextColumn();
            timeCreatedColumn.Header = "Time Created";
            timeCreatedColumn.Binding = new Binding("timeCreated");
        }

        private string GetSelectedDays() {
            List<string> selectedDays = new List<string>(); 
            foreach (var item in spCheckboxDays.Children) {
                if(item is CheckBox checkBox && checkBox.IsChecked == true) {
                    selectedDays.Add(checkBox.Content.ToString());
                }
            }
            return string.Join(", ", selectedDays);
        }

        private void CheckBoxSelectAll_Checked(object sender, RoutedEventArgs e) {
            var checkboxes = GetAllCheckBoxes(spCheckboxDays);
            foreach (var checkbox in checkboxes) {
                checkbox.IsChecked = true;
            }
        }

        private void CheckBoxSelectAll_Unchecked(object sender, RoutedEventArgs e) {
            var checkboxes = GetAllCheckBoxes(spCheckboxDays);
            foreach (var checkbox in checkboxes) {
                checkbox.IsChecked = false;
            }
        }

        private IEnumerable<CheckBox> GetAllCheckBoxes(StackPanel stackPanel) {
            var checkboxes = new List<CheckBox>();

            foreach (var child in stackPanel.Children) {
                if (child is CheckBox checkbox) {
                    checkboxes.Add(checkbox);
                }
            }
            return checkboxes;
        }

        private void rbReoccuring_Checked(object sender, RoutedEventArgs e) {
            calNonReccuringEvent.Visibility = Visibility.Hidden;
            spCheckboxDays.Visibility = Visibility.Visible;
        }

        private void rbNonReocurring_Checked(object sender, RoutedEventArgs e) {
            calNonReccuringEvent.Visibility = Visibility.Visible;
            spCheckboxDays.Visibility = Visibility.Hidden;
        }

        private void calNonReccuringEvent_SelectedDatesChanged(object sender, SelectionChangedEventArgs e) {
            nonReccuringEventDate = calNonReccuringEvent.SelectedDate.Value;
        }

      

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Recording selectedRecording = GetSelectedRecording();
            if(selectedRecording != null)
            {
                UpdateSound updateSound = new UpdateSound(selectedRecording);
                updateSound.ShowDialog();
            } else
            {
                MessageBox.Show("You need to select a recording!");
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Recording selectedRecording = GetSelectedRecording();
            if(selectedRecording != null)
            {
                RecordingService recordingService = new RecordingService();
                bool success = recordingService.RemoveRecording(selectedRecording);
                if (success) MessageBox.Show("Recording successfully deleted!");
                else MessageBox.Show("There was an error in deleted selected recording!");
            } else
            {
                MessageBox.Show("You need to select a recording!");
            }
        }
    }
}

