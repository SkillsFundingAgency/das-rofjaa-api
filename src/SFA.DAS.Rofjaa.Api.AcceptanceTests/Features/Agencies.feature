Feature: Agencies
	As a Agency API consumer
	I want to retrieve agencies
	So that I can use them in my own application

Scenario: Get list of agencies
	Given I have an http client
	When I GET the following url: api/agencies/
	Then an http status code of 200 is returned
    And all agencies are returned

Scenario: Get agency by id
    Given I have an http client
    When I GET the following url: api/agencies/1
    Then an http status code of 200 is returned
    And the agency with id equal to 1 is returned

Scenario: Four o four returned
    Given I have an http client
    When I GET the following url: api/agencies/100
    Then an http status code of 404 is returned