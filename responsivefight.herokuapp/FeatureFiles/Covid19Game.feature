Feature: Covid19Game
	search of heroes like The HandWasher, Invisible Distance, SOAP, WFH, 
	and any other great warriors against COVID19, until CURE arrives to the rescue.

@mytag
Scenario: Create  Warrior
	Given the page is launched
	And entered the name "Super"
	When click on Create warrior
	Then warrior name can be seen on the link

Scenario: Check the four battles
	Given the page is launched
	And entered the name "Super"
	When click on Create warrior & go to CovidPage
	Then it should be four battles

Scenario: Take the news battle
	Given the page is launched
	And entered the name "Super"
	And click on Create warrior & go to CovidPage
	When take the news battle 
	Then Verify the score in the LeaderBoard "300" 

Scenario: Take the news battle & failed
	Given the page is launched
	And entered the name "Test"
	And click on Create warrior & go to CovidPage
	When take the news battle & failed
	Then It should navigate back to home page
