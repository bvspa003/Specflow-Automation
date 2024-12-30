Feature: JokeAPI

This feature tests the JokeAPI for fetching jokes.
@RANDOM
  Scenario: A random joke is fetched
    Given the JokeAPI endpoint "https://v2.jokeapi.dev/joke/Any" is provided
    When a GET request to fetch a random joke is sent
    Then the response should have a joke contained

@PROGRAMMING
  Scenario: A programming joke is fetched
    Given the JokeAPI endpoint "https://v2.jokeapi.dev/joke/Programming" is provided
    When a GET request to fetch a programming joke is sent
    Then the response should have a programming joke contained