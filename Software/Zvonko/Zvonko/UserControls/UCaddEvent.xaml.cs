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
    /// Interaction logic for UCaddEvent.xaml
    /// </summary>
    public partial class UCaddEvent : UserControl {
        public UCaddEvent() {
            InitializeComponent();
            GetAllRecordings();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null && parentWindow is MainWindow) {
                MainWindow mainWindow = (MainWindow)parentWindow;
                mainWindow.LoadMainContent();
            }
        }

        private async void GetAllRecordings() {
            RecordingService recordingService = new RecordingService();
            List<Recording> recordings = await  recordingService.GetAllRecordings(); dgRecordings.ItemsSource = recordings;
        }

    }
}
