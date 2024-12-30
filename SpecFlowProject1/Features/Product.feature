Feature: Product

As a TA Engineer, I want to test the actions of a user on the Inventory page.

Background:
	Given the user is logged in to SauceDemo

@Addeachproductininventory
Scenario Outline: Add a product to the cart
	When the product "<product_name>" is added to the cart
	Then the product "<product_name>" should be in the cart
	And the cart badge should display "<badgecount>"
Examples:
	| product_name                      | badgecount |
	| Sauce Labs Backpack               | 1          |
	| Sauce Labs Bike Light             | 1          |
	| Sauce Labs Bolt T-Shirt           | 1          |
	| Sauce Labs Fleece Jacket          | 1          |
	| Sauce Labs Onesie                 | 1          |
	| Test.allTheThings() T-Shirt (Red) | 1          |

@Removeeachproductininventory
Scenario Outline: Remove a product from the cart
	Given the product "<product_name>" is added to the cart
	When the product "<product_name>" is removed from the cart
	Then the product "<product_name>" should not be in the cart
	And the cart badge should display "<badgecount>"
Examples:
	| product_name                      | badgecount |
	| Sauce Labs Backpack               | 0          |
	| Sauce Labs Bike Light             | 0          |
	| Sauce Labs Bolt T-Shirt           | 0          |
	| Sauce Labs Fleece Jacket          | 0          |
	| Sauce Labs Onesie                 | 0          |
	| Test.allTheThings() T-Shirt (Red) | 0          |

@Checkproductdetails
Scenario Outline: View product details
	When the details of product "<product_name>" are viewed
	Then the product "<product_name>" details should be displayed
	And the product name should be "<product_name>"
Examples:
	| product_name                      |
	| Sauce Labs Backpack               |
	| Sauce Labs Bike Light             |
	| Sauce Labs Bolt T-Shirt           |
	| Sauce Labs Fleece Jacket          |
	| Sauce Labs Onesie                 |
	| Test.allTheThings() T-Shirt (Red) |

@Add_allproducts
Scenario: Add all products to the cart
	When all the products are added to the cart
	Then the cart badge should display "6"

@SortbyName
Scenario: Sort the products by Name in ascending order
	When the sort products by name (A-Z) option is selected
	Then the inventory should be sorted by name in ascending order

@SortbyName
Scenario: Sort the products by Name in descending order
	When the sort products by name (Z-A) option is selected
	Then the inventory should be sorted by name in descending order

@SortbyPrice
Scenario: Sort the products by Price in ascending order
	When the sort products by price (low-high) option is selected
	Then the inventory should be sorted by price in ascending order

@SortbyPrice
Scenario: Sort the products by Price in descending order
	When the sort products by price (high-low) option is selected
	Then the inventory should be sorted by price in descending order