Feature: NASAAPI

  This feature tests the NASA API for fetching the Astronomy Picture of the Day (APOD).

@APOD
Scenario: The Astronomy Picture of the Day is fetched
    Given the NASA API endpoint "https://api.nasa.gov/planetary/apod" is provided
    And a valid API key is possessed
    When a GET request to fetch the Astronomy Picture of the Day is sent
    Then the response should have the title and explanation of the picture contained
    And the URL of the picture should be contained in the response
    And the URL should be opened in the browser and waited for three seconds
    And the image generated should be downloaded
