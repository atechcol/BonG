using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonG.Data
{
    // Stregkode bruger GTIN-13-standard
    public record Product(string Name, float Price, Barcode Barcode)
    {

    }
}