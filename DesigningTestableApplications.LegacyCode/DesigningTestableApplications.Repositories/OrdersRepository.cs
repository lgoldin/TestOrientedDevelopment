using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;

namespace DesigningTestableApplications.Repositories
{
    public class OrdersRepository
    {
        public IList<Order> GetOrders()
        {
            using (var context = new DesigningTestableApplicationsEntities())
            {
                return context.Orders.Include("OrderItems.Product.Prices").Include(x => x.Customer).ToList();
            }
        }

        public void AddOrder(Order order)
        {
            using (var context = new DesigningTestableApplicationsEntities())
            {
                context.Orders.Add(order);
                
                order.OrderItems.ToList().ForEach(x => 
                {
                    context.Products.Attach(x.Product);
                    context.Prices.Attach(x.Product.Prices.FirstOrDefault(y => y.CurrencyId == order.CurrencyId));
                });
                context.Currencies.Attach(order.Currency);
                context.Customers.Attach(order.Customer);
                
                context.SaveChanges();
            }
        }
    }
}
