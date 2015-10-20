using System;
using System.Linq;
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
                Customer = new Customer
                {
                    Active = true,
                    Address = "Roosevelt 1655",
                    Email = "jdoe@baufest.com",
                    FirstName = "John",
                    LastName = "Doe",
                    Phone = "4855-5572"
                },
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
                Customer = new Customer
                    {
                        FirstName = "Mary", 
                        LastName = "Jane", 
                        Email = "mjane@baufest.com", 
                        Active = true, 
                        Address = "Las Heras 568",
                        Phone = "49623699"
                    },
                Date = new DateTime(2015, 10, 20),
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = 2, Quantity = 3 }
                }
            });

            IList<Order> orders = service.GetOrders();
            ShowOrders(orders);
            System.Console.ReadKey();
        }

        private static void ShowOrders(IEnumerable<Order> orders)
        {
            System.Console.WriteLine("---------------------------------------------------");

            foreach (Order order in orders)
            {
                System.Console.WriteLine("{0} {1} {2}", order.Customer.LastName, order.Customer.FirstName, order.Customer.Email);

                foreach (OrderItem item in order.OrderItems)
                {
                    System.Console.WriteLine("-- {0} {1} {2} {3}", item.Product.Name, item.Quantity, item.Product.Prices.First().Amount.ToString("C2"), (item.Quantity * item.Product.Prices.First().Amount).ToString("C2"));
                }
            }
             
            System.Console.WriteLine("---------------------------------------------------");
        }
    }
}
