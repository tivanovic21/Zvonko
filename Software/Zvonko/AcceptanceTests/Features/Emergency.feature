Feature: Emergency

As a school schedule manager
I want to be able to play emergency sound
In case of emergency

Scenario: Emergency From Screen
	Given I am logged in
	When I click the Emergency button
	Then I should see the Emergency screen

Scenario: Cancel Emergency
	Given I am logged in and on Emergency screen
	When I click the Cancel button
	Then I should see the main window

Scenario: Select First Available Emergency Sound
	Given I am logged in and on Emergency screen
	When I select the first available sound from the emergency combobox
	Then the first available sound should be selected

Scenario: Play Selected Sound
	Given I am logged in and on Emergency screen
	And an emergency sound is selected
	When I click the Play button
	And I confirm the play action
	Then the emergency sound should play