using System;
namespace TinyUrlApp
{
	public class RandomKeyGenerator
	{
        const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public RandomKeyGenerator()
		{

		}

        public virtual string createUniqueKey(int keyLength)
        {
            Random random = new Random();
            var chars = Enumerable.Range(0, keyLength).Select(x => pool[random.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }
    }
}

