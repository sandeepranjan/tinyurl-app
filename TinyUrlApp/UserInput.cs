using System;
namespace TinyUrlApp
{
	public class UserInput
	{
        public string userAction { get; set; } //valid values: c (create), d (delete), g (get), s (stats) 
        public string url { get; set; } // this could be longUrl or shortUrl based on user Input
        public string customAlias { get; set; }

        public UserInput(string userAction, string url, string customAlias)
		{
            this.userAction = userAction;
            this.url = url;
            this.customAlias = customAlias;
        }

        public static UserInput createUserInputObject(String[] inputArgsArray)
        {
            string userAction = inputArgsArray[0].Trim().ToLower();
            String? longUrl = string.Empty;
            String? customShortUrl = string.Empty;

            if (inputArgsArray.Length > 1)
                longUrl = inputArgsArray[1].Trim();

            if (inputArgsArray.Length > 2)
                customShortUrl = inputArgsArray[2].Trim();

            UserInput userInput = new(userAction, longUrl, customShortUrl);
            return userInput;
        }
    }
}

