using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonG.Store
{
    public class GTIN13BarcodeData
    {
        string Indicator { get; set; }  
        string CompanyItem { get; set; }
        string CheckDigit { get; set; }
    };
}