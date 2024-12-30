Feature: Cart

As a TA Engineer, I want to test the actions of a user on the Cart page.


@Removingincart
Scenario Outline: Removing an item from the cart page
	Given all items are added to the cart
	And the cart page is navigated to
	When "<item1>" and "<item2>" are removed from the cart
	Then "<item1>" and "<item2>" should be removed
	#paratemeterise
	And the cart badge should display "<badgecount>"
Examples:
	| item1                    | item2                             | badgecount |
	| Sauce Labs Backpack      | Sauce Labs Bike Light             | 4          |
	| Sauce Labs Fleece Jacket | Sauce Labs Onesie                 | 4          |
	| Sauce Labs Bolt T-Shirt  | Test.allTheThings() T-Shirt (Red) | 4          |