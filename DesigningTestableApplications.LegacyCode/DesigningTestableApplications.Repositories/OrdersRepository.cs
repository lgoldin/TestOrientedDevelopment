using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DesigningTestableApplications.Model;

namespace DesigningTestableApplications.Repositories
{
    public class OrdersRepository : Repository
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
