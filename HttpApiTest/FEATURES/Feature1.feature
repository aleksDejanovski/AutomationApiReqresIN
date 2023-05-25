Feature: Feature1

A short summary of the feature

@tag1
Scenario: PostRequest
	Given The user sends a post request to a url "https://reqres.in/api/users"
	Then user should get a success response


	Scenario: GetUser
	Given The user sends a get request to a url "https://reqres.in/api/users/2"
	Then user should get a success get response
