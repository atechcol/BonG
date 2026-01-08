using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace BonG.Store.Data
{
    public class PurchasedProductData
    {
        ProductData Product { get; set; } 
        int Quantity { get; set; }
    }
}