using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;

namespace DesigningTestableApplications.Repositories
{
    public class ProductsRepository
    {
        public Product GetGift()
        {
            using (var context = new DesigningTestableApplicationsEntities())
            {
                return context.Products.FirstOrDefault(x => x.Name == "Pen Drive Gift");
            }
        }
    }
}
