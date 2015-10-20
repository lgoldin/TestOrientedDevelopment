using System.Collections.Generic;
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
                return context.Orders.ToList();
            }
        }

        public void AddOrder(Order order)
        {
            using (var context = new DesigningTestableApplicationsEntities())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}
