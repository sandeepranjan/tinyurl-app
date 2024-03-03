// See https://aka.ms/new-console-template for more information


namespace TinyUrlApp
{
    class Program
    {
        public static string TINY_URL = "tinyurl.com";

        public static void Main()
        {


            Console.WriteLine("Running tinyUrlApp !!");

            TinyUrlService tinyUrlService = new();

            Console.WriteLine("**************");
            Console.Write("Command line Input:");
            String? commandLineInput = Console.ReadLine() ?? "";
            String shortUrl = string.Empty;

            UserInput userInputObject = UserInput.createUserInputObject(commandLineInput.Split(","));

            while (true)
            {
                if ("q".Equals(userInputObject.userAction))
                    break;

                if ("c".Equals(userInputObject.userAction))
                {
                    //create new short Url
                    Console.WriteLine("You entered longUrl: {0}", userInputObject.url);
                    shortUrl = tinyUrlService.createShortUrl(userInputObject.url, userInputObject.customAlias);

                    Console.WriteLine("longUrl {0} mapped to shortUrl: {1}, dictionary size: {2}", userInputObject.url, shortUrl, tinyUrlService.getDictionarySize());
                }
                else if ("d".Equals(userInputObject.userAction))
                {
                    //delete all short Urls for the given longUrl
                    tinyUrlService.deleteShortUrls(userInputObject.url);

                }
                else if ("g".Equals(userInputObject.userAction))
                {
                    if (!userInputObject.url.StartsWith(TINY_URL + "/"))
                    {
                        Console.WriteLine("Url supplied needs to be the tinyUrl, e.g. " + TINY_URL + "/xxxxxx");

                    }
                    else
                    {
                        string longUrlFromDictionary = tinyUrlService.getLongUrlFromDictionary(userInputObject.url);
                        if (String.IsNullOrEmpty(longUrlFromDictionary))
                            Console.WriteLine("Url not found in dictionary");
                        else
                            Console.WriteLine("URL redirect from {0} to {1}", userInputObject.url, longUrlFromDictionary);
                    }

                }
                else if ("s".Equals(userInputObject.userAction))
                {
                    if (!userInputObject.url.StartsWith(TINY_URL + "/"))
                    {
                        Console.WriteLine("Url supplied needs to be the tinyUrl, e.g. " + TINY_URL + "/xxxxxx");

                    }
                    else
                    {
                        long hitCounterFromDictionary = tinyUrlService.getHitCounter(userInputObject.url);
                        Console.WriteLine("Short Url: {0}, Hit Counter: {1}", userInputObject.url, hitCounterFromDictionary);
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }


                //get user input again
                Console.WriteLine("**************");
                Console.Write("Command line Input:");
                commandLineInput = Console.ReadLine() ?? "";
                userInputObject = UserInput.createUserInputObject(commandLineInput.Split(","));

            }


            Console.WriteLine("Exiting...");


        }
    }
}