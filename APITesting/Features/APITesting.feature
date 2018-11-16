Feature: PostCodeAPITesting

Scenario Outline: Get API response from Lookup a postcode

	Given I have a postcode to lookup <postcodes>
	When I call the get method 
	Then i should get back information of my chosen postcode
	Examples: postcodes
	| postcodes |
	| W120LQ    |
	| UB56AP    |

Scenario: Bulk lookup postcodes
	Given I called the base url
	When I call the post method with the bulk
	Then i should get back information of all postcodes chosen 



