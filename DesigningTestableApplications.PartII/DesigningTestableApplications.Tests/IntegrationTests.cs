using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DesigningTestableApplications.Application;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesigningTestableApplications.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        protected DesigningTestableApplicationsEntities dbContext;
        protected TransactionScope transactionScope;

        [TestInitialize]
        public void SetUp()
        {
            this.dbContext = new DesigningTestableApplicationsEntities();
            this.transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);

            var order = new Order
            {
                Currency = this.dbContext.Currencies.Where(x => x.Code == "ARS").FirstOrDefault(),
                Customer = new Customer
                {
                    Active = true,
                    Address = "Roosevelt 1655",
                    Email = "jdoe@baufest.com",
                    FirstName = "John",
                    LastName = "Doe",
                    Phone = "4855-5572"
                },
                Date = new DateTime(2015, 08, 18),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 3, Quantity = 2 },
                    new OrderItem { ProductId = 4, Quantity = 1 },
                    new OrderItem { ProductId = 2, Quantity = 3 }
                }
            };

            this.dbContext.Orders.Add(order);
            this.dbContext.SaveChanges();
        }

        [TestMethod]
        public void GetOrders()
        {
            var ordersRepository = new OrdersRepository(this.dbContext);
            IList<Order> orders = ordersRepository.GetOrders();

            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual("ARS", orders[0].Currency.Code);
            Assert.AreEqual("John", orders[0].Customer.FirstName);
            Assert.AreEqual("Doe", orders[0].Customer.LastName);
            Assert.IsTrue(orders[0].Customer.Active);
            Assert.AreEqual("18/08/2015", orders[0].Date.ToString("dd/MM/yyyy"));

            Assert.AreEqual(3, orders[0].OrderItems.Count);
            Assert.AreEqual(3, orders[0].OrderItems.ElementAt(0).ProductId);
            Assert.AreEqual(2, orders[0].OrderItems.ElementAt(0).Quantity);
        }

        [TestMethod]
        public void AddOrder()
        {
            var ordersRepository = new OrdersRepository(this.dbContext);
            ordersRepository.AddOrder(new Order
            {
                Currency = this.dbContext.Currencies.Where(x => x.Code == "ARS").FirstOrDefault(),
                Customer = this.dbContext.Customers.Where(x => x.FirstName == "John" && x.LastName == "Doe").FirstOrDefault(),
                Date = new DateTime(2015, 09, 15),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 2, Quantity = 1 },
                    new OrderItem { ProductId = 4, Quantity = 2 }
                }
            });

            IList<Order> orders = ordersRepository.GetOrders();

            Assert.AreEqual(2, orders.Count);
            Assert.AreEqual("ARS", orders[1].Currency.Code);
            Assert.AreEqual("John", orders[1].Customer.FirstName);
            Assert.AreEqual("Doe", orders[1].Customer.LastName);
            Assert.IsTrue(orders[1].Customer.Active);
            Assert.AreEqual("15/09/2015", orders[1].Date.ToString("dd/MM/yyyy"));

            Assert.AreEqual(2, orders[1].OrderItems.Count);
            Assert.AreEqual(2, orders[1].OrderItems.ElementAt(0).ProductId);
            Assert.AreEqual(1, orders[1].OrderItems.ElementAt(0).Quantity);
            Assert.AreEqual(4, orders[1].OrderItems.ElementAt(1).ProductId);
            Assert.AreEqual(2, orders[1].OrderItems.ElementAt(1).Quantity);
        }

        [TestCleanup]
        public void CleanUp()
        {
            this.transactionScope.Dispose();
            this.dbContext.Dispose();
        }
    }
}
