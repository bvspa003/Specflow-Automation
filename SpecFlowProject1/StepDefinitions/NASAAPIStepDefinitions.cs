using AutomationFrameworkUtilities;
using AutomationFrameworkUtilities.APIUtil;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class NASAAPIStepDefinitions
    {
        NASAGeneratorUtil _nasaAPIUtil;
        APODResponse _response;
        string _endpoint;
        string _apiKey;
        string _imageUrl;
        ScenarioContext _scenarioContext;
        TestSettings _testSettings;

        public NASAAPIStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _testSettings = _scenarioContext.Get<TestSettings>("Settings");
            _nasaAPIUtil = new NASAGeneratorUtil(_testSettings.NASAEndpoint);
        }
        [Given(@"the NASA API endpoint ""([^""]*)"" is provided")]
        public void GivenTheNASAAPIEndpointIsProvided(string p0)
        {
            _endpoint = p0;
        }

        [Given(@"a valid API key is possessed")]
        public void GivenAValidAPIKeyIsPossessed()
        {
            _apiKey = _testSettings.NASAKey;
        }

        [When(@"a GET request to fetch the Astronomy Picture of the Day is sent")]
        public void WhenAGETRequestToFetchTheAstronomyPictureOfTheDayIsSent()
        {
            var parameters = new Dictionary<string, string>
            {
                { "api_key", _apiKey }
            };
            _response = _nasaAPIUtil.Get<APODResponse>(_endpoint, parameters);
        }

        [Then(@"the response should have the title and explanation of the picture contained")]
        public void ThenTheResponseShouldHaveTheTitleAndExplanationOfThePictureContained()
        {
            var apodResponse = _response;
            Console.WriteLine($"Title: {apodResponse.Title}");
            Console.WriteLine($"Explanation: {apodResponse.Explanation}");
        }

        [Then(@"the URL of the picture should be contained in the response")]
        public void ThenTheURLOfThePictureShouldBeContainedInTheResponse()
        {
            var apodResponse = _response;
            Console.WriteLine($"URL: {apodResponse.Url}");
            _imageUrl = apodResponse.Url;
        }

        [Then(@"the URL should be opened in the browser and waited for three seconds")]
        public void ThenTheURLShouldBeOpenedInTheBrowserAndWaitedForThreeSeconds()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = _imageUrl,
                UseShellExecute = true
            });
        }

        [Then(@"the image generated should be downloaded")]
        public void ThenTheImageGeneratedShouldBeDownloaded()
        {
            Assert.IsNotNull(_imageUrl, "Image URL is null");

            using (WebClient client = new WebClient())
            {
                string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "APOD.jpg");
                client.DownloadFile(_imageUrl, fileName);
                Console.WriteLine($"Image downloaded to: {fileName}");
            }
        }
    }
    public class APODResponse
    {
        public string Title { get; set; }
        public string Explanation { get; set; }
        public string Url { get; set; }
    }
}
