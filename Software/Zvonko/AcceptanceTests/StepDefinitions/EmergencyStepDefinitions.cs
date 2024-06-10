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
    public class EmergencyStepDefinitions
    {
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            bool isWindowOpened = driver.FindElementByName("Zvonko - Login") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Login";
            if (isWindowOpened && isCorrentTitle)
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

        [When(@"I click the Emergency button")]
        public void WhenIClickTheEmergencyButton()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnEmergency = driver.FindElementByAccessibilityId("btnEmergency");
            btnEmergency.Click();
        }

        [Then(@"I should see the Emergency screen")]
        public void ThenIShouldSeeTheEmergencyScreen()
        {
            var driver = GuiDriver.GetDriver();
            var lblEmergency = driver.FindElementByName("EMERGENCY");
            Assert.IsNotNull(lblEmergency, "Emergency UserControl is not displayed");
        }

        [Given(@"I am logged in and on Emergency screen")]
        public void GivenIAmLoggedInAndOnEmergencyScreen()
        {
            GivenIAmLoggedIn();
            WhenIClickTheEmergencyButton();
            ThenIShouldSeeTheEmergencyScreen();
        }

        [When(@"I select the first available sound from the emergency combobox")]
        public void WhenISelectTheFirstAvailableSoundFromTheEmergencyCombobox()
        {
            var driver = GuiDriver.GetDriver();
            var cbEmergency = driver.FindElementByAccessibilityId("cbEmergency");

            cbEmergency.Click();
            cbEmergency.SendKeys(Keys.Enter);
        }

        [Then(@"the first available sound should be selected")]
        public void ThenTheFirstAvailableSoundShouldBeSelected()
        {
            var driver = GuiDriver.GetDriver();
            var cbEmergency = driver.FindElementByAccessibilityId("cbEmergency");

            string selectedText = cbEmergency.Text;

            Assert.IsTrue(!string.IsNullOrWhiteSpace(selectedText), "Selected item text is empty.");
        }

    }
}
