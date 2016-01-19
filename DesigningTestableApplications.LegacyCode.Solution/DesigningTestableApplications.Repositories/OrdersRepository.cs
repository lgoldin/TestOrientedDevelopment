using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DesigningTestableApplications.Interfaces;
using DesigningTestableApplications.Interfaces.Repositories;
using DesigningTestableApplications.Model;

namespace DesigningTestableApplications.Repositories
{
    public class OrdersRepository : Repository, IOrdersRepository
    {
        public IList<Order> GetOrders()
        {
            return Context.Orders.Include("OrderItems.Product.Prices").Include(x => x.Customer).ToList();
        }

        public void AddOrder(Order order)
        {
            Context.Orders.Add(order);
            Context.SaveChanges();
        }
    }
}
