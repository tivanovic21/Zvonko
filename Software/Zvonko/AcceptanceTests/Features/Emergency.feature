Feature: Emergency

As a school schedule manager
I want to be able to play emergency sound
In case of emergency

Scenario: Emergency From Screen
	Given I am logged in
	When I click the Emergency button
	Then I should see the Emergency screen