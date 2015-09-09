using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PsychologicalPricing.Test
{
    [TestFixture]
    public class RuleResolverTest
    {

        [Test]
        public void ThreeDigitTest()
        {
            var rule = new Rule("9.90", "0.00", "3.99");

            var ruleResolver = new RuleResolver(new[] { rule });

            var psycPrice = ruleResolver.GetPsycologicalPrice(13.08m);

            Assert.AreEqual(19.90m, psycPrice);
        }

        [Test]
        public void TwoDigitTest()
        {
            var rule = new Rule("#.99", "#.00", "#.99");

            var ruleResolver = new RuleResolver(new[] {rule});

            var psycPrice = ruleResolver.GetPsycologicalPrice(13.08m);

            Assert.AreEqual(13.99m,psycPrice);
        }

        [Test]
        public void OneDigitTest()
        {
            var rule = new Rule("#.#9", "#.#0", "#.#9");

            var ruleResolver = new RuleResolver(new[] { rule });

            var psycPrice = ruleResolver.GetPsycologicalPrice(13.08m);

            Assert.AreEqual(13.09m, psycPrice);
        }

        [Test]
        public void NoRuleApply()
        {
            var ruleResolver = new RuleResolver(new[]
            {
                new Rule("#.#9", "#.#0", "#.#8"),
                new Rule("#.99", "#.00", "#.58"),
                new Rule("9.99", "0.00", "2.98")
            });

            var psycPrice = ruleResolver.GetPsycologicalPrice(13.79m);

            Assert.AreEqual(13.79m, psycPrice);
        }

        [Test]
        public void NoRule()
        {
            Assert.Throws<ArgumentException>(()=> new RuleResolver(new List<Rule>()));
       }
    }
}