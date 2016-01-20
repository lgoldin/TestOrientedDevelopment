using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;
using DesigningTestableApplications.Repositories;
using DesigningTestableApplications.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesigningTestableApplications.IntegrationTests
{
    [TestClass]
    public class IntegrationTests
    {
        private DesigningTestableApplicationsEntities dbContext;
        private TransactionScope transactionScope;

        [TestInitialize]
        public void SetUp()
        {
            this.dbContext = Repository.Context;
            this.transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);
        }

        [TestMethod]
        public void AddOrderWithGift()
        {
            var ordersService = new OrdersService();

            ordersService.AddOrder(new Order
            {
                CurrencyId = 1,
                CustomerId = 1,
                Date = new DateTime(2015, 10, 20),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 2, Quantity = 1 },
                    new OrderItem { ProductId = 4, Quantity = 2 }
                }
            });

            Order order = this.dbContext.Orders.Include("OrderItems").FirstOrDefault();
            Assert.IsNotNull(order);
            Assert.AreEqual(3, order.OrderItems.Count);
            Assert.AreEqual(2, order.OrderItems.ElementAt(0).ProductId);
            Assert.AreEqual(1, order.OrderItems.ElementAt(0).Quantity);
            Assert.AreEqual(4, order.OrderItems.ElementAt(1).ProductId);
            Assert.AreEqual(2, order.OrderItems.ElementAt(1).Quantity);
            Assert.AreEqual(6, order.OrderItems.ElementAt(2).ProductId);
            Assert.AreEqual(1, order.OrderItems.ElementAt(2).Quantity);

            Assert.AreEqual(30799.77M, order.GetAmount());
            Assert.AreEqual(123200M, order.GetPoints());
        }

        [TestMethod]
        public void AddOrderWithoutGift()
        {
            var ordersService = new OrdersService();

            ordersService.AddOrder(new Order
            {
                CurrencyId = 1,
                CustomerId = 2,
                Date = new DateTime(2015, 10, 20),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 3, Quantity = 1 }
                }
            });

            Order order = this.dbContext.Orders.Include("OrderItems").FirstOrDefault();
            Assert.IsNotNull(order);
            Assert.AreEqual(1, order.OrderItems.Count);
            Assert.AreEqual(3, order.OrderItems.ElementAt(0).ProductId);
            Assert.AreEqual(1, order.OrderItems.ElementAt(0).Quantity);

            Assert.AreEqual(2399.99M, order.GetAmount());
            Assert.AreEqual(2400M, order.GetPoints());
        }

        [TestCleanup]
        public void CleanUp()
        {
            this.transactionScope.Dispose();
        }
    }
}
