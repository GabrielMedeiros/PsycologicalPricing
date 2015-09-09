using System;
using System.Text.RegularExpressions;

namespace PsychologicalPricing
{
    public class PriceEndTemplate
    {
        public string Value { get; private set; }
        public int IntValue { get; private set; }
        public int CountFixedDigits { get;private set; }

        public PriceEndTemplate(string template)
        {
            Value = Validate(template) ? template : "#.##";

            var simplifyedValue = template.Replace("#", "").Replace(".", "");

            CountFixedDigits = simplifyedValue.Length;

            int intValue;
            int.TryParse(simplifyedValue, out intValue);

            IntValue = intValue;

        }

        public static bool Validate(string template)
        {
            return template != null 
                && Regex.IsMatch(template, @"^(#|\d)\.(#|\d)(\d)$")
                && !Regex.IsMatch(template, @"^\d\.#\d$");
        }
    }
}