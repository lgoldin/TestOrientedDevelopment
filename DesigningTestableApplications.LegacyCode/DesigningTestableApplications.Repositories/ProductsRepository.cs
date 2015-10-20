using System.Linq;
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
                return context.Products.Include("Prices.Currency").FirstOrDefault(x => x.Name == "Pen Drive Gift");
            }
        }

        public Product GetById(int id)
        {
            using (var context = new DesigningTestableApplicationsEntities())
            {
                return context.Products.Include("Prices.Currency").FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
