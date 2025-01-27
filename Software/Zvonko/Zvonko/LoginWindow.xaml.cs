﻿using BusinessLogicLayer;
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
using System.Windows.Shapes;
using Zvonko;

namespace Zvonko {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        AuthServices authServices = new AuthServices();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AccountRepository accRepo = new AccountRepository();
            AccountService accountService = new AccountService(accRepo);

            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (!authServices.ValidateInput(username, password))
            {
                SetError("Fill out all fields!");
                //MessageBox.Show("Please fill out all fields.");
            } else
            {
                ClearError();
                var account = accountService.GetAccount(username);
                if (account == null)
                {
                    SetError("User not found!");
                    //MessageBox.Show("User not found!", "User not found!");
                }

                if (account != null)
                {
                    ClearError();
                    bool checkPass = authServices.VerifyPassword(password, account.password);
                    if (checkPass == true)
                    {
                        MainWindow mainWindow = new MainWindow(account);
                        this.Close();
                        mainWindow.Show();
                        return;
                    }
                    SetError("Invalid credentials!");
                    //MessageBox.Show("Invalid credentials. Please try again!");
                }
            }
        }


        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            this.Close();
            registrationWindow.Show();
        }

        private void SetError(string errMessage)
        {
            txtErrorMessage.Text = errMessage;
            txtErrorMessage.Visibility = Visibility.Visible;
        }

        private void ClearError()
        {
            txtErrorMessage.Text = "";
            txtErrorMessage.Visibility = Visibility.Collapsed;
        }
    }
}
