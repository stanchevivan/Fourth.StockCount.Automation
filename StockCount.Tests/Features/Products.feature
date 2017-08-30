Feature: Products
	Scenarios for Products
	
@TC23625
Scenario: Verify the list of products
	Given Stock Count app is opened
	When I Select location "Covent Garden"
	And user enters area "Bar"
	Then the correct list of products associated with the given location is displayed

Scenario: Verify quantity of product
    Given Stock Count app is opened
    When I Select location "11 test"
    And user enters area "Kitchen"
    Then the correct quantity for a product is displayed

@TC22611 @Smoke
Scenario: Products & UOM display
    Given Stock Count app is opened
    When I Select location "Covent Garden"
    And they navigate to a Stock list screen for area "Kitchen"
    Then they are presented with all the products returned from the API for the users current location
    And underneath every product there is a list of all UOMs returned from the API for the specific product