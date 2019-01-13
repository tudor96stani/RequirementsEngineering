Feature: SearchOffersAndCandidates
	In order to find offers or other candidates
	As a logged in user
	I want to be able to search for them

@search
Scenario: Search for offers and candidates
	Given I am a logged in user
	And I have navigated to the Offers or Candidates page
	And I have enterd the keyword Java
	When I press search
	Then the list of Java internships should be displayed
