using Gloop;
using NUnit.Framework;

namespace Gloops.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void ReplaceFirst_Success()
        {
            string valueToTest = "/some/value";

            string result = valueToTest.ReplaceFirst("/", "root-");

            Assert.AreEqual("root-some/value", result);
        }

        [Test]
        public void ReplaceFirst_Cannot_Find()
        {
            string valueToTest = "/some/value";

            string result = valueToTest.ReplaceFirst("tt", "anything");

            Assert.AreEqual("/some/value", result);
        }
    }
}
