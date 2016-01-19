using DesigningTestableApplications.Model;

namespace DesigningTestableApplications.Interfaces.Repositories
{
    public interface ICurrenciesRepository
    {
        Currency GetByCode(string code);
        Currency GetById(int id);
    }
}
