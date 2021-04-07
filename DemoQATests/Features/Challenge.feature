Feature: Challenge
	This feature must register a user and handle his book collection


Scenario: Register a user  
	Given the user navigate to the login page
	And he goes to the user registration page
	When he fills in the registration of a new user with the correct data
	Then the data was filled in correctly way
	And the user confirm the registration
	And the user logs in, confirming that the registration was successfully
	
	
Scenario: Search a book and add it to the book collection	
	Given the authenticated user navigates to profile page
	When the user searches a specific book using the tag "JavaScript"
	Then a list of all books with this tag appears
	Then the user add the book number '2' of the list to his book collection
