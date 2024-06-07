using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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

    }
}
