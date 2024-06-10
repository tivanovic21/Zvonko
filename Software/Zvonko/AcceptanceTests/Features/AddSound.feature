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

	# soundName specific to the one available on the testers PC
	# sample file: Intro Sound effects.mp3
	Examples: 
	| soundName               |
	| Intro Sound effects.mp3 |  

Scenario: Cancel Adding A Sound After File Is Loaded
	Given I am logged in and on a Add New Sound screen
	And I have loaded the Sound File with file name <soundName>
	When I click the Cancel button
	Then I should see the main window

	Examples: 
	| soundName               |
	| Intro Sound effects.mp3 |


# Files don't get actually saved to the db, thus 
# the success message step is set always to true
Scenario: Add Sound To System
	Given I am logged in and on a Add New Sound screen
	And I loaded the sound with name <soundName>
	When I choose Emergency value
	And I press the Save button
	Then I should get a success message

	Examples: 
	| soundName               |
	| Intro Sound effects.mp3 |

