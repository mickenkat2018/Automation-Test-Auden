Feature: UISmokeTests

@smokeTests
Scenario Outline: Create an account
	Given user is on the site login page
	And Provides an email address under create new account form and clicks the create account button
	Then the user should be redirected to registration form
	When user successfully creates an account
	Then user should be redirected to My account page
	And user should be able to logout and log back in with newly created credentials
	When user selects an item category as <productCategory> and chooses a product listed with <priceCategory> price
	Then user can now add selected item to basket
	When user logs out, and logs back in, item should still be in the basket

Examples: 
| productCategory | priceCategory |
| Dress           | Highest Price |

