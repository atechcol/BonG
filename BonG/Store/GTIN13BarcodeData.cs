using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonG.Store
{
    public record GTIN13BarcodeData(string Indicator, string CompanyItem, string CheckDigit);
}