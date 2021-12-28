using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowTestOctoberBatch.Drivers;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecflowTestOctoberBatch.Base
{
    [Binding]
    public class Hooks1 : DriverHelper
    {
        ChromeOptions? options;

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            options = new ChromeOptions();
            options.AddArguments("start-maximized", 
                "incognito");
            driver = new ChromeDriver(options);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Thread.Sleep(2000);
            driver?.Quit();
            using (var process = Process.GetCurrentProcess())
            {
                if (process.ToString() == "chromedriver")
                {
                    process.Kill();
                } 
                else if(process.ToString() == "geckodriver")
                {
                    process.Kill();
                }
            }
            driver?.Dispose(); driver = null;
        }
    }
}