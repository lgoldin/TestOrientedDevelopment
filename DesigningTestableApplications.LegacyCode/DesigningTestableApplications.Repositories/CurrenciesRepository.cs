using System.Linq;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;

namespace DesigningTestableApplications.Repositories
{
    public class CurrenciesRepository : Repository
    {
        public Currency GetByCode(string code)
        {
            return Context.Currencies.FirstOrDefault(x => x.Code == code);
        }

        public Currency GetById(int id)
        {
            return Context.Currencies.FirstOrDefault(x => x.Id == id);
        }
    }
}
