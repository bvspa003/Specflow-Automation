using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AutomationFrameworkUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;


namespace SpecFlowTestSuite.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        ScenarioContext _scenarioContext;
        FeatureContext _featureContext;
        WebDriverCreator _webDriverCreator;
        TestSettings _settings;
        ElementInteractor _elementInteractor;
        ScreenshotHelper _screenshotHelper;
        Waits _waits;
        NavigationHelper _navigationHelper;
        BrowserWindowHelper _browserWindowHelper;

        public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ReportHelper.InitializeReport();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ReportHelper.extent.Flush();
        }
        [BeforeFeature]
        public static void BeforeFeatureStart(FeatureContext featureContext)
        {
            ReportHelper.featureName = ReportHelper.extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenarioStart(ScenarioContext scenarioContext)
        {
            ReportHelper.scenario = ReportHelper.featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }
        [BeforeScenario]
        //[Scope()]
        public void Setup()
        {
            _settings = ConfigReader.GetConfig("Settings.json");
            _webDriverCreator = WebDriverCreator.Instance;
            HashSet<string> allowedFeatures = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Login", "Product", "Cart", "Checkout" };
            if (allowedFeatures.Contains(_featureContext.FeatureInfo.Title))
            {
                var driver = _webDriverCreator.GetDriver(_settings.Browser, _settings.Headless, _settings.Incognito, _settings.AcceptInsecureCerts);


                _elementInteractor = new ElementInteractor(driver);
                _waits = new Waits(driver, TimeSpan.FromSeconds(10));
                _navigationHelper = new NavigationHelper(driver);
                _browserWindowHelper = new BrowserWindowHelper(driver);

                _scenarioContext.Set(driver, "WebDriver");
                _scenarioContext.Set(_elementInteractor, "ElementInteractor");
                _scenarioContext.Set(_waits, "Waits");

                _scenarioContext.Set(_navigationHelper, "NavigationHelper");
                _scenarioContext.Set(_browserWindowHelper, "BrowserWindowHelper");

                _screenshotHelper = new ScreenshotHelper(driver);
            }
            if ((_scenarioContext.ScenarioInfo.Tags).Contains("ignore"))
            {
                Assert.Ignore("Ignored due to @ignore tag");
            }
            _scenarioContext.Set(_settings, "Settings");
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
                .WriteTo.File($"logs\\{_scenarioContext.ScenarioInfo.Tags.First()}.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        [AfterScenario]
        public void Teardown()
        {
            Thread.Sleep(1000);
            Log.Information($"Ending scenario: {_scenarioContext.ScenarioInfo.Title}");
            _webDriverCreator.QuitDriver();
        }
        [BeforeStep]
        public void BeforeStep()
        {
            Log.Information($"Initializing Step Definition for {ScenarioStepContext.Current.StepInfo.Text}");
        }
        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (scenarioContext.TestError == null)
            {
                Log.Information($"Definition for {ScenarioStepContext.Current.StepInfo.Text} has run successfully");
                if (stepType.Equals("Given"))
                    ReportHelper.scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType.Equals("When"))
                    ReportHelper.scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType.Equals("Then"))
                    ReportHelper.scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType.Equals("And"))
                    ReportHelper.scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (scenarioContext.TestError != null)
            {
                var screenshotName = $"{scenarioContext.ScenarioInfo.Tags.First()}";
                Log.Error(ScenarioStepContext.Current.StepInfo.Text);
                Log.Fatal($"TEST FAILED: Please Refer to the screenshot titled {screenshotName}");
                var screenshotPath = _screenshotHelper.TakeandFetchScreenshotPath(screenshotName);
                var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();

                if (stepType.Equals("Given"))
                    ReportHelper.scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(scenarioContext.TestError.Message, mediaEntity);
                else if (stepType.Equals("When"))
                    ReportHelper.scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(scenarioContext.TestError.Message, mediaEntity);
                else if (stepType.Equals("Then"))
                    ReportHelper.scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(scenarioContext.TestError.Message, mediaEntity);
                else if (stepType.Equals("And"))
                    ReportHelper.scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(scenarioContext.TestError.Message, mediaEntity);

            }
        }
    }
}

//file path =currentdirectory+"$path"+"report.html";
//replca e$path , value
