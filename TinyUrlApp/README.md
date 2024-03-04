# tinyurl-app
# This application is a command line implementation of a Tiny Url Style Service.

## Files/Classes:

* Program.cs: This class has the Main method which is the entry point of the application
* UserInput.cs: Class having fields that correspond to the command line user input. It has static method that acts as a factory for creating UserInput objects.
* RandomKeyGenerator.cs: This is a helper class that generates random token of length 6 characters. This token is part of the tiny Url.
* TinyUrl.cs: This class maintains the mapping of long Urls to short Url and how many times the url has been clicked (hitCounter field).
* TinyUrlService.cs: Class having complete logic of creating Unique URls, deleting Urls, incrementing hit Counter.

## Assumptions:

* The unique Key (or short Url) generated is of 6 char in length and can consist of any character from A-Z a-z 0-9 (a total of 62 chars).
* This will give approx. 56.8 billion distinct tinyUrls. (62^6)


## How to run/test the application:

* Run the command line application the usual way.
* When prompted for Input, supply one of the following:
 * For Creating a new shortUrl for a given LongUrl without supplying the custom Alias
 ```
 c,www.google.com
 ```
 * For Creating a new shortUrl for a given LongUrl supplying the custom Alias
 ```
 c,www.google.com,fgR09l
 ```
 * For retrieving the long Url for a short Url:
 ```
 g,tinyurl.com/fgR09l
 ```
 * For getting the stats on how many times a url has been clicked
 ```
 s,tinyurl.com/fgR09l
 ```
 * Delete all short Urls for the given long Url
 ```
 d,www.google.com
 ```
 * Quit the application
 ```
 q
 ```

## Execution Logs:

![Logs](./images/TinyUrlApp-Execution-logs.png?raw=true?raw=true "Logs")
