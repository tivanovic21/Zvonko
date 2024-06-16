using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class UpdateEventStepDefinitions
    {
        [Given(@"log in good")]
        public void GivenIAmAUserThatIsLoggedIn()
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
        
        [When(@"I click monday now")]
        public void WhenISelectMonday() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnMonday");
            btnEmergency.Click();
        }

        [When(@"i select a event i want to update")]
        public void WhenISelectEvent() {
            var driver = GuiDriver.GetOrCreateDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgRecordings");

            var firstRow = dataGridView.FindElementByXPath("//DataItem[1]");
            firstRow.Click();
        }

        [When(@"i click update event")]
        public void WhenIClickUpdateEvent() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnUpdate");
            btnEmergency.Click();
        }

        [Then(@"i should see the update event user control")]
        public void ThenIShouldSeeTheUpdateEventUserControl()
        {
            var driver = GuiDriver.GetDriver();
            var lblAddEvent = driver.FindElementByName("Update event");
            Assert.IsNotNull(lblAddEvent, "Add update event is not displayed");
        }

        [Given(@"logged")]
        public void GivenLoggedCorrectly()
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

        [When(@"I click monday in dg")]
        public void WhenIClickMonday() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnMonday");
            btnEmergency.Click();
        }
        [When(@"i select a event")]
        public void WhenISelectEventNow() {
            var driver = GuiDriver.GetOrCreateDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgRecordings");

            var firstRow = dataGridView.FindElementByXPath("//DataItem[1]");
            firstRow.Click();
        }

        [When(@"i click update event now")]
        public void WhenIClickUpdateEventButton() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnUpdate");
            btnEmergency.Click();
        }

        [When(@"I click cancel update")]
        public void WhenIClickCacncel()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnCancel");
            btnEmergency.Click();
        }

        [Then(@"i should see main screen after canceling")]
        public void ThenIShouldSeeMainScreen()
        {
            var driver = GuiDriver.GetDriver();
            var lblMainContent = driver.FindElementByName("Day you entered:");
            Assert.IsNotNull(lblMainContent, "Main content is not displayed");
        }


        [Given(@"logged into app")]
        public void GivenImLoggedIntoApp() {
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

        [When(@"I click monday button")]
        public void WhenIClickMondayButton() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnMonday");
            btnEmergency.Click();
        }

        [When(@"select event")]
        public void WhenIselectEvent() {
            var driver = GuiDriver.GetOrCreateDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgRecordings");

            var firstRow = dataGridView.FindElementByXPath("//DataItem[1]");
            firstRow.Click();
        }

        [When(@"i click update button")]
        public void WhenIClickUpdateButton() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnUpdate");
            btnEmergency.Click();
        }

        [When(@"I click save")]
        public void WhenIClickSaveButton() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnUpdate");
            btnEmergency.Click();
        }


        [Then(@"error popup")]
        public void ThenIShouldSeeErrorPopup() {
            var driver = GuiDriver.GetOrCreateDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());

            bool btnOk = driver.FindElementByAccessibilityId("2") != null;
            Assert.IsTrue(btnOk);

            var okButton = driver.FindElement(By.XPath("//Button[contains(@Name, 'OK')]"));
            okButton.Click();
            driver.CloseApp();
        }




        [Given(@"I am on main screen")]
        public void GivenImOnMainScreen() {
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

        [When(@"I click button monday to grab all the event")]
        public void WhenIClickMondayButtonToHaveAllEvents() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnMonday");
            btnEmergency.Click();
        }

        [When(@"i select a event for update")]
        public void WhenISelectAEventForUpdate() {
            var driver = GuiDriver.GetOrCreateDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgRecordings");

            var firstRow = dataGridView.FindElementByXPath("//DataItem[1]");
            firstRow.Click();
        }

        [When(@"i click update")]
        public void WhenIClickUpdate() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnUpdate");
            btnEmergency.Click();
        }

        [When(@"I clear name")]
        public void WhenIClearAllTheTextboxesInUserProfile() {
            var driver = GuiDriver.GetOrCreateDriver();

            var txtUsername = driver.FindElementByAccessibilityId("txtNameOfEvent");
            txtUsername.Clear();

        }
        [When(@"I clear description")]
        public void WhenIClearAllTheTextboxesInUserProfile2() {
            var driver = GuiDriver.GetOrCreateDriver();

            var txtSchoolName = driver.FindElementByAccessibilityId("txtDescriptionOfEvent");
            txtSchoolName.Clear();

        }
        [When(@"I clear startingTime")]
        public void WhenIClearMacAdress() {
            var driver = GuiDriver.GetOrCreateDriver();

            var txtMacAdress = driver.FindElementByAccessibilityId("txtStartingTime");
            txtMacAdress.Clear();

        }

        [When(@"I enter updated event details: name (.*), description (.*) and starting time (.*)")]
        public void WhenIEnterNewEventDetails(string name, string description, string startingTime) {
            var driver = GuiDriver.GetOrCreateDriver();

            var txtName = driver.FindElementByAccessibilityId("txtNameOfEvent");
            txtName.SendKeys(name);

            var txtDescription = driver.FindElementByAccessibilityId("txtDescriptionOfEvent");
            txtDescription.SendKeys(description);

            var txtStartingTime = driver.FindElementByAccessibilityId("txtStartingTime");
            txtStartingTime.SendKeys(startingTime);
        }

        [When(@"I select the recording aswell")]
        public void WhenISelectARecording() {
            var driver = GuiDriver.GetOrCreateDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgRecordings");

            var firstRow = dataGridView.FindElementByXPath("//DataItem[1]");
            firstRow.Click();
        }


        [When(@"I click on the update button")]
        public void WhenIClickOnTheUpdateButton() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnUpdate");
            btnEmergency.Click();
        }

       [Then(@"I should see (.*) error message in update event screen")]
        public void ThenIShouldSeeAnErrorMessage(string expectedMessage) {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            var messageBoxTextElement = driver.FindElement(By.XPath("//Text"));
            string actualMessage = messageBoxTextElement.Text.Trim();
            Assert.AreEqual(expectedMessage, actualMessage);

            var okButton = driver.FindElement(By.XPath("//Button[contains(@Name, 'OK')]"));
            okButton.Click();
            driver.CloseApp();
        }
    }
}
