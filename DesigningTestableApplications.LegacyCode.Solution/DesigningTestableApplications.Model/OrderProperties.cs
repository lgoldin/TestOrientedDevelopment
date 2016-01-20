using System;
using System.Collections.Generic;
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

        public virtual int GetPoints()
        {
            return this.GetPoints(Math.Ceiling(this.GetAmount()));
        }

        public virtual int GetPoints(decimal amount)
        {
            var pointsMultipliers = new List<PointsMultiplier>
                {
                    new PointsMultiplier { LowerLimit = 1M, UpperLimit = 4999M, Multiplier =  1},
                    new PointsMultiplier { LowerLimit = 5000M, UpperLimit = 9999M, Multiplier =  2},
                    new PointsMultiplier { LowerLimit = 10000M, UpperLimit = 19999M, Multiplier =  3},
                    new PointsMultiplier { LowerLimit = 20000M, UpperLimit = decimal.MaxValue, Multiplier =  4}
                };

            return (int) (pointsMultipliers.First(x => x.LowerLimit <= amount && x.UpperLimit >= amount).Multiplier * amount);
        }
    }
}
