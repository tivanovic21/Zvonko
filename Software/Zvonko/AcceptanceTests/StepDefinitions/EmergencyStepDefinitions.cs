using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class EmergencyStepDefinitions
    {
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
    }
}
