using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace BonG.Store.Data
{
    public class PurchaseData
    {
        DateTime Timestamp { get; set; }
        IEnumerable<PurchasedProductData> Products { get; set; }
        float Total { get; set; }
    }
}