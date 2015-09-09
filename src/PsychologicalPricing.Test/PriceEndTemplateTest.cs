using NUnit.Framework;

namespace PsychologicalPricing.Test
{
    [TestFixture]
    public class PriceEndTemplateTest
    {
        [TestCase("#.#1")]
        [TestCase("#.11")]
        [TestCase("1.11")]
        [TestCase("#.00")]
        [TestCase("#.#9")]
        [TestCase("#.#9")]
        public void TestAlowedValues(string template)
        {
            Assert.IsTrue(PriceEndTemplate.Validate(template));
        }

        [TestCase("a")]
        [TestCase("a.#1")]
        [TestCase("1")]
        [TestCase("1.1")]
        [TestCase("1.1#")]
        [TestCase("1.#1")]
        [TestCase("#,##")]
        [TestCase("##,##")]
        [TestCase("123,12#")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void TestDisalowedValues(string template)
        {
            Assert.IsFalse(PriceEndTemplate.Validate(template));
        }

        [TestCase("#.##", 0)]
        [TestCase("#.#1", 1)]
        [TestCase("#.11", 2)]
        [TestCase("1.11", 3)]
        public void FixedDigits(string template, int expectedFixedDigits)
        {
            var priceEndTemplate = new PriceEndTemplate(template);

            Assert.AreEqual(expectedFixedDigits,priceEndTemplate.CountFixedDigits);

        }

        [TestCase("#.##", 0)]
        [TestCase("#.#1", 1)]
        [TestCase("#.21", 21)]
        [TestCase("3.21", 321)]
        public void IntValue(string template, int expectedInt)
        {
            var priceEndTemplate = new PriceEndTemplate(template);

            Assert.AreEqual(expectedInt,priceEndTemplate.IntValue);

        }
    }
}

