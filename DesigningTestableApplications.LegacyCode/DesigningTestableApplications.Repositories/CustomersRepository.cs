using System.Linq;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;

namespace DesigningTestableApplications.Repositories
{
    public class CustomersRepository
    {
        public Customer GetById(int id)
        {
            using (var context = new DesigningTestableApplicationsEntities())
            {
                return context.Customers.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
