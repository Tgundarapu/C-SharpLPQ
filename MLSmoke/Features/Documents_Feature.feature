Feature: Documents_Feature
	Description: This feature will test the Document functionality

@smoke
Scenario: Verify the Printing of Docs For Banker System
	 Given User Login successfully
     When User selected Vehicle APP 
	 And User navigated to letter docs
	 And User Attached document
	 And User Click on Display Link of the uploaded document
     Then Print button Should be displayed in the Print Preview Window

Scenario: Verify the Attaching of .PDF Document less than 4mb
	 Given User Login successfully
     When User selected Vehicle APP 
	 And User navigated to letter docs
	 And User Attached document
     Then The same PDF document should be displayed in the scanned /Uploaded documents

Scenario: Verify the Attaching of .PDF Document more than 4mb
	 Given User Login successfully
     When User selected Vehicle APP 
	 And User navigated to letter docs
	 And User Attached pdf document of more than 4mb 
     Then Pop should be displayed as the file you are transferring is too big

Scenario: Verify the .JPG Document is not attached
	 Given User Login successfully
     When User selected Vehicle APP 
	 And User navigated to letter docs
	 And User Attached .jpg document of less than 4mb
     Then Pop up Should be displayed as file type .JPG is not allowed

Scenario: Verify the visibility of the document to the consumer
	 Given User Login successfully
     When User selected Vehicle APP 
	 And User navigated to letter docs
	 And User Attached document
	 And Click on show consumer link of the uploaded document  coming in the scanned/uploaded document
     Then YES should be displayed In the consumer column of the uploaded document present in the Scanned / uploaded Documents section

Scenario: Verify the sharing of the PDF document on the generated link 
	 Given User Login successfully
     When User selected Vehicle APP 
	 And User navigated to letter docs
	 And Copy the generated link
	 And Open the generated link 
	 And Upload the PDF document less than 3.91 mb
     Then The same PDF document should be displayed in the scanned /Uploaded documents

Scenario: Verify the .PDF document of more than 3.91mb must not be shared on the generaded link 
	 Given User Login successfully
     When User selected Vehicle APP 
	 And User navigated to letter docs
	 And Copy the generated link
	 And Open the generated link 
	 And Upload the PDF document of more than 3.91 mb
     Then The file you are transferring is too big Max file size is 3.91MB Message should be there