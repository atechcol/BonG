using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonG.Data
{
    public record PurchasedProduct(Product Product, int Quantity);
}