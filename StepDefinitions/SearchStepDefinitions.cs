using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTestOctoberBatch.StepDefinitions
{
    [Binding]
    public class SearchStepDefinitions
    {
        [Given(@"I am on google page")]
        public void GivenIAmOnGooglePage()
        {

        }

        [When(@"I search for Iphone(\d+)")]
        public void WhenISearchForIphone(int peter)
        {
            Console.WriteLine($"Peter gets paid: £{peter}");
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {

        }

        [Then(@"I see search result")]
        public void ThenISeeSearchResult()
        {

        }

        [Then(@"Iphone(\d+) is displayed in result page")]
        public void ThenIphoneIsDisplayedInResultPage(int p0)
        {

        }

        [When(@"I click Iphone(\d+) link")]
        public void WhenIClickIphoneLink(int p0)
        {

        }
    }
}
