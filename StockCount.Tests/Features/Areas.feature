@Areas
Feature: Areas
	Scenarios for areas
	
Scenario: Check area is present
	Given I am on the Fourth app Homepage
    When I Open Stock Count app
    And I Select location "Covent Garden"
	Then There is an area with name "Bar"

@TC23624
Scenario: Verify the list of areas
    Given Stock Count app is opened
    When user selects a location
    Then the correct list of areas associated with the given location is displayed

@TC23595
Scenario: Current stock period with status "OPEN"
	Given the current stock period for a given location is set to "Open" status (R9)
	When Stock Count app is opened
	And user chooses the given location from the precondition
	Then the correct "OPEN" status for the stock period is displayed on the main page
	And the correct stock period date range is displayed on the main page

@TC22609 @Smoke
Scenario: Home button navigation
    Given Stock Count app is opened
    And the user is on a screen containing a Home button
    When they click the Home button
    Then they are redirected to the Main screen

@TC23022 @Smoke
Scenario Outline: Create new area locally
    Given Stock Count app is opened
    When I Select location "<locationName>"
    And a new area "<newAreaName>" is created
    Then "<newAreaName>" is present on the area list

Examples:
    | newAreaName                  | locationName  |
    | Automation test created area | Covent Garden |

@TC23021 @Smoke
Scenario: User is redirected to the main page when location is selected
    Given Stock Count app is opened
    And the user has multiple locations
    When I Select location "Covent Garden"
    Then they are redirected to the Main screen

@TC24259 @Smoke
Scenario Outline: Rename area
    Given the Stock Count app is open
    When Location "<location>" is selected
    When Area "<oldAreaName>" is renamed to "<newAreaName>"
    Then the name is changed to "<newAreaName>" on the local device

Examples:
    | location      | oldAreaName | newAreaName             |
    | Covent Garden | Kitchen     | Automation renamed area |