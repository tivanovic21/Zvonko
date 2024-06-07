using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {

        [Given(@"I am on the Login screen")]
        public void GivenIAmOnTheLoginScreen()
        {
            var driver = GuiDriver.GetOrCreateDriver();
        }

        [Given(@"I press the Register here hyper link")]
        public void GivenIPressTheRegisterHereHyperLink()
        {
            var driver = GuiDriver.GetDriver();
            var btnRegister = driver.FindElementByAccessibilityId("txtRegisterLink");
            btnRegister.Click();
        }

        [Then(@"I should see the registration window")]
        public void ThenIShouldSeeTheRegistrationWindow()
        {
            var driver = GuiDriver.GetDriver();
            if (driver == null) GuiDriver.GetOrCreateDriver();

            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool isWindowOpened = driver.FindElementByName("Zvonko - Register") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Register";
            Assert.IsTrue(isWindowOpened && isCorrentTitle);
        }

        [Given(@"I am on the Registration screen")]
        public void GivenIAmOnTheRegistrationScreen()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            if(driver.Title != "Zvonko - Register")
            {
                GivenIAmOnTheLoginScreen();
                GivenIPressTheRegisterHereHyperLink();
                ThenIShouldSeeTheRegistrationWindow();
            }
        }

        [When(@"I enter registration details username (.*), password (.*) and school name (.*)")]
        public void WhenIEnterUsernameAndPasswordAndSchoolName(string username, string password, string schoolName)
        {
            var driver = GuiDriver.GetDriver();
            if(driver == null) driver = GuiDriver.GetOrCreateDriver();

            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");
            var txtSchoolName = driver.FindElementByAccessibilityId("txtSchoolName");

            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
            txtSchoolName.SendKeys(schoolName);
        }

        [When(@"I click on the Register button")]
        public void WhenIClickOnTheRegisterButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnRegister = driver.FindElementByAccessibilityId("btnRegister");
            btnRegister.Click();
        }

        [Then(@"I should see (.*) error message in registration")]
        public void ThenIShouldSeeFillOutAllFieldsErrorMessageForRegistration(string expectedMessage)
        {
            var driver = GuiDriver.GetDriver();
            var lblErrorMessage = driver.FindElementByAccessibilityId("lblErrorMessage");
            var actualMessage = lblErrorMessage.Text;
            Assert.AreEqual(actualMessage, expectedMessage);
        }

        [Then(@"I should be redirected to the login screen")]
        public void ThenIShouldBeRedirectedToTheLoginScreen()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool isWindowOpened = driver.FindElementByName("Zvonko - Login") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Login";
            Assert.IsTrue(isWindowOpened && isCorrentTitle);
        }


    }
}
