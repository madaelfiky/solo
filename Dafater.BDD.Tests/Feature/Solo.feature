Feature: Solo File Upload Tests

@tc:1088
Scenario: Login in solo and upload file
	Given the user Enters solo credentials
	When user clicks files
	And user upload files
	Then files should be uploaded successfully



