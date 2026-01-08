using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonG.Store.Data
{
    public class ProductData
    {
        string Name { get; set; }
        float Price { get; set; } 
        GTIN13BarcodeData Barcode { get; set; }
    }
}