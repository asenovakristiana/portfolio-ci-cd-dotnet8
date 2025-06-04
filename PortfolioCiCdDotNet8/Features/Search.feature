Feature: Search Functionality
	Scenario: User searches for Selenium WebDriver
		Given the user is on the search page
		When they enter "Selenium WebDriver" in the search box
		Then they see relevant results