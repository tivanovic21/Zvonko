using BusinessLogicLayer;
using DatabaseLayer;
using DatabaseLayer.Repositories;
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
    /// Interaction logic for UCupdateEvent.xaml
    /// </summary>
    public partial class UCupdateEvent : UserControl {
        private Event _selected;
        
        public UCupdateEvent(Event selected) {
            InitializeComponent();
            _selected = selected;
            DefineDataGridColumns();
            GetRecordings();
            PopulateTextBoxes();
        }

        private void GetRecordings() {

            RecordingRepository recordingRepository = new RecordingRepository();
            RecordingService recordingService = new RecordingService(recordingRepository);
            dgRecordings.ItemsSource = recordingService.GetAllRecordings();
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

        private void PopulateTextBoxes() {
            txtNameOfEvent.Text = _selected.name;
            txtDescriptionOfEvent.Text = _selected.description;
            txtStartingTime.Text = _selected.starting_time.ToString();
        }

        private Recording GetSelectedRecording() {
            return dgRecordings.SelectedItem as Recording;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(txtNameOfEvent.Text) || string.IsNullOrWhiteSpace(txtDescriptionOfEvent.Text) || string.IsNullOrWhiteSpace(txtStartingTime.Text)) {
                MessageBox.Show("Fill out all fields!");
                return;
            }
            if(GetSelectedRecording()?.id == null) {
                MessageBox.Show("Choose a recording!");
                return;
            }
            _selected.name = txtNameOfEvent.Text;
            _selected.description = txtDescriptionOfEvent.Text;
            _selected.starting_time = TimeSpan.Parse(txtStartingTime.Text);
            _selected.recordingId = GetSelectedRecording().id;

            EventRepository eventRepository = new EventRepository();
            EventService eventService = new EventService(eventRepository);
            if (eventService.UpdateEvent(_selected)) {
                MessageBox.Show("Event update successfully!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null && parentWindow is MainWindow) {
                MainWindow mainWindow = (MainWindow)parentWindow;
                mainWindow.LoadMainContent();
            }
        }
    }
}
