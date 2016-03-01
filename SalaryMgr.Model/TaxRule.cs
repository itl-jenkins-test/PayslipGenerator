using System.Collections.Generic;

namespace SalaryMgr.Model
{
    /// <summary>
    /// Allows for the TaxRule to be loaded in future from a file on disk or even provided by the execution
    /// </summary>
    public class TaxRule
    {
        public TaxRule(int v1, int? v2, int v3, decimal v4,string taxYear)
        {
            this.TaxBracketMin = v1;
            this.TaxBracketMax = v2;
            this.BaseTaxAmount = v3;
            this.ExcessAmount = v4;
            this.TaxYear = taxYear;
        }

        public int BaseTaxAmount { get; private set; }
        public decimal ExcessAmount { get; private set; }
        public int? TaxBracketMax { get; private set; }
        public int TaxBracketMin { get; private set; }
        public string TaxYear { get; private set; }


        public static List<TaxRule> LoadRules()
        {
            var rules = new List<TaxRule>();
            var a = new TaxRule(0,18200,0,0,"2012-2013");            
            rules.Add(a);

            var b = new TaxRule(18201, 37000, 0, .19m, "2012-2013");    
            rules.Add(b);

            var c = new TaxRule(37001, 80000, 3572, .325m, "2012-2013");
            rules.Add(c);

            var d = new TaxRule(80001, 180000, 1754, .37m, "2012-2013");
            rules.Add(d);

            var e = new TaxRule(180001, null, 54547, .45m, "2012-2013");
            rules.Add(e);

            return rules;
        }
    }
}