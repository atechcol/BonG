using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonG.Data
{

    public abstract record Barcode(int Indicator, int CompanyItem, int CheckDigit)
    {
        public abstract bool Check();
    }

    public record GTIN13Barcode(int CompanyItem, int CheckDigit) : Barcode(0, CompanyItem, CheckDigit)
    {
        public override bool Check()
        {
            return true;
        }
    }
}