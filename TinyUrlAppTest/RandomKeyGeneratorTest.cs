namespace TinyUrlAppTest;

[TestClass]
public class RandomKeyGeneratorTest
{
    [TestMethod]
    public void test_RandomKeyGenerator_createsKey_WithLength_6()
    {
        var randomKeyGenerator = new TinyUrlApp.RandomKeyGenerator();
        var result = randomKeyGenerator.createUniqueKey(6);
        Assert.IsTrue(result.Length == 6);
        
    }
}
