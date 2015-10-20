using System.Linq;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;

namespace DesigningTestableApplications.Repositories
{
    public class CustomersRepository
    {
        public Customer GetCustomer(string firstName, string lastName, string email)
        {
            using (var context = new DesigningTestableApplicationsEntities())
            {
                return context.Customers.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName && x.Email == email);
            }
        }
    }
}
