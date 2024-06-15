Feature: Event

As a school manager
I should be able to define events
that simbolize type of events

Scenario: Go to Add events UC
	Given I'm logged in and on main screen
	When I click Add event button
	Then I should see the Add event screen


Scenario: Leave Add events UC
	Given I'm logged in succesfully
	When I click Add event button on the main screen
	And I click the Cancel button on Add event
	Then I should see the main window after i click cancel


Scenario Outline: Invalid Addition of an Event
    Given I am logged in on the main screen
    When I go to event addition screen
    And I enter new event details: name <name>, description <description> and starting time <startingTime> 
    And I select the recording
    And I click on the Add button
    Then I should see <message> error message in add event screen

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


Scenario: Click reoccurring on the Add events UC
    Given I'm logged in successfully into main
    When I click Add event
    And I check is not recurring checkbox on Add event
    Then I should see the calendar picker

Scenario: Remove an recording without selecting the recording
	Given Log in succesfully
	When I click Add event button on main
	And I click remove event
    Then I should see not allowed


 Scenario: Remove a selected recording
    Given  Logged in succesfully
    When I click Add event in nav
    And I select a recording i want to remove
    And I Click remove selected recording
	Then I should see the popup saying succesfully deleted

 Scenario: Open update dialog
    Given  Succesfull login
    When I click Add event using navigation
    And I select an recording to update
    And I Click update selected recording
	Then I should see the popup where i can edit a recording