using System.Linq;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;

namespace DesigningTestableApplications.Repositories
{
    public class ProductsRepository : Repository
    {
        public Product GetGift()
        {
            return Context.Products.Include("Prices.Currency").FirstOrDefault(x => x.Name == "Pen Drive Gift");
        }

        public Product GetById(int id)
        {
            return Context.Products.Include("Prices.Currency").FirstOrDefault(x => x.Id == id);
        }
    }
}
