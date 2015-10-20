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

            order.Currency = currenciesRepository.GetCurrencyByCode(order.Currency.Code);
            
            order.OrderItems.ToList().ForEach(x => x.Product = productsRepository.GetById(x.ProductId));

            if (order.OrderItems.Sum(x => x.Quantity * (x.Product.Prices.First(y => y.Currency.Code == order.Currency.Code)).Amount) > 20000)
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
