Feature: iOSOnly
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Add and delete a task from the list
	Given I enter a new task named "Finish example"
    And I am on the task list page
    When I swipe and delete the task named "Finish example"
    Then the task named "Finish example" should not exist
