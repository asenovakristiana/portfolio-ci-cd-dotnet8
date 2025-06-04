Feature: Search Functionality
	Scenario: User searches for Selenium WebDriver
		Given the user is on the search page
		When they enter "Selenium WebDriver" in the search box
		Then they see relevant results

Scenario: Successful Login
  Given the user is on the login page
  When the user enters valid credentials
  Then the user should be logged in successfully

Scenario: Unsuccessfull login with incorrect password
  Given the user is on the login page
  When the user enters an incorrect password
  Then the user should see an error message

Scenario: Login without entering credentials
  Given the user is on login page
  When the user clicks the login button without entering data
  Then the user should see a warning about empty fields