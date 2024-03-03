using System;
namespace TinyUrlApp
{
	public class TinyUrl
	{
        public string longUrl { get; set; }
        public string shortUrl { get; set; }
        public long hitCounter { get; set; }

        public TinyUrl(string longUrl, string shortUrl, long hitCounter)
		{
            this.longUrl = longUrl;
            this.shortUrl = shortUrl;
            this.hitCounter = hitCounter;
        }
	}
}

