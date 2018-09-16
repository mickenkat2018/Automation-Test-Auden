Feature: UISmokeTests

@smokeTests
Scenario Outline: Create an account
	Given user is on the site login page
	And provides an <emailAddress> under create new account form and clicks the create account button
	Then the user should be redirected to registration form
	When user successfully creates an account
	Then user should be redirected to My account page
	And user should be able to logout and log back in with newly created credentials

Examples: 
| emailAddress    |
| email@email.com |