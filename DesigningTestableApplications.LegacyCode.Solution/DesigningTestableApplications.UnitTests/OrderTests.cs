using System.Collections.Generic;
using System.Collections.ObjectModel;
using DesigningTestableApplications.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DesigningTestableApplications.UnitTests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void GetAmount()
        {
            var order = new Order
                {
                    CurrencyId = 1,
                    OrderItems = new List<OrderItem>
                        {
                            new OrderItem
                                {
                                    Product = new Product
                                        {
                                            Id = 1,
                                            Prices =
                                                new Collection<Price>
                                                    {
                                                        new Price
                                                            {
                                                                Currency = new Currency {Code = "ARS", Id = 1},
                                                                Amount = 100
                                                            }
                                                    }
                                        },
                                    Quantity = 1
                                },
                            new OrderItem
                                {
                                    Product = new Product
                                        {
                                            Id = 4,
                                            Prices =
                                                new Collection<Price>
                                                    {
                                                        new Price
                                                            {
                                                                Currency = new Currency {Code = "ARS", Id = 1},
                                                                Amount = 299.99M
                                                            }
                                                    }
                                        },
                                    Quantity = 2
                                }
                        }
                };

            decimal amount = order.GetAmount();

            Assert.AreEqual(699.98M, amount);
        }

        [TestMethod]
        public void GetPointsX1()
        {
            var order = new Order();
            var amount = 100M;

            var points = order.GetPoints(amount);

            Assert.AreEqual(100, points);
        }


        [TestMethod]
        public void GetPointsX2()
        {
            var order = new Order();
            var amount = 5000M;

            var points = order.GetPoints(amount);

            Assert.AreEqual(10000M, points);
        }

        [TestMethod]
        public void GetPointsX3()
        {
            var order = new Order();
            var amount = 10000M;

            var points = order.GetPoints(amount);

            Assert.AreEqual(30000M, points);
        }

        [TestMethod]
        public void GetPointsX4()
        {
            var order = new Order();
            var amount = 20000M;

            var points = order.GetPoints(amount);

            Assert.AreEqual(80000M, points);
        }

        [TestMethod]
        public void GetPointsParameterless()
        {
            var mock = new Mock<Order>();
            mock.Setup(x => x.GetAmount()).Returns(7999.9M);
            mock.Setup(x => x.GetPoints(8000M)).Returns(16000);

            mock.CallBase = true;

            var order = mock.Object;

            var points = order.GetPoints();

            Assert.AreEqual(16000, points);

            mock.Verify(x => x.GetAmount(), Times.Once);
            mock.Verify(x => x.GetPoints(8000M), Times.Once);
        }
    }
}
