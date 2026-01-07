using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonG.Data
{

    public abstract class Barcode(byte Indicator, int CompanyItem, byte CheckDigit)
    {
        public byte Indicator {get; set; } = Indicator;
        public int CompanyItem {get; set; } = CompanyItem;
        public byte CheckDigit {get; set; } = CheckDigit;

        protected int[] indicatorArray = [.. Indicator.ToString().Select(o => Convert.ToInt32(o) - 48)];
        protected int[] companyItemArray = [.. CompanyItem.ToString().Select(o => Convert.ToInt32(o) - 48)];
        protected int[] checkDigitArray = [.. CheckDigit.ToString().Select(o => Convert.ToInt32(o) - 48)];

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
        public GTIN13Barcode(int companyItem, byte checkDigit) : base(0, companyItem, checkDigit)
        {
        }
        public override bool Check()
        {
            int result = 0;
            int remainder = 0;

            // Odd sum
            for (int i = 0; i < 11; i += 2)
            {
                result += this.companyItemArray[i];
            }
            result *= 3;

            // Even sum
            for (int i = 1; i < 11; i += 2)
            {
                result += this.companyItemArray[i];
            }

            remainder = (result % 10) == 0 ? 0 : 10 - (result % 10);

            return remainder == this.CheckDigit;

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