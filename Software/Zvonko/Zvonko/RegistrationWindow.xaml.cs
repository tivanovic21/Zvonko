using BusinessLogicLayer;
using EntitiesLayer;
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

namespace Zvonko
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        AccountService accountService = new AccountService();
        public Registration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (RegisterNewUser())
            {
                MessageBox.Show("Registration successfull! Please log in.");
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
        }

        private bool RegisterNewUser()
        {
            if (ValidateInput())
            {
                Account newAccount = new Account
                {
                    username = txtUsername.Text,
                    password = txtPassword.Text,
                    schoolName = txtSchoolName.Text
                };
                bool successfullRegistration = accountService.AddAccount(newAccount);
                return successfullRegistration;
            }
            else
            {
                MessageBox.Show("Please fill out all the fields!");
                return false;
            }
        }
        private bool ValidateInput()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string schoolName = txtSchoolName.Text;

            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password) || !string.IsNullOrEmpty(schoolName)) return true;
            return false;
        }
    }
}
