Feature: Search

As a user 
i should be able to use the google search functionality

Background: 
	Given I am on google page

@googleSearch
Scenario: google search1
	When I search for Iphone13
	And I click search button
	Then I see search result
	And Iphone13 is displayed in result page
	When I click Iphone13 link

Scenario Outline: google search2
	When I search for Iphone<number>
	And I click search button
	Then I see search result
	And Iphone<number> is displayed in result page
	When I click Iphone<number> link
Examples: table
	| number |
	| 12     |
	| 13     |
	| 14     |