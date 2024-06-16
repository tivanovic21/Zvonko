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
using System.Xml.Linq;

namespace Zvonko.UserControls {
    /// <summary>
    /// Interaction logic for UCuserProfile.xaml
    /// </summary>
    public partial class UCuserProfile : UserControl {
        public Account _loggedUser;
        private AccountRepository accountRepository;
        public UCuserProfile(Account loggedUser) {
            InitializeComponent();
            _loggedUser = loggedUser;
            PopulateTextboxes();
        }

        public void PopulateTextboxes() {
            txtUsername.Text = _loggedUser.username;
            txtSchoolName.Text = _loggedUser.schoolName;
            txtMacAddress.Text = _loggedUser.macAddress;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            AccountService accountService = new AccountService(accountRepository);
            if (string.IsNullOrWhiteSpace(txtMacAddress.Text) || string.IsNullOrWhiteSpace(txtSchoolName.Text) || string.IsNullOrWhiteSpace(txtUsername.Text)) {
                MessageBox.Show("Fill out all fields!");
                return;
            }
            _loggedUser.username = txtUsername.Text;
            _loggedUser.schoolName = txtSchoolName.Text;
            _loggedUser.macAddress = txtMacAddress.Text;

            accountService.UpdateAccount(_loggedUser);
            MessageBox.Show("User profile succesfully updated");
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
