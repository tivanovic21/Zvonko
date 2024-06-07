Feature: Registration

As a school schedule manager
I want to be able to register a new account
So that I can access the system

Scenario: Register From Display
	When I launch the application
	Given I am on the Login screen
	And I press the Register here hyper link
	Then I should see the registration window
