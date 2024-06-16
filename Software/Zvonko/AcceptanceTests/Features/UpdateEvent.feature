Feature: UpdateEvent

A short summary of the feature

@tag1
Scenario: Update event Display
	Given log in good
	When I click monday now
    And i select a event i want to update
	And i click update event
	Then i should see the update event user control


Scenario: Leave update event UC
	Given logged
	When I click monday in dg
	When i select a event
	And i click update event now
	And I click cancel update
	Then i should see main screen after canceling


Scenario: Update event without selecting a new recording
	Given logged into app
	When I click monday button
    And select event
	And i click update button
	And I click save
	Then error popup


	
Scenario Outline: Invalid Update of an Event
    Given I am on main screen
    When I click button monday to grab all the event
    And i select a event for update
    And i click update
    And I clear name
    And I clear description
    And I clear startingTime
    And I enter updated event details: name <name>, description <description> and starting time <startingTime>
    And I select the recording aswell
    And I click on the update button
    Then I should see <message> error message in update event screen

    Examples:
    | name     | description | startingTime       | message              |
    |          |             |                    | Fill out all fields! |
    | newEvent |             |                    | Fill out all fields! |
    |          | someDesc    |                    | Fill out all fields! |
    |          |             |                    | Fill out all fields! |
    |          |             | 12:00:00           | Fill out all fields! |
    | newEvent | someDesc    |                    | Fill out all fields! |
    | newEvent |             | 12:00:00           | Fill out all fields! |
    |          | someDesc    | 12:00:00           | Fill out all fields! |