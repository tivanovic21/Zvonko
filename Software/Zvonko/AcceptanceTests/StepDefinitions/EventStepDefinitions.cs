using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Windows;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class EventStepDefinitions
    {
        [Given(@"I'm logged in and on main screen")]
        public void GivenImLoggedInAndOnMainScreen()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            bool isWindowOpened = driver.FindElementByName("Zvonko - Login") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Login";
            if (isWindowOpened && isCorrentTitle) {
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

        [When(@"I click Add event button")]
        public void WhenIClickAddEventButton()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnAddEvent");
            btnEmergency.Click();
        }

        [Then(@"I should see the Add event screen")]
        public void ThenIShouldSeeTheAddEventScreen()
        {
            var driver = GuiDriver.GetDriver();
            var lblAddEvent = driver.FindElementByName("Audio recording details");
            Assert.IsNotNull(lblAddEvent, "Add Event UserControl is not displayed");
        }




        [Given(@"I'm logged in succesfully")]
        public void GivenImLoggedInSuccesfully() {
            var driver = GuiDriver.GetOrCreateDriver();
            bool isWindowOpened = driver.FindElementByName("Zvonko - Login") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Login";
            if (isWindowOpened && isCorrentTitle) {
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

        [When(@"I click Add event button on the main screen")]
        public void WhenIClickAddEventButtonOnTheMainScreen() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnAddEvent");
            btnEmergency.Click();
        }

        [When(@"I click the Cancel button on Add event")]
        public void WhenIClickTheCancelButtonOnAddEvent() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnCancel = driver.FindElementByAccessibilityId("btnCancel");
            btnCancel.Click();
        }

        [Then(@"I should see the main window after i click cancel")]
        public void ThenIShouldSeeTheMainWindowAfterIClickCancel() {
            var driver = GuiDriver.GetDriver();
            var lblMainContent = driver.FindElementByName("Day you entered:");
            Assert.IsNotNull(lblMainContent, "Main content is not displayed");
        }



        [Given(@"I'm logged in successfully into main")]
        public void GivenImLoggedInSuccessfullyIntoMain() {
            var driver = GuiDriver.GetOrCreateDriver();
            bool isWindowOpened = driver.FindElementByName("Zvonko - Login") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Login";
            if (isWindowOpened && isCorrentTitle) {
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

        [When(@"I click Add event")]
        public void WhenIClickAddEvent() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnAddEvent = driver.FindElementByAccessibilityId("btnAddEvent");
            btnAddEvent.Click();
        }

        [When(@"I check is not recurring checkbox on Add event")]
        public void WhenICheckIsNotRecurringCheckboxOnAddEvent() {
            var driver = GuiDriver.GetOrCreateDriver();
            var chkNonRecurring = driver.FindElementByAccessibilityId("rbNonReocurring");
            chkNonRecurring.Click();
        }

        [Then(@"I should see the calendar picker")]
        public void ThenIShouldSeeTheCalendarPicker() {
            var driver = GuiDriver.GetDriver();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var calendar = wait.Until(d => {
                var element = driver.FindElementByAccessibilityId("calNonReccuringEvent");
                return element.Displayed ? element : null;
            });

            Assert.IsNotNull(calendar, "Calendar picker is not displayed");
            Assert.IsTrue(calendar.Displayed, "Calendar picker is not visible");
        }




        [Given(@"Logged in succesfully")]
        public void GivenLoggedInSuccessfully() {
            var driver = GuiDriver.GetOrCreateDriver();
            bool isWindowOpened = driver.FindElementByName("Zvonko - Login") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Login";
            if (isWindowOpened && isCorrentTitle) {
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

        [When(@"I click Add event in nav")]
        public void WhenIClickAddEventInNav() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnAddEvent = driver.FindElementByAccessibilityId("btnAddEvent");
            btnAddEvent.Click();
        }

        [When(@"I select a recording i want to remove")]
        public void WhenISelectARecordingIWantToRemove() {
            var driver = GuiDriver.GetOrCreateDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgRecordings");

            var firstRow = dataGridView.FindElementByXPath("//DataItem[1]");
            firstRow.Click();
        }
        

        [When(@"I Click remove selected recording")]
        public void WhenIClickRemoveSelectedRecording() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnRemove = driver.FindElementByAccessibilityId("btnRemove");

            btnRemove.Click();
        }

        [Then(@"I should see the popup saying succesfully deleted")]
        public void ThenIShouldSeeThePopupSayingSuccesfullyDeleted() {
            var driver = GuiDriver.GetOrCreateDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());

            bool btnOk = driver.FindElementByAccessibilityId("2") != null;
            Assert.IsTrue(btnOk);
        }



        [Given(@"Log in succesfully")]
        public void GivenLogInSuccessfully() {
            var driver = GuiDriver.GetOrCreateDriver();
            bool isWindowOpened = driver.FindElementByName("Zvonko - Login") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Login";
            if (isWindowOpened && isCorrentTitle) {
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
       

        [When(@"I click Add event button on main")]
        public void WhenIClickAddEventButtonOnMain() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnAddEvent = driver.FindElementByAccessibilityId("btnAddEvent");
            btnAddEvent.Click();
        }

        [When(@"I click remove event")]
        public void WhenIClickRemoveEvent() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnRemove = driver.FindElementByAccessibilityId("btnRemove");

            btnRemove.Click();
        }

        [Then(@"I should see not allowed")]
        public void ThenIShouldSeeNotAllowed() {
            var driver = GuiDriver.GetOrCreateDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());

            bool btnOk = driver.FindElementByAccessibilityId("2") != null;
            Assert.IsTrue(btnOk);
        }


        [Given(@"I am logged in on the main screen")]
        public void GivenIAmLoggedInOnTheMainScreen() {
            var driver = GuiDriver.GetOrCreateDriver();
            bool isWindowOpened = driver.FindElementByName("Zvonko - Login") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Login";
            if (isWindowOpened && isCorrentTitle) {
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
        [When(@"I go to event addition screen")]
        public void WhenIGoToEventAdditionScreen() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnAdd = driver.FindElementByAccessibilityId("btnAddEvent");
            btnAdd.Click();
            
        }

        [When(@"I enter new event details: name (.*), description (.*) and starting time (.*)")]
        public void WhenIEnterNewEventDetails(string name, string description, string startingTime) {
            var driver = GuiDriver.GetOrCreateDriver();

            var txtName = driver.FindElementByAccessibilityId("txtNameOfEvent");
            txtName.SendKeys(name);

            var txtDescription = driver.FindElementByAccessibilityId("txtDescriptionOfEvent");
            txtDescription.SendKeys(description);

            var txtStartingTime = driver.FindElementByAccessibilityId("txtStartingTime");
            txtStartingTime.SendKeys(startingTime);

            var rbReccuing = driver.FindElementByAccessibilityId("rbReoccuring");
            rbReccuing.Click();

            var chkMonday = driver.FindElementByAccessibilityId("chkMonday");
            chkMonday.Click();
        }


        [When(@"I select the recording")]
        public void WhenISelectTheRecording() {
            var driver = GuiDriver.GetOrCreateDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgRecordings");

            var firstRow = dataGridView.FindElementByXPath("//DataItem[1]");
            firstRow.Click();
        }

        [When(@"I click on the Add button")]
        public void WhenIClickOnTheAddButton() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnSave = driver.FindElementByAccessibilityId("btnSave");
            btnSave.Click();
        }


        [Then(@"I should see (.*) error message in add event screen")]
        public void ThenIShouldSeeFillOutAllFieldsErrorMessageForNewEvent(string expectedMessage) {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            var messageBoxTextElement = driver.FindElement(By.XPath("//Text"));
            string actualMessage = messageBoxTextElement.Text.Trim();

            Assert.AreEqual(expectedMessage, actualMessage);
        }


        [Given(@"Succesfull login")]
        public void GivenSuccesfullLogin() {
            var driver = GuiDriver.GetOrCreateDriver();
            bool isWindowOpened = driver.FindElementByName("Zvonko - Login") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Login";
            if (isWindowOpened && isCorrentTitle) {
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

        [When(@"I click Add event using navigation")]
        public void WhenIClickAddEventUsingNavigation() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnAdd = driver.FindElementByAccessibilityId("btnAddEvent");
            btnAdd.Click();

        }

        
        [When(@"I select an recording to update")]
            public void WhenISelectAnRecordingToUpdate() {
            var driver = GuiDriver.GetOrCreateDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgRecordings");

            var firstRow = dataGridView.FindElementByXPath("//DataItem[1]");
            firstRow.Click();
        }

        
        [When(@"I Click update selected recording")]
        public void WhenIClickUpdateSelectedRecording() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnUpdate = driver.FindElementByAccessibilityId("btnUpdate");
            btnUpdate.Click();
        }

        [Then(@"I should see the popup where I can edit a recording")]
        public void ThenIShouldSeeThePopupWhereICanEditARecording() {
            var driver = GuiDriver.GetOrCreateDriver();
            var updateSoundTitle = driver.FindElementByXPath("//Label[@Content='Update Sound']");
            Assert.IsTrue(updateSoundTitle.Displayed);
            Assert.Fail("UpdateSound popup window not found.");

        }
    }
}
