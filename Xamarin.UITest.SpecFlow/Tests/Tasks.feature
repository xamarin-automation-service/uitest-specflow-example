Feature: Tasks
    In a task app you want to be able to add and complete tasks 

Scenario: Enter and delete a task
    Given I enter a new task named "Finish example"
    And I am on the task list page
    And I select the first task
    And I am on the task details page
    When I delete the task
    And I am on the task list page
    Then the task named "Finish example" should not exist

Scenario: Enter and complete a task
    Given I enter a new task named "Finish example"
    And I am on the task list page
    And I select the first task
    And I am on the task details page
    When I complete the task
    And I verify the task is done
    And I save the task
    Then the task named "Finish example" should be complete
