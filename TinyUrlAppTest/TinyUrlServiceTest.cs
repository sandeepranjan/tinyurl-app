using System;

using Moq;

namespace TinyUrlAppTest
{
	[TestClass]
	public class TinyUrlServiceTest
	{

		TinyUrlApp.TinyUrlService tinyUrlServiceTest = new();

		[TestMethod]
		public void test_TinyUrl_Using_CustomAlias()
		{
			//var randomKeyGenerator = new Mock<TinyUrlApp.RandomKeyGenerator>();			
			//randomKeyGenerator.Setup(x => x.createUniqueKey(6)).Returns("x08F4r");

			var customAlias = "x08F4r";
			var longUrl = "http://gmail.com";
            var shortUrlexpectedResult = TinyUrlApp.Program.TINY_URL + "/" + customAlias;

            var shortUrlResult = tinyUrlServiceTest.createShortUrl(longUrl, customAlias);
			

			var actualDictionarySize = tinyUrlServiceTest.getDictionarySize();
			var actualLongUrl = tinyUrlServiceTest.getLongUrlFromDictionary(TinyUrlApp.Program.TINY_URL + "/" + customAlias);
			var actualHitCounter = tinyUrlServiceTest.getHitCounter(shortUrlexpectedResult);
			


            Assert.IsTrue(shortUrlexpectedResult.Equals(shortUrlResult));
			Assert.AreEqual(actualDictionarySize , 1);
			Assert.IsTrue(actualLongUrl.Equals(longUrl));
			Assert.AreEqual(actualHitCounter, 1);

            var actualCountOfDeletedUrls = tinyUrlServiceTest.deleteShortUrls(longUrl);
            var actualDictionarySizeAfterDeletion = tinyUrlServiceTest.getDictionarySize();

            Assert.AreEqual(actualCountOfDeletedUrls, 1);
            Assert.AreEqual(actualDictionarySizeAfterDeletion, 0);

        }
	}
}

