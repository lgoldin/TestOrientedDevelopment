using System.Collections.Generic;
using System.Linq;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;

namespace DesigningTestableApplications.Application
{
    public class OrdersRepository
    {
        private readonly DesigningTestableApplicationsEntities context;

        public OrdersRepository(DesigningTestableApplicationsEntities context)
        {
            this.context = context;
        }

        public IList<Order> GetOrders()
        {
            return this.context.Orders.ToList();
        }

        public void AddOrder(Order order)
        {
            this.context.Orders.Add(order);
            this.context.SaveChanges();
        }
    }
}
