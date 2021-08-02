using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using responsivefight.Helpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Gherkin.Model;

namespace responsivefight.StepDefinitionFiles
{
    [Binding]
    public sealed class Covid19GameStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        public static string ReportPath;

        public Covid19GameStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;


        }


        [Given(@"the page is launched")]
        public void GivenThePageIsLaunched()
        {
            Herokuapp.MainPageObject.LauchPage();
        }

        [Given(@"entered the name ""(.*)""")]
        public void GivenEnteredTheName(string name)
        {
            //Random ran = new Random();
            //name= name + ran.Next(1,2).ToString();
            _scenarioContext["WarriorName"] = name;
            Herokuapp.MainPageObject.CreateWarrior(name);

        }

        [When(@"click on Create warrior")]
        public void WhenClickOnCreateWarrior()
        {
            Herokuapp.MainPageObject.ClickCreateWarrior();
        }

        [Then(@"warrior name can be seen on the link")]
        public void ThenWarriorNameCanBeSeenOnTheLink()
        {
            Assert.IsTrue(Herokuapp.MainPageObject.VerifyJourneyText(_scenarioContext["WarriorName"].ToString()), "Warrior Created Successfully");
        }

        [Given(@"click on Create warrior & go to CovidPage")]
        [When(@"click on Create warrior & go to CovidPage")]
        public void WhenClickOnCreateWarriorGoToCovidPage()
        {
            Herokuapp.MainPageObject.ClickCreateWarrior();
            Herokuapp.MainPageObject.StartYourJiourneyLink.Click();

        }

        [Then(@"it should be four battles")]
        public void ThenItShouldBeFourBattles()
        {
            Assert.IsTrue(Herokuapp.CovidPageObject.CheckAllBattlesExistence(), "Test Passed");
        }

        [When(@"take the news battle & failed")]
        [When(@"take the news battle")]
        public void WhenTakeTheNewsBattle()
        {
            Herokuapp.CovidPageObject.AreYouGameLnk.Click();

        }

        [Then(@"Verify the score in the LeaderBoard ""(.*)""")]
        public void ThenVerifyTheScoreInTheLeaderBoard(int expectedValue)
        {
            Assert.AreEqual(expectedValue, Herokuapp.NewsPageObject.TakeBattle(), "Test Passed");
        }

        [Then(@"It should navigate back to home page")]
        public void ThenItShouldNavigateBackToHomePage()
        {
            Herokuapp.NewsPageObject.TakeBattle(false);
            Assert.IsTrue(Herokuapp.NewsPageObject.VerifyHomePage(), "Test Passed");
        }

        #region Hooks
        [BeforeFeature]
        [Obsolete]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            Console.WriteLine("BeforeFeature");
        }

        [BeforeScenario]
        [Obsolete]
        public static void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario");
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterStep]
        [Obsolete]
        public static void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    scenario.AddScreenCaptureFromPath(Utilities.TakeScreenshot());
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    scenario.AddScreenCaptureFromPath(Utilities.TakeScreenshot());
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    scenario.AddScreenCaptureFromPath(Utilities.TakeScreenshot());
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    scenario.AddScreenCaptureFromPath(Utilities.TakeScreenshot());
                }
            }
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            string path = path1 + "Reports\\Results.html";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path, AventStack.ExtentReports.Reporter.Configuration.ViewStyle.Default);

            //htmlReporter.Configuration.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDown()
        {
            Herokuapp.MainPageObject.CloseBrowser();
            extent.Flush();
        }

        #endregion
    }
}
