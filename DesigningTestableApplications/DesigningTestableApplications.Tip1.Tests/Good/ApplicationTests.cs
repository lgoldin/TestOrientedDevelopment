using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestOrientedDevelopment.Tip1.Good;

namespace TestOrientedDevelopment.Tip1.Tests.Good
{
    [TestClass]
    public class ApplicationTests
    {
        [TestMethod]
        public void GetLast10LoggedMessages()
        {
            var application = new Application();
            IList<string> messages = application.GetLast10LoggedMessages();

            Assert.AreEqual(10, messages.Count);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual((i + 1).ToString(), messages[i]);
            }
        }
    }
}
