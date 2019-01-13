using System;
using TechTalk.SpecFlow;

namespace Web.Tests.Steps
{
    [Binding]
    public class RegisterSteps
    {
        [Given(@"I have navigated to the register page")]
        public void GivenIHaveNavigatedToTheRegisterPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have entered valid information in the form")]
        public void GivenIHaveEnteredValidInformationInTheForm()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press Create new account")]
        public void WhenIPressCreateNewAccount()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"An account is created")]
        public void ThenAnAccountIsCreated()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
