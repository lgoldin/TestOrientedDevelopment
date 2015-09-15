using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;

namespace DesigningTestableApplications.Application
{
    public class OrdersRepository
    {
        private DesigningTestableApplicationsEntities context;

        public OrdersRepository(DesigningTestableApplicationsEntities context)
        {
            this.context = context;
        }

        public IList<Order> GetOrders()
        {
            return this.context.Orders.Include("Currency").Include("Customer").Include("OrderItems").Include("OrderItems.Product").ToList();
        }

        public void AddOrder(Order order)
        {
            this.context.Orders.Add(order);
            this.context.SaveChanges();
        }
    }
}
