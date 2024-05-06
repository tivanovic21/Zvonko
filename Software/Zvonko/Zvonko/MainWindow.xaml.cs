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
using Zvonko.UserControls;

namespace Zvonko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Account account)
        {
            InitializeComponent();
            LoadMainContent();
            //LoadRecordings();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();
        }

        public void LoadMainContent()
        {
            UCmainContent ucMainContent = new UCmainContent();
            contentPanel.Content = ucMainContent;
        }

        private void btnNewSound_Click(object sender, RoutedEventArgs e)
        {
            UCaddSound ucAddSound = new UCaddSound();
            contentPanel.Content = ucAddSound;
        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            UCaddEvent uCaddEvent = new UCaddEvent();
            contentPanel.Content = uCaddEvent;
        }

        private void btnLiveBroadcast_Click(object sender, RoutedEventArgs e)
        {
            StreamingWindow streamingWindow = new StreamingWindow();
            streamingWindow.Show();
        }
    }
}