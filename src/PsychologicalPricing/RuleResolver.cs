using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalPricing
{
    public class RuleResolver
    {
        private readonly IList<Rule> _rules;

        public RuleResolver(IList<Rule> rules )
        {
            if(rules == null || rules.Count == 0)
                throw new ArgumentException("wrong format","rules");

            _rules = rules.OrderByDescending(x=>x.PriceTemplate.CountFixedDigits).ToList();
        }

        public decimal GetPsycologicalPrice(decimal price)
        {

            foreach (var rule in _rules)
            {
                if (rule.IsInRage(price))
                    return rule.ApplyRule(price);
            }

            return price;
        }

    }
}