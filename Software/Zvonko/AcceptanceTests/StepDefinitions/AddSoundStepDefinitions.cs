using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class AddSoundStepDefinitions
    {
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            bool isWindowOpened = driver.FindElementByName("Zvonko - Login") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Login";
            if(isWindowOpened && isCorrentTitle)
            {
                var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
                var txtPassword = driver.FindElementByAccessibilityId("txtPassword");

                txtUsername.SendKeys("dev");
                txtPassword.SendKeys("dev");

                var btnLogin = driver.FindElementByAccessibilityId("btnLogin");
                btnLogin.Click();

                driver.SwitchTo().Window(driver.WindowHandles.First());
                bool isMainWindowOpened = driver.FindElementByName("Zvonko - Main") != null;
                bool isMainTitleCorrect = driver.Title == "Zvonko - Main";
                Assert.IsTrue(isMainWindowOpened && isMainTitleCorrect);
            }
        }

        [When(@"I click the Add New Sound button")]
        public void WhenIClickTheAddNewSoundButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnNewSound = driver.FindElementByAccessibilityId("btnNewSound");
            btnNewSound.Click();
        }

        [Then(@"I should see the Add Sound user control")]
        public void ThenIShouldSeeTheAddSoundUserControl()
        {
            var driver = GuiDriver.GetDriver();
            var lblAddSound = driver.FindElementByName("Add a new sound");
            Assert.IsNotNull(lblAddSound, "Add Sound UserControl is not displayed");
        }

        [Given(@"I am logged in and on a Add New Sound screen")]
        public void GivenIAmLoggedInAndOnAAddNewSoundScreen()
        {
            GivenIAmLoggedIn();
            WhenIClickTheAddNewSoundButton();
            ThenIShouldSeeTheAddSoundUserControl();
        }

        [When(@"I click the Cancel button")]
        public void WhenIClickTheCancelButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnCancel = driver.FindElementByAccessibilityId("btnCancel");
            btnCancel.Click();
        }

        [Then(@"I should see the main window")]
        public void ThenIShouldSeeTheMainWindow()
        {
            var driver = GuiDriver.GetDriver();
            var lblMainContent = driver.FindElementByName("Day you entered:");
            Assert.IsNotNull(lblMainContent, "Main content is not displayed");
        }

        [When(@"I click the Choose a sound button")]
        public void WhenIClickTheChooseASoundButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnChooseSound = driver.FindElementByAccessibilityId("btnChooseSound");
            btnChooseSound.Click();
        }

        [When(@"The file dialog is open")]
        public void TheFileDialogIsOpen()
        {
            var driver = GuiDriver.GetDriver();
            bool isFileDialogOpened = driver.FindElementByName("Otvori") != null;
            Assert.IsTrue(isFileDialogOpened);
        }

        [When(@"I choose a sound with name (.*)")]
        public void WhenIChooseASoundFromFileDialog(string soundName)
        {
            var driver = GuiDriver.GetDriver();
            var file = driver.FindElementByName(soundName.Replace(".mp3", ""));
            file.Click();
        }

        [When(@"I click the Open button")]  
        public void WhenIClickTheOpenButton()
        {
            var driver = GuiDriver.GetDriver();
            var fileDialog = driver.FindElementByName("Otvori");
            if (fileDialog != null)
            {
                // Press Enter because Open button has the same name as fileDialog
                Actions action = new Actions(driver);
                action.SendKeys(fileDialog, OpenQA.Selenium.Keys.Enter).Perform();
            }
        }

        [Then(@"I should see the selected file information on my screen")]
        public void ThenIShouldSeeTheSelectedFileInformationOnMyScreen()
        {
            var driver = GuiDriver.GetDriver();
            var txtSoundName = driver.FindElementByAccessibilityId("txtSoundName");
            var txtSoundLength = driver.FindElementByAccessibilityId("txtSoundLength");

            Assert.IsFalse(string.IsNullOrEmpty(txtSoundName.Text), "Sound name is not displayed");
            Assert.IsFalse(string.IsNullOrEmpty(txtSoundLength.Text), "Sound length is not displayed");
        }

    }
}
