Feature: Calculator
As a user 
I should be able to do some simple calculations



@mytag
@Regression
Scenario: Add two numbers1
	Given the 'first' number is 40  
	And the 'second' number is 40
	When the two numbers are added
	Then the result should be 80


@Regression
Scenario Outline: Add two numbers2
	Given the '<first>' number is <FValue>  
	And the '<second>' number is <SValue> 
	When the two numbers are added
	Then the result should be 120
Examples: 
	| first  | second | FValue | SValue |
	| first  | second | 50     | 70     |
	| first  | second | 40     | 80     |

@Regression
Scenario: Add two numbers3
	Given the 'first' number is   
		| Value |
		| 40    |
	And the 'second' number is
		| Value |
		| 40    |
	When the two numbers are added
	Then the result should be 80