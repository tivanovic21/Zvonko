Feature: MainWindow

A short summary of the feature


Scenario: After login the main window appears
	Given Im logged in
	Then Main is loaded

Scenario: Removing events works
	Given Im logged in into the application
	When I click monday
	And I select an event
	And I press remove button
	Then Event is removed
