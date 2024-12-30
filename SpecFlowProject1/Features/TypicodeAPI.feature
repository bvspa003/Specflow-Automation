Feature: TypicodeAPI

This feature tests the CRUD operations using the APIUtil class.

@POST
Scenario: A POST Request is implemented
  Given a new post is provided with title "meow", body "gugu", userId 7
  When a POST request is sent to "posts"
  Then the response should have the title "meow" and body "gugu" contained

@GET
Scenario: A GET Request is implemented
  Given the post ID 21 is provided
  When a GET request to "posts/21" is sent
  Then the response should have the id 21 and userId 3 contained

@PUT
Scenario: A PUT Request is implemented
  Given an updated post is provided with title "updated meow", body "updated gugu", userId 7
  When a PUT request to "posts/21" is sent
  Then the response should have the title "updated meow" and body "updated gugu" contained

@DELETE
Scenario: A delete request is implemented
  Given the post ID 21 is provided
  When a DELETE request to "posts/21" is sent
  Then the response should be found empty
