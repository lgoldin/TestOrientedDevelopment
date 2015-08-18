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
        public IList<Order> GetOrders()
        {
            using (var context = new DesigningTestableApplicationsEntities())
            {
                return context.Orders.Include("Currency").Include("Customer").Include("OrderItems").Include("OrderItems.Product").ToList();
            }
        }
    }
}
