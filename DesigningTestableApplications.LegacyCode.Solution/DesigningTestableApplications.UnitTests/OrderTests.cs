using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DesigningTestableApplications.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
