Feature: Login
	Test the login functionality of application
	Will verify if the username and password combinations are working as expected

@mytag
Scenario Outline: Verify if the login is working
	Given I have navigated to the website
	And I click Sign In
	When I typed "email" and "password"
	And I click on the Sign In button
	Then I should see the ToDoApp page
Examples: 
| email                  | password  |
| admin                  | admin     |
| felipegluz@hotmail.com | abc123456 |

