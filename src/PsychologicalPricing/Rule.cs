using System;

namespace PsychologicalPricing
{
    public class Rule
    {
        public readonly PriceEndTemplate PriceTemplate;

        public readonly PriceEndTemplate BeginTemplate;
        public readonly PriceEndTemplate EndTemplate;

        public Rule(string priceTemplate, string beginTemplate, string endTemplate)
        {
            if (!PriceEndTemplate.Validate(priceTemplate))
                throw new ArgumentException(string.Format("wrong format: {0}", priceTemplate), "priceTemplate");

            if (!PriceEndTemplate.Validate(beginTemplate))
                throw new ArgumentException(string.Format("wrong format: {0}", beginTemplate), "beginTemplate");

            if (!PriceEndTemplate.Validate(endTemplate))
                throw new ArgumentException(string.Format("wrong format: {0}", endTemplate), "endTemplate");

            PriceTemplate = new PriceEndTemplate(priceTemplate);
            BeginTemplate = new PriceEndTemplate(beginTemplate);
            EndTemplate = new PriceEndTemplate(endTemplate);

            if (PriceTemplate.CountFixedDigits != BeginTemplate.CountFixedDigits
                || BeginTemplate.CountFixedDigits != EndTemplate.CountFixedDigits)
                throw new ArgumentException("All templates must have the same quantity of fixed digits.");
        }


        public bool IsInRage(decimal testNumber)
        {
            var begingValue = DecimalFormater.Format(testNumber,BeginTemplate);
            
            var endValue = DecimalFormater.Format(testNumber, EndTemplate);
            
            return begingValue <= testNumber && testNumber <= endValue;
        }

        public decimal ApplyRule(decimal price)
        {
            var transformedPrice = DecimalFormater.Format(price, PriceTemplate);

            return transformedPrice;

        }
        
    }
}
