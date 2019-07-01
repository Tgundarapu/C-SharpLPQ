Feature: SearchBy_Feature
	Description: This feature will test the Search Page functionality

@smoke
Scenario: Verify the loading of APP with valid APP number
	 Given User Login successfully
     When User select the Loan APP Number from the drop down
	 And User enters valid APP number and Click Search 
     Then Same APP number should be displayed in the loaded Application

Scenario: Verify the loading of APP with invalid APP number
	 Given User Login successfully
     When User select the Loan APP Number from the drop down
	 And User enters invalid APP number and Click Search 
     Then Pop up should be displayed as No Results found

Scenario: Verify the loading of APP with valid first name
	 Given User Login successfully
     When User select the First Name from the drop down
	 And User enters valid first name and Click Search 
     Then Same first name APP should be displayed in the name column of the results found

Scenario: Verify the loading of APP with invalid first name
	 Given User Login successfully
     When User select the First Name from the drop down
	 And User enters invalid first name and Click Search 
     Then Pop up should be displayed as No Results found

Scenario: Verify the loading of APP with valid last name
	 Given User Login successfully
     When User select the Last Name from the drop down
	 And User enters valid lasst name and Click Search 
     Then Same last name APP should be displayed in the name column of the results found

Scenario: Verify the loading of APP with invalid last name
	 Given User Login successfully
     When User select the Last Name from the drop down
	 And User enters invalid last name and Click Search 
     Then Pop up should be displayed as No Results found
	 
Scenario: Verify the loading of APP with valid SSN
	 Given User Login successfully 
     When User select the SSN from the drop down
	 And User enters valid SSN and Click Search 
     Then Same SSN APP should be displayed in the Last 4 SSN column of the results found

Scenario: Verify the loading of APP with invalid SSN
	 Given User Login successfully
     When User select the SSN from the drop down
	 And User enters invalid SSN and Click Search 
     Then Pop up should be displayed as No Results found

Scenario: Verify the loading of APP with valid Member Number
	 Given User Login successfully 
     When User select the Member Number from the drop down
	 And User enters valid Member Number and Click Search 
     Then Same Member Number APP should be displayed in the Member# column of the results found

Scenario: Verify the loading of APP with valid Universal Loan ID
	 Given User Login successfully 
     When User select the Universal Loan ID from the drop down
	 And User enters valid Universal ID and Click Search 
	 And In Loan Info click on HMDA info
     Then Same Universal loan ID should be displayed in the universal Loan identifier text box

Scenario: Verify the loading of APP with invalid Member Number
	 Given User Login successfully
     When User select the Member Number from the drop down
	 And User enters invalid Member Number and Click Search 
     Then Pop up should be displayed as No Results found

Scenario: Verify the loading of APP with invalid Universal Loan ID
	 Given User Login successfully
     When User select the Universal Loan ID from the drop down
	 And User enters invalid Universal Loan ID and Click Search 
     Then Pop up should be displayed as No Results found

Scenario: Verify the loading of the APP
	Given User Login successfully
	When In Action ? column click the View APP icon
	Then APP should be displayed with all the headings Laon Info,Custom Questions,Comments ,Borrower Info,Liabilities,Assets,Underwriting Info,Disbursements





	