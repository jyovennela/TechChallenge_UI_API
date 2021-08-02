Feature: RestAPI
	Simple calculator for adding two numbers

@GET
Scenario: Verify GET Method Response & Status Code
	Given Rest API End Point
	When invoke the GET Method
	Then verify the response

@GET
Scenario: Verify GET Method scores order
	When invoke the GET Method to verify the score order
	Then the score should be in descending order

@POST
Scenario: Verify Post method with valid User
	When invoke the post method with a valid body
	Then the data submitted successfully "p9t", 200

@POST
Scenario: Verify Post method with invalid User
	When invoke the post method with a valid body
	Then the data not submitted successfully "", 200

@POST
Scenario: Verify Post method with invalid score
	When invoke the post method with a valid body
	Then the data not submitted successfully "pos", 0
@POST
Scenario: Verify Post method with duplicate user
	When invoke the post method with a valid body
	Then duplicate data not submitted successfully "post", 100

@PUT
Scenario: Verify PUT method with existing user
	When invoke the post method with a valid body
	Then data should be updated successfully "put", 100

@PUT
Scenario: Verify PUT method with new user
	When invoke the post method with a valid body
	Then data should be added successfully "p2t2", 200

@PUT
Scenario: Verify PUT method with invalid user
	When invoke the post method with a valid body
	Then data should not be submit successfully "", 200

@PUT
Scenario: Verify PUT method with invalid score
	When invoke the post method with a valid body
	Then data should not be submit successfully "put1", 0

@DELETE
Scenario: Verify DELETE method with invalid delete-key
	When invoke the Delete method without a delete-key
	Then the response staus should be unauthorized 

@DELETE
Scenario: Verify DELETE method with valid delete-key
	When invoke the Delete method with a valid delete-key
	Then the response staus should be success 

		