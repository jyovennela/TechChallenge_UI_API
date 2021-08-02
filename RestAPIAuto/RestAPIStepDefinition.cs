using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RestAPIAuto.StepDefinitionFiles
{
    [Binding]
    public sealed class RestAPIStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public RestAPIStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Rest API End Point")]
        [When(@"invoke the GET Method")]
        [Then(@"verify the response")]
        public void ThenVerifyTheResponse()
        {
            Assert.IsTrue(RestAPIMethods.GetLeaderBoardUsers("Test") || RestAPIMethods.VerifyStatusCode(200), "Test Failed");
        }

        [When(@"invoke the GET Method to verify the score order")]
        public void WhenInvokeTheGETMethodToVerifyTheScoreOrder()
        {
            //ScenarioContext.Current.Pending();
        }



        [Then(@"the score should be in descending order")]
        public void ThenTheScoreShouldBeInDescendingOrder()
        {
            Assert.IsTrue(RestAPIMethods.CheckLeaderBoardScoreOrder(), "Test Failed");
        }

        [When(@"invoke the post method with a valid body")]
        public void WhenInvokeThePostMethodWithAValidBody()
        {

        }

        [Then(@"duplicate data not submitted successfully ""(.*)"", (.*)")]
        [Then(@"the data not submitted successfully ""(.*)"", (.*)")]
        [Then(@"the data submitted successfully ""(.*)"", (.*)")]
        public void ThenTheDataSubmittedSuccessfully(string username, int? scorevalue)
        {
            if (ScenarioStepContext.Current.StepInfo.Text.Contains("duplicate"))
                Assert.IsTrue(RestAPIMethods.ValidatePostMethod(username, scorevalue, true), "Test Failed");
            else
                Assert.IsTrue(RestAPIMethods.ValidatePostMethod(username, scorevalue, false), "Test Failed");
        }

        [Then(@"data should not be submit successfully ""(.*)"", (.*)")]
        [Then(@"data should be added successfully ""(.*)"", (.*)")]
        [Then(@"data should be updated successfully ""(.*)"", (.*)")]
        public void ThenDataShouldBeUpdatedSuccessfully(string username, int scorevalue)
        {
            if (ScenarioStepContext.Current.StepInfo.Text.Contains("not"))
                Assert.IsTrue(RestAPIMethods.ValidatePutMethod(username, scorevalue, true), "Test Failed");
            if (ScenarioStepContext.Current.StepInfo.Text.Contains("updated"))
                Assert.IsTrue(RestAPIMethods.ValidatePutMethod(username, scorevalue), "Test Failed");
            if (ScenarioStepContext.Current.StepInfo.Text.Contains("added"))
                Assert.IsTrue(RestAPIMethods.ValidatePutMethod(username, scorevalue, isExistUser: false), "Test Failed");
        }

        [When(@"invoke the Delete method with a valid delete-key")]
        [When(@"invoke the Delete method without a delete-key")]
        public void WhenInvokeTheDeleteMethodWithoutADelete_Key()
        {

        }

        [Then(@"the response staus should be success")]
        [Then(@"the response staus should be unauthorized")]
        public void ThenTheResponseStausShouldBeUnauthorized()
        {
            if (ScenarioStepContext.Current.StepInfo.Text.Contains("success"))
                Assert.IsTrue(RestAPIMethods.VerifyDeleteResponseStatus(true), "Test Failed");
            Assert.IsTrue(RestAPIMethods.VerifyDeleteResponseStatus(), "Test Failed");
        }
                
    }
}
