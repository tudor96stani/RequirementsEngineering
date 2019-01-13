Feature: Register
	In order to use the application
	I want to register

@register
Scenario: Create new account
	Given I have navigated to the register page
	And I have entered valid information in the form
	When I press Create new account
	Then An account is created
