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

            order.Customer = customersRepository.GetById(order.CustomerId);

            order.Currency = currenciesRepository.GetById(order.CurrencyId);

            order.OrderItems.ToList().ForEach(x => x.Product = productsRepository.GetById(x.ProductId));

            //Si la suma de los ítems es mayor a 20.000, se le agregará un ítem de regalo
            if (order.OrderItems.Sum(x => x.Quantity * (x.Product.Prices.First(y => y.Currency.Id == order.CurrencyId)).Amount) > 20000)
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
