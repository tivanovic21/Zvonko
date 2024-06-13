Feature: LiveBroadcast

As a school schedule manager
I want to be able to do 
A live broadcast in case of emergency
Or to give out important information

Scenario: Live Broadcast Screen
	Given I am logged in
	When I click the Live Broadcast button
	Then I should see the Live Broadcast screen

Scenario: Cancel Live Broadcast
	Given I am on the Live Broadcast screen
	When I close the screen
	Then I should be on the main screen

Scenario: Start Live Broadcast
	Given I am on the Live Broadcast screen
	When I press the Start Streaming button
	And I confirm the start streaming action
	Then the Live Broadcast should start

Scenario: Stop Live Broadcast
	Given I am on the Live Broadcast screen
	And The broadcast has started
	When I press the Stop Streaming button
	Then the Live Broadcast should stop
