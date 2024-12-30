Feature: Login

As a TA Engineer, I want to test the login functionality, to achieve BDD

@validlogin
Scenario: Successful Login with valid credentials
	Given the Saucedemo login page is displayed
	When valid credentials are entered
	And the login button is clicked
	Then the user should be rerouted to the products page

@invalidlogin
Scenario Outline: Unsuccessful login with invalid credentials
	Given the Saucedemo login page is displayed
	When "<username>" and "<password>" are entered
	And the login button is clicked
	Then an error message indicating that "<error_message>" should be displayed
Examples:
	| username        | password     | error_message                                               |
	| invalid_user    | invalid_pass | Username and password do not match any user in this service |
	| locked_out_user | secret_sauce | user has been locked out                                    |
	|                 | secret_sauce | Username is required                                        |
	| standard_user   |              | Password is required                                        |
	|                 |              | is required                                                 |

@lockedUserlogin @ignore
Scenario: Login with locked out user
	Given the Saucedemo login page is displayed
	When the credentials of a locked out user are entered
	And the login button is clicked
	Then an error message indicating that the user is locked out should be displayed

@othervalidcredentials
Scenario Outline: Login with various credentials
	Given the Saucedemo login page is displayed
	When "<username>" and "<password>" are entered
	And the login button is clicked
	Then "<result>" should be displayed
Examples:
	| username      | password     | result        |
	| standard_user | secret_sauce | products page |
	| problem_user  | secret_sauce | products page |
	| error_user    | secret_sauce | products page |