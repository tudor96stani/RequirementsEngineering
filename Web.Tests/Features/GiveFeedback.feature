Feature: GiveFeedback
	In order to inform others about an internship
	As a candidate 
	I want to be able to offer feedback

@feedback
Scenario: Give feedback
	Given I am a logged in candidate
	And I have finished an internship
	And I have navigated to the offer's page
	When I enter the feedback comments
	And I press Send
	Then The feedback is saved
	And It is displayed on the offer's page
