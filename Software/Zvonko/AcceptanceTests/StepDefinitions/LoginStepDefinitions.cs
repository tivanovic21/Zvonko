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
    }
}
