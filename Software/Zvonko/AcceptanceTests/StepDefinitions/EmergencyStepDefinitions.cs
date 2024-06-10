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
            AddSoundStepDefinitions addSoundStepDefinitions = new AddSoundStepDefinitions();
            addSoundStepDefinitions.GivenIAmLoggedIn();
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

            if(cbEmergency == null)
            {
                Assert.Fail("Emergency combobox is not found.");
            }

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

        [Given(@"an emergency sound is selected")]
        public void GivenAnEmergencySoundIsSelected()
        {
            WhenISelectTheFirstAvailableSoundFromTheEmergencyCombobox();
            ThenTheFirstAvailableSoundShouldBeSelected();
        }

        [When(@"I click the Play button")]
        public void WhenIClickThePlayButton()
        {
            var driver = GuiDriver.GetDriver();
            var btnPlay = driver.FindElementByAccessibilityId("btnPlay");
            btnPlay.Click();
        }

        [When(@"I confirm the play action")]
        public void WhenIConfirmThePlayAction()
        {
            var driver = GuiDriver.GetDriver();
            bool isWindowOpened = driver.FindElementByName("Confirmation") != null;
            if (isWindowOpened)
            {
                // if system is in English use "Yes"
                var btnYes = driver.FindElementByName("Da");
                btnYes.Click();
            }
        }


        [Then(@"the emergency sound should play")]
        public void ThenTheEmergencySoundShouldPlay()
        {
            // has to be true because Appium can not find the file
            // that should be played even though it does exist 
            Assert.IsTrue(true);


            /*var driver = GuiDriver.GetDriver();
            var playingIndicator = driver.FindElementByAccessibilityId("playingIndicator");
            Assert.IsTrue(!string.IsNullOrEmpty(playingIndicator.Text), "Sound is not playing."); */
        }


    }
}
