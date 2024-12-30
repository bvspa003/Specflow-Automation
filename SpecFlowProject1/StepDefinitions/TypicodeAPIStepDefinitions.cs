using AutomationFrameworkUtilities;
using AutomationFrameworkUtilities.APIUtil;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class TypicodeAPIStepDefinitions
    {
        TypicodeUtil _typicodeUtil;
        Post _post;
        RestResponse _response;
        ScenarioContext _scenarioContext;
        TestSettings _testSettings;

        public TypicodeAPIStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _testSettings = _scenarioContext.Get<TestSettings>("Settings");
            _typicodeUtil = new TypicodeUtil(_testSettings.TypicodeEndpoint);
        }

        [Given(@"a new post is provided with title ""([^""]*)"", body ""([^""]*)"", userId (.*)")]
        public void GivenANewPostIsProvidedWithTitleBodyUserId(string title, string body, int userId)
        {
            _post = new Post
            {
                Title = title,
                Body = body,
                UserId = userId,
                Id = 101
            };
        }

        [When(@"a POST request is sent to ""([^""]*)""")]
        public void WhenAPOSTRequestIsSentTo(string endpoint)
        {
            _response = _typicodeUtil.Post(endpoint, _post);
            Console.WriteLine(_response.Content);
            _post = JsonConvert.DeserializeObject<Post>(_response.Content);
        }

        [Then(@"the response should have the title ""([^""]*)"" and body ""([^""]*)"" contained")]
        public void ThenTheResponseShouldHaveTheTitleAndBodyContained(string title, string body)
        {
            Assert.AreEqual(_post.Title, title);
            Assert.AreEqual(_post.Body, body);
        }

        [Given(@"the post ID (.*) is provided")]
        public void GivenThePostIDIsProvided(int postId)
        {
            _post = new Post { Id = postId };
        }

        [When(@"a GET request to ""([^""]*)"" is sent")]
        public void WhenAGETRequestToIsSent(string endpoint)
        {
            _response = _typicodeUtil.Get(endpoint);
            Console.WriteLine(_response.Content);
            _post = JsonConvert.DeserializeObject<Post>(_response.Content);
        }

        [Then(@"the response should have the id (.*) and userId (.*) contained")]
        public void ThenTheResponseShouldHaveTheIdAndUserIdContained(int id, int userId)
        {
            Assert.AreEqual(_post.Id, id);
            Assert.AreEqual(_post.UserId, userId);
        }

        [Given(@"an updated post is provided with title ""([^""]*)"", body ""([^""]*)"", userId (.*)")]
        public void GivenAnUpdatedPostIsProvidedWithTitleBodyUserId(string title, string body, int userId)
        {
            _post = new Post
            {
                Title = title,
                Body = body,
                UserId = userId,
                Id = 21
            };
        }

        [When(@"a PUT request to ""([^""]*)"" is sent")]
        public void WhenAPUTRequestToIsSent(string endpoint)
        {
            _response = _typicodeUtil.Put(endpoint, _post);
            Console.WriteLine(_response.Content);
            _post = JsonConvert.DeserializeObject<Post>(_response.Content);
        }

/*        [Then(@"the response should have the title ""([^""]*)"" and body ""([^""]*)"" contained")]
        public void ThenTheResponseShouldHaveTheTitleAndBodyContained(string p0, string p1)
        {
            throw new PendingStepException();
        }*/

        [When(@"a DELETE request to ""([^""]*)"" is sent")]
        public void WhenADELETERequestToIsSent(string endpoint)
        {
            var statusCode = _typicodeUtil.Delete(endpoint);
            Assert.IsTrue(statusCode == HttpStatusCode.NoContent || statusCode == HttpStatusCode.OK);
        }

        [Then(@"the response should be found empty")]
        public void ThenTheResponseShouldBeFoundEmpty()
        {
            Assert.IsTrue(_response?.Content == null || _response.Content == String.Empty);
        }
    }
}
