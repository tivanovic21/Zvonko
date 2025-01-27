﻿using BusinessLogicLayer;
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
using System.Windows.Shapes;

namespace Zvonko
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private static AccountRepository accRepo = new AccountRepository();
        private AccountService accountService = new AccountService(accRepo);
        AuthServices authServices = new AuthServices();
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (RegisterNewUser())
            {
                LoginWindow loginWindow = new LoginWindow();
                this.Close();
                loginWindow.Show();
            }
        }

        private bool RegisterNewUser()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string schoolName = txtSchoolName.Text;

            if (authServices.ValidateRegistrationInput(username, password, schoolName))
            {
                ClearError();
                string hashedPassword = authServices.HashPassword(password);
                if (string.IsNullOrEmpty(hashedPassword)) return false;

                Account newAccount = new Account
                {
                    username = username,
                    password = hashedPassword,
                    schoolName = schoolName
                };
                bool successfullRegistration = accountService.AddAccount(newAccount);
                return successfullRegistration;
            }
            else
            {
                SetError("Fill out all fields!");
                //MessageBox.Show("Please fill out all the fields!");
                return false;
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();
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
