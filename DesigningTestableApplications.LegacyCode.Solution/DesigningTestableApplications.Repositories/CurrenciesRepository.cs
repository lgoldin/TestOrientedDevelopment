using System.Linq;
using DesigningTestableApplications.Interfaces.Repositories;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.Interfaces;

namespace DesigningTestableApplications.Repositories
{
    public class CurrenciesRepository : Repository, ICurrenciesRepository
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
