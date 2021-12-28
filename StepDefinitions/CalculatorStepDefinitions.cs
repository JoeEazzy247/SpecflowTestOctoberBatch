using NUnit.Framework;
using SpecflowTestOctoberBatch.Extensions;

namespace SpecflowTestOctoberBatch.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        int? actualResult;
        ScenarioContext? scenarioContext;
        private readonly CustomExtensions customExtensions;

        public CalculatorStepDefinitions(
            ScenarioContext? _scenarioContext, CustomExtensions customExtensions)
        {
            scenarioContext = _scenarioContext;
            this.customExtensions = customExtensions;
        }

        [Given("the '(.*)' number is (.*)")]
        public void GivenTheFirstNumberIs(string key, int number1)
        {
            customExtensions.AddNumbersToContext(key, number1);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            actualResult = customExtensions.GetNumbersFromContext("first") +
                customExtensions.GetNumbersFromContext("second");
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Given(@"the '(.*)' number is")]
        public void GivenTheFirstNumberIs(string key, Table table)
        {
            customExtensions.AddNumbersToContext(key, int.Parse(table.Rows[0]["Value"]));
        }
    }
}