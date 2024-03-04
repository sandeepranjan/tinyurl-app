# tinyurl-app
# This application is a command line implementation of a Tiny Url Style Service.

## Files/Classes:

* Program.cs: This class has the Main method which is the entry point of the application
* UserInput.cs: Class having fields that correspond to the command line user input. It has static method that acts as a factory for creating UserInput objects.
* RandomKeyGenerator.cs: This is a helper class that generates random token of length 6 characters. This token is part of the tiny Url.
* TinyUrl.cs: This class maintains the mapping of long Urls to short Url and how many times the url has been clicked (hitCounter field).
* TinyUrlService.cs: Class having complete logic of creating Unique URls, deleting Urls, incrementing hit Counter.
