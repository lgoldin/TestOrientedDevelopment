using System.Linq;
using DesigningTestableApplications.Model;
using DesigningTestableApplications.ORM;

namespace DesigningTestableApplications.Repositories
{
    public class CurrenciesRepository
    {
        public Currency GetCurrencyByCode(string code)
        {
            using (var context = new DesigningTestableApplicationsEntities())
            {
                return context.Currencies.FirstOrDefault(x => x.Code == code);
            }
        }
    }
}
