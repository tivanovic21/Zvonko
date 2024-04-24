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
using System.Windows.Shapes;
using Zvonko;

namespace Zvonko {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {

        AuthServices authServices = new AuthServices();
        public LoginWindow() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            AccountService accountService = new AccountService();

            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (!authServices.ValidateInput(username, password)) {
                MessageBox.Show("Please fill out all fields.");
            } 
            else {
                string hashedPassword = authServices.HashPassword(password, "");
                MessageBox.Show(hashedPassword);
                var account = accountService.GetAccount(username, hashedPassword);
                if (account != null) {
                    MainWindow mainWindow = new MainWindow(); // MainWindow(account)
                    this.Close();
                    mainWindow.Show();
                } else {
                    MessageBox.Show("Invalid credentials. Please try again!");
                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e) {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            this.Close();
            registrationWindow.Show();
        }
    }
}
