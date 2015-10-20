using System.Collections.Generic;
using System.Linq;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.Repositories;

namespace DesigningTestableApplications.Services
{
    public class OrdersService
    {
        public IList<Order> GetOrders()
        {
            var repository = new OrdersRepository();
            return repository.GetOrders();
        }

        public void AddOrder(Order order)
        {
            var ordersRepository = new OrdersRepository();
            var productsRepository = new ProductsRepository();
            var currenciesRepository = new CurrenciesRepository();
            var customersRepository = new CustomersRepository();

            order.Currency = currenciesRepository.GetCurrencyByCode(order.Currency.Code);
            order.Customer = customersRepository.GetCustomer(order.Customer.FirstName, order.Customer.LastName, order.Customer.Email);

            if (order.OrderItems.Sum(x => x.Quantity * x.Product.Prices.FirstOrDefault(y => y.Currency.Code == order.Currency.Code).Amount) > 20000)
            {
                order.OrderItems.Add(new OrderItem
                {
                    Product = productsRepository.GetGift(),
                    Quantity = 1
                });
            }

            ordersRepository.AddOrder(order);
        }
    }
}
