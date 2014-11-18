using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestOrientedDevelopment.Tip5.UI;
using TestOrientedDevelopment.Tip5.Service;
using System;

namespace TestOrientedDevelopment.Tip5.Tests
{
    [TestClass]
    public class UITests
    {
        [TestMethod]
        public void UIMethod()
        {
            // Setup preconditions including the setup of mock objects
            var serviceMock = new Mock<IService>();
            serviceMock.Setup(x => x.Method(45, "Mocks")).Returns(new Result { Number = 22, Text = "Result", IsOk = true });
            
            //Inject mocked dependencies
            var ui = new Presentation(serviceMock.Object);
            
            // Execute the code to be tested
            ResultModel model = ui.UIMethod(45, "Mocks");
            
            // Assert on the expected results
            Assert.AreEqual(22, model.Number);
            Assert.AreEqual("Result", model.Text);
            Assert.IsTrue(model.IsOk);
            
            // Verify that the mock object was called the expected number of times and with the expected parameters
            serviceMock.Verify(x => x.Method(45, "Mocks"), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "I'm an exception!")]
        public void UIMethodException()
        {
            // Setup preconditions including the setup of mock objects
            var serviceMock = new Mock<IService>();
            serviceMock.Setup(x => x.Method(45, "Mocks")).Throws(new Exception("I'm an exception!"));

            //Inject mocked dependencies
            var ui = new Presentation(serviceMock.Object);

            // Execute the code to be tested
            ui.UIMethod(45, "Mocks");

            //ExpectedException will fail the test if the exception is not thrown
        }
    }
}
