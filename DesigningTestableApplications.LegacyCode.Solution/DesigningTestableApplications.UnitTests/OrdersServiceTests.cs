using System.Collections.Generic;
using System.Linq;
using DesigningTestableApplications.Interfaces.Repositories;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DesigningTestableApplications.UnitTests
{
    [TestClass]
    public class OrdersServiceTests
    {
        [TestMethod]
        public void AddOrder()
        {
            var ordersRepository = new Mock<IOrdersRepository>();
            var productsRepository = new Mock<IProductsRepository>();
            var customersRepository = new Mock<ICustomersRepository>();

            var customer = new Customer { Id = 11 };
            var firstProduct = new Product { Id = 456 };
            var secondProduct = new Product { Id = 2435 };
            var gift = new Product { Id = 6 };

            customersRepository.Setup(x => x.GetById(11)).Returns(customer);

            productsRepository.Setup(x => x.GetById(456)).Returns(firstProduct);
            productsRepository.Setup(x => x.GetById(2435)).Returns(secondProduct);
            productsRepository.Setup(x => x.GetGift()).Returns(gift);

            var order = new Mock<Order>();
            order.SetupGet(x => x.OrderItems).Returns(new List<OrderItem>
                {
                    new OrderItem { ProductId = 456, Quantity =  1 },
                    new OrderItem { ProductId = 2435, Quantity = 2 }
                });
            order.SetupGet(x => x.CurrencyId).Returns(1);
            order.SetupGet(x => x.CustomerId).Returns(11);
            order.Setup(x => x.GetAmount()).Returns(21999);
            order.Setup(x => x.GetPoints()).Returns(87996);
            order.SetupProperty(x => x.Customer);

            var ordersService = new OrdersService(ordersRepository.Object, productsRepository.Object, customersRepository.Object);

            ordersService.AddOrder(order.Object);

            ordersRepository.Verify(
                x =>
                x.AddOrder(
                    It.Is<Order>(
                        y =>
                        y.Customer == customer && y.CurrencyId == 1 && y.OrderItems.Count == 3 &&
                        y.OrderItems.First(o => o.Product == gift).Quantity == 1 &&
                        y.Customer.Points == 87996)),
                Times.Once);

            customersRepository.Verify(x => x.GetById(11), Times.Once);
            productsRepository.Verify(x => x.GetById(456), Times.Once);
            productsRepository.Verify(x => x.GetById(2435), Times.Once);
            productsRepository.Verify(x => x.GetGift(), Times.Once);
            order.Verify(x => x.GetAmount(), Times.Once);
            order.Verify(x => x.GetPoints(), Times.Once);
        }
    }
}
