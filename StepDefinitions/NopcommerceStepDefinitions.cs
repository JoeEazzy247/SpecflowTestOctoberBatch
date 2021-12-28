using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecflowTestOctoberBatch.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTestOctoberBatch.StepDefinitions
{
    [Binding]
    public class NopcommerceStepDefinitions : DriverHelper
    {
        private string url => 
            "https://admin-demo.nopcommerce.com/login?ReturnUrl=%2Fadmin%2F";
        [Given(@"I am on nopcommerce page")]
        public void GivenIAmOnNopcommercePage()
        {
            driver?.Navigate().GoToUrl(url);
        }

        [When(@"I click login")]
        public void WhenIClickLogin()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(20));
            wait.Until(x => x.FindElement(By.XPath("//button[@type='submit']"))).Click();

            new Actions(driver).SendKeys(Keys.Tab)
                .SendKeys(Keys.Enter).Build().Perform();
            wait.Until(x =>
            x.FindElement(By.XPath("(//li[@class='nav-item has-treeview'][3])[1]"))).Click();

            ((IJavaScriptExecutor)driver)
                .ExecuteScript("arguments[0].click();", 
                driver.FindElement(By.XPath("//li[@class='nav-item']/a[@href='/Admin/CustomerRole/List']")));
            Thread.Sleep(3000);
        }
    }
}
