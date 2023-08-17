Feature: Umrah Tests

@tc:1088
Scenario: Login in Umrah with UO 
	Given the user Enters credentials
	When user Change language to arabic
	Then assert langauage is changed


@tc:1089
Scenario: Login in Umrah with UO2 
	Given the user Enters credentials
#	When user Change language to arabic2
#	Then assert langauage is changed

