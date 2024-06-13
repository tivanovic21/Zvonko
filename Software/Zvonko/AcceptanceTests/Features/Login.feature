Feature: Login

As a school schedule manager
I want to be able to login in to the system
So that I can manage and schedule bell ringing

Scenario: Login Display
	When I launch the application
	Then I should see the login window

Scenario Outline: Invalid Credentials
	Given I am on the login form
	When I enter username <username> and password <password>
	When I click on the Login button
	Then I should see <message> error message
	
	Examples: 
	| username    | password    | message              |
	|             |             | Fill out all fields! |
	| invalidUser | invalidPass | User not found!      |
	| invalidUser |             | User not found!      |
	|             | dev         | User not found!      |
	| dev         |             | Invalid credentials! |

Scenario: Valid Credentials
	Given I am on the login form
	When I enter username dev and password dev
	And I click on the Login button
	Then I should be redirected to main window