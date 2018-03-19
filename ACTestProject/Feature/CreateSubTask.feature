@createSubTask
Feature: CreateSubTask
	As a ToDo App user
	I should be able to create a subtask
	So I can break down my tasks in smaller pieces


Background: Enter the page and click the Manage Subtasks button
	Given I have logged in the website
	When I click My Tasks
	Then I should see the ToDoList page
	And I create a task
	And I click on the Manage Subtasks button

Scenario: Verify if there is a button labeled as Manage Subtasks
	When I close the modal
	Then I should see a button labeled Manage Subtasks

Scenario: Verify if the Manage Subtasks button have the number of subtasks created
	Given I created two subtasks
	When I close the modal
	Then I should see the number of two subtasks created for that task
	
Scenario: Verify if the modal has a task ID and task description
	Given The modal dialog is open
	Then I should check if the modal has task ID and task description

Scenario: Verify if the subtask description and dueDate have the correct values
	Given The modal dialog is open
	Then the subTask description and dueDate should have the correct values

Scenario: Verify if it's possible to add a new subTask by clicking on the Add button
	Given I created a subtask
	When I click the Add button to add a subTask

Scenario: Verify if the task description and dueDate are required fields
	Given The modal dialog is open
	Then I should see if the task description and dueDate are required fields

Scenario: Verify if the subtasks added were appended on the bottom part of the modal dialog
	Given I created a subtask
	When I click the Add button to add a subTask
	Then The subtask should be on the bottom part of the modal dialog