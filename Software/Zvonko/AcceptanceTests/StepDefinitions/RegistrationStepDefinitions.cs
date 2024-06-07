using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            driver.SwitchTo().Window(driver.WindowHandles.First());
            bool isWindowOpened = driver.FindElementByName("Zvonko - Register") != null;
            bool isCorrentTitle = driver.Title == "Zvonko - Register";
            Assert.IsTrue(isWindowOpened && isCorrentTitle);
        }
    }
}
