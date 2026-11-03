using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleNotContains : RuleBase
{
    public RuleNotContains(string notContains)
    {
        NotContains = notContains;
    }
    public string NotContains { get; set; }
}
