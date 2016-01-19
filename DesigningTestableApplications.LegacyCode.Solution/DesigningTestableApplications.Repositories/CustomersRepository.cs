using System.Linq;
using DesigningTestableApplications.Interfaces.Repositories;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.Interfaces;

namespace DesigningTestableApplications.Repositories
{
    public class CustomersRepository : Repository, ICustomersRepository
    {
        public Customer GetById(int id)
        {
            return Context.Customers.FirstOrDefault(x => x.Id == id);
        }
    }
}
