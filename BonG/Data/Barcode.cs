using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonG.Data
{

    public abstract class Barcode(string Indicator, string CompanyItem, string CheckDigit)
    {

        public string Indicator { get; set; } = Indicator;
        public string CompanyItem { get; set; } = CompanyItem;
        public string CheckDigit { get; set; } = CheckDigit;

        public byte CheckDigitByte => Convert.ToByte(this.CheckDigit);

        public Barcode(byte indicator, long companyItem, byte checkDigit) : this(
            indicator.ToString(),
            companyItem.ToString(),
            checkDigit.ToString())
        {

        }

        public abstract int GetManufacturerCode();
        public abstract int GetItemCode();

        public abstract bool Check();
    }

    /// <summary>
    ///  
    /// </summary>
    /// <param name="CompanyItem"> An integer between 0 and 9999999999, represents the item</param>
    /// <param name="CheckDigit"> An integer between 0 and 9, for error correction</param>
    /// <returns></returns>
    public class GTIN13Barcode : Barcode
    {
        public GTIN13Barcode(string companyItem, string checkDigit) : base("0", companyItem, checkDigit)
        {
        }

        // https://en.wikipedia.org/wiki/Check_digit#UPC,_EAN,_GLN,_GTIN,_numbers_administered_by_GS1
        public override bool Check()
        {
            long result = 0;

            // Odd sum
            for (int i = 0; i < 11; i += 2)
            {
                result += long.Parse([this.CompanyItem[i]]);
            }
            result *= 3;

            // Even sum
            for (int i = 1; i < 11; i += 2)
            {
                result += long.Parse([this.CompanyItem[i]]);
            }

            long remainder = (result % 10) == 0 ? 0 : 10 - (result % 10);
            return remainder == this.CheckDigitByte;

        }
        public override int GetManufacturerCode()
        {
            throw new NotImplementedException();
        }

        public override int GetItemCode()
        {
            throw new NotImplementedException();
        }

    }
}