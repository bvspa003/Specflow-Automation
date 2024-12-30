using AutomationFrameworkUtilities;
using AutomationFrameworkUtilities.APIUtil;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using static SpecFlowTestSuite.StepDefinitions.JokeAPIStepDefinitions;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class JokeAPIStepDefinitions
    {
        JokeGeneratorUtil _jokeUtil;
        JokeResponse _response;
        string _endpoint;
        TestSettings _testSettings;
        ScenarioContext _scenarioContext;
        public JokeAPIStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _testSettings = _scenarioContext.Get<TestSettings>("Settings");
            _jokeUtil = new JokeGeneratorUtil(_testSettings.JokeEndpoint);
        }
        [Given(@"the JokeAPI endpoint ""([^""]*)"" is provided")]
        public void GivenTheJokeAPIEndpointIsProvided(string p0)
        {
            _endpoint = p0;
        }

        [When(@"a GET request to fetch a random joke is sent")]
        public void WhenAGETRequestToFetchARandomJokeIsSent()
        {
            _response = _jokeUtil.Get<JokeResponse>(_endpoint);
            Assert.IsNotNull(_response, "Response is null");
        }

        [Then(@"the response should have a joke contained")]
        public void ThenTheResponseShouldHaveAJokeContained()
        {
            var jokeResponse = _response;
            if (jokeResponse.Type == "single")
            {
                Console.WriteLine($"Joke: {jokeResponse.Joke}");
            }
            else if (jokeResponse.Type == "twopart")
            {
                Console.WriteLine($"Setup: {jokeResponse.Setup}");
                Console.WriteLine($"Delivery: {jokeResponse.Delivery}");
            }
        }

        [When(@"a GET request to fetch a programming joke is sent")]
        public void WhenAGETRequestToFetchAProgrammingJokeIsSent()
        {
            _response = _jokeUtil.Get<JokeResponse>(_endpoint);
            Assert.IsNotNull(_response, "Response is null");
        }

        [Then(@"the response should have a programming joke contained")]
        public void ThenTheResponseShouldHaveAProgrammingJokeContained()
        {
            var jokeResponse = _response;
            if (jokeResponse.Type == "single")
            {
                Console.WriteLine($"Joke: {jokeResponse.Joke}");
            }
            else if (jokeResponse.Type == "twopart")
            {
                Console.WriteLine($"Setup: {jokeResponse.Setup}\n");
                Console.WriteLine($"Delivery: {jokeResponse.Delivery}");
            }
        }
    }
    public class JokeResponse
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public string Joke { get; set; }
        public string Setup { get; set; }
        public string Delivery { get; set; }
    }
}
