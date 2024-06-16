Feature: UserProfile

A short summary of the feature

Scenario: User profile Display
	Given i am a user that is logged in
	When i click the user profile button
	Then i should see the user profile user control


Scenario: Leave User profile UC
	Given logged correctly
	When I click user profile button on the main screen
	And I click the Cancel button on User profile
	Then i should see main screen

Scenario Outline: Invalid Update of an User profile
    Given I am logged succesfully
    When I go to user profile
    And I clear username
    And I clear school name
    And I clear mac adress
    And I enter updated account details: username <username>, macAdress <macAdress> and school name <schoolName> 
    And I click Save
    Then I should see <message> error message in update account screen

Examples:
    | username | macAdress | schoolName | message              |
    |          |           |            | Fill out all fields! |
    | dev      |           |            | Fill out all fields! |
    |          | mac       |            | Fill out all fields! |
    |          |           | Osnovna    | Fill out all fields! |
    | dev      | mac       |            | Fill out all fields! |
    | dev      |           | Osnovna    | Fill out all fields! |
    |          | mac       | Osnovna    | Fill out all fields! |

