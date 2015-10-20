using System;
using System.Collections.Generic;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.Services;

namespace DesigningTestableApplications.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new OrdersService();
            service.AddOrder(new Order
            {
                Currency = new Currency { Code = "ARS" },
                Customer = new Customer { FirstName = "John", LastName = "Doe", Email = "jdoe@baufest.com" },
                Date = new DateTime(2015, 10, 20),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 2, Quantity = 1 },
                    new OrderItem { ProductId = 4, Quantity = 2 }
                }
            });

            service.AddOrder(new Order
            {
                Currency = new Currency { Code = "ARS" },
                Customer = new Customer { FirstName = "Mary", LastName = "Jane", Email = "mjane@baufest.com" },
                Date = new DateTime(2015, 10, 20),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 2, Quantity = 3 }
                }
            });

            IList<Order> orders = service.GetOrders();
            ShowOrders(orders);
        }

        private static void ShowOrders(IList<Order> orders)
        {
        }
    }
}
