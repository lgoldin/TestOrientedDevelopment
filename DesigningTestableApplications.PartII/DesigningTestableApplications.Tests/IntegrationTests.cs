using System;
using System.Collections.Generic;
using System.Linq;
using DesigningTestableApplications.Application;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesigningTestableApplications.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestInitialize]
        public void SetUp()
        {
            using (var context = new DesigningTestableApplicationsEntities())
            {
                var order = new Order
                {
                    Currency = context.Currencies.Where(x => x.Code == "ARS").FirstOrDefault(),
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

                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetOrders()
        {
            var ordersRepository = new OrdersRepository();
            IList<Order> orders = ordersRepository.GetOrders();
        }

        [TestCleanup]
        public void CleanUp()
        {
            using (var context = new DesigningTestableApplicationsEntities())
            {
                foreach (Order order in context.Orders)
                {
                    context.Orders.Remove(order);
                }

                context.SaveChanges();
            }
        }
    }
}
