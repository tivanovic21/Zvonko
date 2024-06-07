Feature: AddSound

As a school administrator
I want to be able to add sounds to the system
So that I can play them as bell sounds

Scenario: Add A Sound From Display
	Given I am logged in
	When I click the Add New Sound button
	Then I should see the Add Sound user control

Scenario: Cancel Adding A Sound
	Given I am logged in and on a Add New Sound screen
	When I click the Cancel button
	Then I should see the main window

Scenario: Load Sound File
	Given I am logged in and on a Add New Sound screen
	When I click the Choose a sound button
	And The file dialog is open
	And I choose a sound with name <soundName>
	And I click the Open button
	Then I should see the selected file information on my screen

	Examples: 
	| soundName               |
	| Intro Sound effects.mp3 |

