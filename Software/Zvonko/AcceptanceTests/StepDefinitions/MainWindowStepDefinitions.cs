using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinitions {
    [Binding]
    public class MainWindowStepDefinitions {
        [Given(@"Im logged in")]
        public void GivenImLoggedIn() {
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

            [Then(@"Main is loaded")]
            public void ThenMainIsLoaded() {
                var driver = GuiDriver.GetDriver();
                var lblAddEvent = driver.FindElementByAccessibilityId("btnMonday");
                Assert.IsNotNull(lblAddEvent, "Add Event UserControl is not displayed");
        }



        [Given(@"Im logged in into the application")]
        public void GivenImLoggedInIntoTheApplication() {
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

        [When(@"I click monday")]
        public void WhenIClickMonday() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnMonday = driver.FindElementByAccessibilityId("btnMonday");
            btnMonday.Click();
        }

        [When(@"I select an event")]
        public void WhenISelectAnEvent() {
            var driver = GuiDriver.GetOrCreateDriver();
            var dataGridView = driver.FindElementByAccessibilityId("dgRecordings");

            var firstRow = dataGridView.FindElementByXPath("//DataItem[1]");
            firstRow.Click();
        }

        [When(@"I press remove button")]
        public void WhenIPressRemoveButton() {
            var driver = GuiDriver.GetOrCreateDriver();
            var btnRemove = driver.FindElementByAccessibilityId("btnRemove");
            btnRemove.Click();
        }

        [Then(@"Event is removed")]
        public void ThenEventIsRemoved() {
            var driver = GuiDriver.GetOrCreateDriver();
            driver.SwitchTo().Window(driver.WindowHandles.First());

            bool btnOk = driver.FindElementByAccessibilityId("2") != null;
            Assert.IsTrue(btnOk);
        }








    }

    } 

