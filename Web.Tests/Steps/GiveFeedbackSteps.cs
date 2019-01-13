using System;
using TechTalk.SpecFlow;

namespace Web.Tests.Steps
{
    [Binding]
    public class GiveFeedbackSteps
    {
        [Given(@"I am a logged in candidate")]
        public void GivenIAmALoggedInCandidate()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have finished an internship")]
        public void GivenIHaveFinishedAnInternship()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have navigated to the offer's page")]
        public void GivenIHaveNavigatedToTheOfferSPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter the feedback comments")]
        public void WhenIEnterTheFeedbackComments()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press Send")]
        public void WhenIPressSend()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The feedback is saved")]
        public void ThenTheFeedbackIsSaved()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"It is displayed on the offer's page")]
        public void ThenItIsDisplayedOnTheOfferSPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
