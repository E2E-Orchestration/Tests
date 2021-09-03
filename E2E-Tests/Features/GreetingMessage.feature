Feature: Greeting Message
	Participant sees a greeting message

Scenario: Participant sees a greeting message
	Given I visit the website
	When I navigate to the greeting screen
	Then I see the greeting message