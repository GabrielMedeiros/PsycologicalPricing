using NUnit.Framework;

namespace PsychologicalPricing.Test
{
    [TestFixture]
    public class DecimalFormatTest
    {
        [TestCase("#.#9", 13.08, 13.09)]
        [TestCase("#.99", 13.08, 13.99)]
        [TestCase("9.99", 13.08, 19.99)]
        public void Parse_template(string template, decimal entryNumber, decimal expectedNumber)
        {
            var priceEndTemplate = new PriceEndTemplate(template);

            var actualNumber = DecimalFormater.Format(entryNumber, priceEndTemplate);
            
            Assert.AreEqual(expectedNumber, actualNumber);
        }
    }
}