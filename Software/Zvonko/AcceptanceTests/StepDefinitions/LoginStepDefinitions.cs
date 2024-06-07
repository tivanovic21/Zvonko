using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Linq;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        [AfterScenario]
        public void CloseApplication()
        {
            GuiDriver.Dispose();
        }

        [When(@"I launch the application")]
        public void WhenILaunchTheApplication()
        {
            var driver = GuiDriver.GetOrCreateDriver();
        }

        [Then(@"I should see the login window")]
        public void ThenIShouldSeeTheLoginWindow()
        {
            var driver = GuiDriver.GetDriver();
            bool isWindowOpened = driver.FindElementByName("Zvonko - Login") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Login";
            Assert.IsTrue(isWindowOpened && isCorrentTitle);
        }

        [Given(@"I am on the login form")]
        public void GivenIAmOnTheLoginForm()
        {
            var driver = GuiDriver.GetOrCreateDriver();
        }

        [When(@"I enter username (.*) and password (.*)")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            var driver = GuiDriver.GetDriver();
            var txtUsername = driver.FindElementByAccessibilityId("txtUsername");
            var txtPassword = driver.FindElementByAccessibilityId("txtPassword");

            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
        }

        [When(@"I click on the Login button")]
        public void WhenIClickOnTheLoginButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnLogin = driver.FindElementByAccessibilityId("btnLogin");
            btnLogin.Click();
        }

        [Then(@"I should see (.*) error message")]
        public void ThenIShouldSeeErrorMessage(string expectedMessage)
        {
            var driver = GuiDriver.GetDriver();
            var lblErrorMessage = driver.FindElementByAccessibilityId("lblErrorMessage");
            var actualMessage = lblErrorMessage.Text;
            Assert.AreEqual(actualMessage, expectedMessage);
        }

    }
}
