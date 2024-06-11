Feature: Registration

As a school schedule manager
I want to be able to register a new account
So that I can access the system

Scenario: Register Display
	When I launch the application
	Given I am on the Login screen
	And I press the Register here hyper link
	Then I should see the registration window

Scenario Outline: Invalid Registration
	Given I am on the Registration screen
	When I enter registration details username <username>, password <password> and school name <schoolName>
	And I click on the Register button
	Then I should see <message> error message in registration

	Examples:
	| username | password | schoolName | message              |
	|          |          |            | Fill out all fields! |
	| dev      |          |            | Fill out all fields! |
	|          | dev      |            | Fill out all fields! |
	|          |          | dev        | Fill out all fields! |
	| dev      | dev      |            | Fill out all fields! |
	| dev      |          | dev        | Fill out all fields! |
	|          | dev      | dev        | Fill out all fields! |

Scenario: Valid Registration
	Given I am on the Registration screen
	When I enter registration details username <username>, password <password> and school name <schoolName>
	And I click on the Register button
	Then I should be redirected to the login screen

	Examples:
	| username | password | schoolName |
	| testUser | testPass | testSchool |  