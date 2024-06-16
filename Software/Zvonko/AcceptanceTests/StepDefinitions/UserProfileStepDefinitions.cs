
using AcceptanceTests.Support;
using DatabaseLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions {
    [Binding]
    public class UserProfileStepDefinitions {
        [Given(@"i am a user that is logged in")]
        public void GivenIAmAUserThatIsLoggedIn() {
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

        [When(@"i click the user profile button")]
        public void WhenIClickTheUserProfileButton() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnUserProfile");
            btnEmergency.Click();
        }

        [Then(@"i should see the user profile user control")]
        public void ThenIShouldSeeTheUserProfileUserControl() {
            var driver = GuiDriver.GetDriver();
            var lblAddEvent = driver.FindElementByName("Update Event Details");
            Assert.IsNotNull(lblAddEvent, "Add Event UserControl is not displayed");
        }



        [Given(@"logged correctly")]
        public void GivenImLoggedInsuccesfully() {
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

        [When(@"I click user profile button on the main screen")]
        public void WhenIClickTheUserProfileButtonOnTheMainScreen() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnUserProfile");
            btnEmergency.Click();
        }

        [When(@"I click the Cancel button on User profile")]
        public void WhenIClickTheCancelButtonOnUserProfile() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnCancel");
            btnEmergency.Click();
        }

        [Then(@"i should see main screen")]
        public void ThenIShouldSeeTheMainWindowAfterIClickCancel() {
            var driver = GuiDriver.GetDriver();
            var lblMainContent = driver.FindElementByName("Day you entered:");
            Assert.IsNotNull(lblMainContent, "Main content is not displayed");
        }

        [Given(@"I am logged succesfully")]
        public void GivenIAmLoggedSuccesfully() {
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
        [When(@"I go to user profile")]
        public void WhenIGoToUserProfile() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnAdd = driver.FindElementByAccessibilityId("btnUserProfile");
            btnAdd.Click();

        }
        [When(@"I clear username")]
        public void WhenIClearAllTheTextboxesInUserProfile() {
            var driver = GuiDriver.GetOrCreateDriver();

            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            txtUsername.Clear();

        }
        [When(@"I clear school name")]
        public void WhenIClearSchoolName() {
            var driver = GuiDriver.GetOrCreateDriver();

            var txtSchoolName = driver.FindElementByAccessibilityId("txtSchoolName");
            txtSchoolName.Clear();

        }
        [When(@"I clear mac adress")]
        public void WhenIClearMacAdress() {
            var driver = GuiDriver.GetOrCreateDriver();

            var txtMacAdress = driver.FindElementByAccessibilityId("txtMacAddress");
            txtMacAdress.Clear();

        }

        [When(@"I enter updated account details: username (.*), macAdress (.*) and school name (.*)")]
        public void WhenIEnterUpdatedAccount(string username, string macAdress, string schoolName) {
            var driver = GuiDriver.GetOrCreateDriver();

            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            txtUsername.SendKeys(username);

            var txtMacAddress = driver.FindElementByAccessibilityId("txtMacAddress");
            txtMacAddress.SendKeys(macAdress);

            var txtSchoolName = driver.FindElementByAccessibilityId("txtSchoolName");

            txtSchoolName.SendKeys(schoolName);
        }



        [When(@"I click Save")]
        public void WhenIClickSave() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnSave = driver.FindElementByAccessibilityId("btnSave");
            btnSave.Click();
        }



        [Then(@"I should see (.*) error message in update account screen")]
        public void ThenIShouldSeeErrorMessage(string expectedMessage) {
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

