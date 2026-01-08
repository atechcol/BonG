using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonG.Data
{
    public record Purchase(DateTime Timestamp, IEnumerable<PurchasedProduct> Products, float Total)
    {
     
    }
}