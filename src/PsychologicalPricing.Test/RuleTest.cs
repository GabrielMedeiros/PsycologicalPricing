using System;
using NUnit.Framework;

namespace PsychologicalPricing.Test
{
    [TestFixture]
    public class RuleTest
    {
        [TestCase("#.11","#.#1","1.11")]
        [TestCase("#.11","#.11","1.11")]
        [TestCase("#.11","1.11","1.11")]
        [TestCase("#.11","#.#1","#.11")]
        public void AllTemplatesMustHaveTheSameQuantityOfFixedDigits(string priceTemplate, string beginTemplate, string endTemplate)
        {
            Assert.Throws<ArgumentException>(() => new Rule(priceTemplate, beginTemplate, endTemplate));
        }

        [TestCase("#.11", "#.17", 2.12)]
        [TestCase("#.11", "#.17", 2.11)]
        [TestCase("#.11", "#.17", 2.17)]
        [TestCase("#.#1", "#.#7", 2.17)]
        [TestCase("2.11", "2.20", 2.17)]
        public void RuleRange_IsInRageTest(string beginTemplate, string endTemplate, decimal testNumber)
        {
            var rule = new Rule(beginTemplate,beginTemplate,endTemplate);

            Assert.IsTrue(rule.IsInRage(testNumber));
        }

        [TestCase("#.11", "#.17", 2.10)]
        [TestCase("#.11", "#.17", 2.18)]
        public void RuleRange_NotInRageTest(string beginTemplate, string endTemplate, decimal testNumber)
        {
            var rule = new Rule(beginTemplate, beginTemplate, endTemplate);

            Assert.IsFalse(rule.IsInRage(testNumber));
        }
    }
}