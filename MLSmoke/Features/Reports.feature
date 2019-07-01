Feature: Reports

@smoke
Scenario: Custom Report designer are working
	Given User login to application
	And User navigated to Reports page
	When User designed a custom report for Credit Score
	Then User verified Credit Score custom report creation

Scenario: Running Pre-built reports for Credit Score
	Given User login to application
	And User navigated to Reports page
	And User selected Pre-built Credit Score reports
	When User ran Credit Score reports 
	Then User verified Pre-built Credit Score reports

Scenario: Running Pre-built reports for Vehicle App
	Given User login to application
	And User navigated to Reports page
	And User selected pre-built Credit Score Reports for Vehicle App
	When User ran Credit Score reports for Vehicle App
	Then User verified Credit Score reports for Vehicle App

Scenario: Running Pre-built reports for Vehicle App in PDF format
	Given User login to application
	And User navigated to Reports page
	And User selected Credit Score Reports in PDF format for Vehicle App 
	When User ran Credit Score reports for Vehicle App in PDF format
	Then User verified Credit Score reports with PDF format for Vehicle App

Scenario: Running Pre-built reports for Approved Loans
	Given User login to application
	And User navigated to Reports page
	And User selected Approved Loans Pre-built reports
	When User ran Approved Loans reports
	Then User verified Approved Loans reports

Scenario: Running Pre-built reports in XLS format for Approved Loans
	Given User login to application
	And User navigated to Reports page
	And User selected Approved Loans Pre-built reports in XLS format
	When User ran Approved Loans Pre-built reports in XLS format
	Then User verified Approved Loans reports in XLS format

Scenario: Running Pre-built reports for Branch Activities
	Given User login to application
	And User navigated to Reports page
	And User selected Branch Activities Pre-built reports
	When User ran Branch Activities Pre-built reports
	Then User verified Branch Activities Pre-built reports

