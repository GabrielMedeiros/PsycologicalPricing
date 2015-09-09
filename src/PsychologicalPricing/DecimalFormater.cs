using System;
using System.Globalization;

namespace PsychologicalPricing
{
    public static class DecimalFormater
    {
        public static decimal Format(decimal entryNumber, PriceEndTemplate template)
        {
            var strValue = entryNumber.ToString(CultureInfo.InvariantCulture);

            var fixedDigits = (template.CountFixedDigits == 3) ? 4 : template.CountFixedDigits;

            var sub = strValue.Substring(0, strValue.Length - fixedDigits);

            var value = Convert.ToDecimal(sub + template.IntValue);

            return  value / 100;
        }
    }
}