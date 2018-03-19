@createTask
Feature: CreateTask
	As a ToDo App user
	I should be able to create a task
	So I can manage my tasks
	
Background: Enter the page
	Given I have logged in the website
	When I click My Tasks
	Then I should see the ToDoList page

Scenario: Verify a task creation
	Given I typed a new task
	When I click on Add icon	
	Then the new task should be in the To be Done list

Scenario: Verify the clicking on the My Tasks link on the NavBar
	When I clicked the link My Tasks on the NavBar
	Then I should see the ToDoList page

Scenario: Checking the message on the top
	When I see the message on the top
	Then The message on the top should be correct

Scenario: Verify the Enter button by Keyboard to create a new task
	Given I typed a new task
	When I press Enter
	Then the new task should be in the To be Done list

Scenario: Check if the task field permits less than 3 characters
	When I type a task named ts
	And I press Enter
	Then The task should not be added

Scenario: Check the maxlenght of the task field
	When I see the maxlength of the task field
	Then The value of the task field should be correct
