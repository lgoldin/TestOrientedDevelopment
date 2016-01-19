using System.Linq;

namespace DesigningTestableApplications.Model
{
    public partial class Order
    {
        public virtual decimal GetAmount()
        {
            return
                this.OrderItems.Sum(x => x.Quantity * (x.Product.Prices.First(y => y.Currency.Id == this.CurrencyId)).Amount);
        }
    }
}
