using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowTestOctoberBatch.Base;
using SpecflowTestOctoberBatch.Drivers;
using SpecflowTestOctoberBatch.Extensions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTestOctoberBatch.StepDefinitions
{
    [Binding]
    public class DemoQaExamplStepDefinitions : DriverHelper
    {
        string url => "http://demoqa.com";

        [Given(@"I navigate to demoQa page")]
        public void GivenINavigateToDemoQaPage()
        {
            driver?.Navigate().GoToUrl(url);
        }

        [When(@"I click Elements")]
        public void WhenIClickElements()
        {
            var element = driver?.FindElement(
                By.XPath(
                    "//div[contains(@class, 'card mt-')][.='Elements']"));
            driver?.ClickElement(element, true);
        }

        [When(@"I click Text Box")]
        public void WhenIClickTextBox()
        {
            var TextBox = 
                driver?.FindElement(By.XPath("//li[@id='item-0'][.='Text Box']"));
            Thread.Sleep(1000);
            TextBox?.Click();
            Thread.Sleep(1000);
        }


        [When(@"I enter the following data")]
        public void WhenIEnterTheFollowingData(Table table)
        {
            dynamic tabledata = table.CreateDynamicInstance();
            driver?.FindElement(By.Id("userName"))
                .SendKeys(tabledata.FullName);
            driver?.FindElement(By.Id("userEmail"))
                .SendKeys(tabledata.Email);
            driver?.FindElement(By.Id("currentAddress"))
                .SendKeys(tabledata.CurrentAddress);
            driver?.FindElement(By.Id("permanentAddress"))
                .SendKeys(tabledata.ParmanentAddress);
        }

        [When(@"I click submit button")]
        public void WhenIClickSubmitButton()
        {
            driver?.FindElement(By.Id("submit")).Click();
        }

        [Then(@"following data has been added")]
        public void ThenFollowingDataHasBeenAdded(Table table)
        {
            dynamic tabledata = table.CreateDynamicInstance();
            var result = 
                driver?.FindElements(By.XPath("//div[@id='output']//p"));
            var resultVal = result?[0].Text;
            var resultVal2 = result?[0].Text.Split(":").LastOrDefault();
            var resultVal3 = result?[0].Text.Split(":").FirstOrDefault();

            Assert.Multiple(()=>
            {
                Assert.AreEqual(tabledata.FullName, result?[0].Text.Split(":")[1]);
                Assert.AreEqual(tabledata.Email, result?[1].Text.Split(":")[1]);
                Assert.AreEqual(tabledata.CurrentAddress, result?[2].Text.Split(":")[1]);
                Assert.AreEqual(tabledata.ParmanentAddress, result?[3].Text.Split(":")[1]);
            });
        }
    }
}
