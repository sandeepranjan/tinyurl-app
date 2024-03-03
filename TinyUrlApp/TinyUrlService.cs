using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace TinyUrlApp
{
	public class TinyUrlService
	{
        Dictionary<string, TinyUrl> tinyUrlDictionary = new Dictionary<string, TinyUrl>();

		RandomKeyGenerator randomKeyGenerator = new();

        public TinyUrlService()
		{

		}

        [MethodImpl(MethodImplOptions.Synchronized)]
        public string createShortUrl(string longUrl, string? customAlias)
        {
            
            string uniqueKey = string.Empty;

            Console.WriteLine("custom alias: {0}", customAlias);
            if (customAlias != null && customAlias.Length > 0)
                uniqueKey = customAlias;
            else
                uniqueKey = randomKeyGenerator.createUniqueKey(6);

            while (tinyUrlDictionary.ContainsKey(uniqueKey))
            {
                Console.WriteLine("Unique Key {0} already present in dictionary, generating a new one", uniqueKey);
                uniqueKey = randomKeyGenerator.createUniqueKey(6);

            }
            string shortUrl = createUrlStringWithUniqueKey(uniqueKey);
            TinyUrl tinyUrl = new TinyUrl(longUrl, shortUrl, 0);

            tinyUrlDictionary.Add(uniqueKey, tinyUrl);

            return shortUrl;
        }

        private string createUrlStringWithUniqueKey(string uniqueKey)
        {
            return Program.TINY_URL + "/" + uniqueKey;
        }

        private string getUniqueKeyFromShortUrl(string shortUrl)
        {
            return shortUrl.Contains('/') ? shortUrl.Split("/")[1] : "";
        }

        public string getLongUrlFromDictionary(string shortUrl)
        {
            string uniqueKey = getUniqueKeyFromShortUrl(shortUrl);
            if (!tinyUrlDictionary.ContainsKey(uniqueKey))
                return "";

            //every time a shortUrl is retrieved, increment the hit counter
            tinyUrlDictionary[uniqueKey].hitCounter++;

            return tinyUrlDictionary[uniqueKey].longUrl;
        }

        public long getHitCounter(string shortUrl)
        {
            string uniqueKey = getUniqueKeyFromShortUrl(shortUrl);
            return tinyUrlDictionary.ContainsKey(uniqueKey) ? tinyUrlDictionary[uniqueKey].hitCounter : -1;
        }


        public long getDictionarySize()
        {
            return tinyUrlDictionary.Count;
        }

        public int deleteShortUrls(string longUrl)
        {
            int countOfKeysDeleted = 0;

            //Find all the uniqueKeys for this longUrl and delete each of them
            List<String> keysToRemove = new List<string>();

            foreach (KeyValuePair<string, TinyUrl> entry in tinyUrlDictionary)
            {
                if (longUrl.Equals(entry.Value.longUrl))
                    keysToRemove.Add(entry.Key);

            }
            if (keysToRemove.Count <= 0)
            {
                Console.WriteLine("Url {0} not found in dictionary, nothing to delete", longUrl);
                return -1;
            }

            foreach (string key in keysToRemove)
            {
                tinyUrlDictionary.Remove(key);
                Console.WriteLine("Deleted key {0} mapped to longUrl {1}", key, longUrl);
                countOfKeysDeleted++;
            }
            Console.WriteLine("Size of dictionary after deletion: {0}", getDictionarySize());
            return countOfKeysDeleted;




        }


    }
}

