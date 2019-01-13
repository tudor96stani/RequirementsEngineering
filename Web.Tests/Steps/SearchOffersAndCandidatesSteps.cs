using System;
using TechTalk.SpecFlow;

namespace Web.Tests
{
    [Binding]
    public class SearchOffersAndCandidatesSteps
    {
        [Given(@"I am a logged in user")]
        public void GivenIAmALoggedInUser()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have navigated to the Offers or Candidates page")]
        public void GivenIHaveNavigatedToTheOffersOrCandidatesPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have enterd the keyword Java")]
        public void GivenIHaveEnterdTheKeywordJava()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the list of Java internships should be displayed")]
        public void ThenTheListOfJavaInternshipsShouldBeDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
