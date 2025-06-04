Feature: Login Functionality
  As a registered user
  I want to log into my account
  So that I can access my dashboard

Scenario Outline: User tries to log in with different credentials
  Given the user is on login page
  When the user enters "<username>" and "<password>"
  Then the login should be "<result>"

Examples:
  | username  | password   | result       |
  | testuser  | password123 | success     |
  | admin     | wrongpass   | failure     |
  | user123   | pass123     | success     |
  | guest     | empty       | failure     |
