using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleDateTimeEquals:RuleBase
{
    public DateTime ExpectedValue { get; set; }
    public RuleDateTimeEquals(DateTime expectedValue)
    {
        ExpectedValue = expectedValue;
    }
}
