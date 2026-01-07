using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonG.Store
{
    public class GTIN13BarcodeData
    {
        public string Indicator { get; set; }
        public string CompanyItem { get; set; }
        public string CheckDigit { get; set; }
    }
}