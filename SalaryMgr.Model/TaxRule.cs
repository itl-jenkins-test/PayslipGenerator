using System.Collections.Generic;

namespace SalaryMgr.Model
{
    public class TaxRule
    {
        public int BaseTaxAmount { get; private set; }
        public decimal ExcessAmount { get; private set; }
        public int? TaxBracketMax { get; private set; }
        public int TaxBracketMin { get; private set; }
        public string TaxYear { get; private set; }

        public static List<TaxRule> LoadRules()
        {
            var rules = new List<TaxRule>();
            var a = new TaxRule();
            a.TaxBracketMin = 0;
            a.TaxBracketMax = 18200;
            a.BaseTaxAmount = 0;
            a.ExcessAmount = 0;

            rules.Add(a);

            var b = new TaxRule();
            b.TaxBracketMin = 18201;
            b.TaxBracketMax = 37000;
            b.BaseTaxAmount = 0;
            b.ExcessAmount = .19m;
            rules.Add(b);

            var c = new TaxRule();
            c.TaxBracketMin = 37001;
            c.TaxBracketMax = 80000;
            c.BaseTaxAmount = 3572;
            c.ExcessAmount = .325m;
            rules.Add(c);

            var d = new TaxRule();
            d.TaxBracketMin = 80001;
            d.TaxBracketMax = 180000;
            d.BaseTaxAmount = 17547;
            d.ExcessAmount = .37m;

            rules.Add(d);

            var e = new TaxRule();
            e.TaxBracketMin = 180001;
            e.BaseTaxAmount = 54547;
            e.ExcessAmount = .45m;

            rules.Add(e);

            return rules;
        }
    }
}