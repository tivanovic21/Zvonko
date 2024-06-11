using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class LiveBroadcastStepDefinitions
    {
        [When(@"I click the Live Broadcast button")]
        public void WhenIClickTheLiveBroadcastButton()
        {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnLiveBroadcast = driver.FindElementByAccessibilityId("btnLiveBroadcast");
            btnLiveBroadcast.Click();
        }

        [Then(@"I should see the Live Broadcast screen")]
        public void ThenIShouldSeeTheLiveBroadcastScreen()
        {
            var driver = GuiDriver.GetDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool isWindowOpened = driver.FindElementByAccessibilityId("screenLiveBroadcast") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Live Broadcast";
            Assert.IsTrue(isWindowOpened && isCorrentTitle);
        }

        [Given(@"I am on the Live Broadcast screen")]
        public void GivenIAmOnTheLiveBroadcastScreen()
        {
            AddSoundStepDefinitions ssd = new AddSoundStepDefinitions();
            ssd.GivenIAmLoggedIn();
            WhenIClickTheLiveBroadcastButton();
            ThenIShouldSeeTheLiveBroadcastScreen();
        }

        [When(@"I close the screen")]
        public void WhenICloseTheScreen()
        {
            var driver = GuiDriver.GetDriver();
            var currentWindowHandle = driver.CurrentWindowHandle;
            var windowHandles = driver.WindowHandles;

            driver.Close();
            var remainingWindowHandle = windowHandles.First(handle => handle != currentWindowHandle);
            driver.SwitchTo().Window(remainingWindowHandle);
        }

        [Then(@"I should be on the main screen")]
        public void ThenIShouldBeOnTheMainScreen()
        {
            var driver = GuiDriver.GetDriver();
            if (driver.WindowHandles.Count == 0)
            {
                driver = GuiDriver.GetOrCreateDriver();
            }

            var mainWindowHandle = driver.WindowHandles.FirstOrDefault();
            driver.SwitchTo().Window(mainWindowHandle);

            bool isWindowOpened = driver.FindElementByName("Zvonko - Main") != null;
            bool isCorrectTitle = driver.Title == "Zvonko - Main";
            Assert.IsTrue(isWindowOpened && isCorrectTitle);
        }


    }
}
