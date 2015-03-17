using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DesigningTestableApplications.Tip2.Tests
{
    [TestClass]
    public class ApplicationTests
    {
        [TestMethod]
        public void GetLast10LoggedMessages()
        {
            var logger = new Mock<ILogger>();
            logger.Setup(x => x.GetLast10Messages()).Returns(new string[]
            {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
            });

            var application = new Application(logger.Object);
            IList<string> messages = application.GetLast10LoggedMessages();

            Assert.AreEqual(10, messages.Count);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual((i + 1).ToString(), messages[i]);
            }

            logger.Verify(x => x.GetLast10Messages(), Times.Once);
        }
    }
}
