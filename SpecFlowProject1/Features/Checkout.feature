Feature: Checkout

As a TA Engineer, I want to test the actions of a user on the Checkout page.
Background: 
	Given the user is logged in
	And products are added to the cart
	And the cart page is navigated to
	And Checkout is clicked

@MissingDetailsCase
Scenario Outline: Providing Incorrect Checkout Information
	When "<firstName>" is entered as the First Name
    And "<lastName>" is entered as the Last Name
    And "<Zip>" is entered as the Zip/Postal Code
    And Continue is clicked
    Then the "<Expectedresult>" should be displayed
	Examples: 
	| firstName		| lastName		| Zip		| Expectedresult			|
	|				| Bhamidipati	| 500035    | First Name is required	|
	| Venkata Sai P |				| 500035    | Last Name is required		|
	| Venkata Sai P | Bhamidipati	|		    | Postal Code is required	|
	|				|				|		    | is required				|

@NormalCase
Scenario: Providing Correct Checkout Information
	When "Venkata Sai P" is entered as the First Name
    And "Bhamidipati" is entered as the Last Name
    And "500035" is entered as the Zip/Postal Code
    And Continue is clicked
    Then the user should be rerouted to Checkout Overview 
    When Finish is clicked
    Then the user should be rerouted to Checkout Complete
    And "Thank you" should be part of the success message
