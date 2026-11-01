using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleNotContainsCaseInsensitive: RuleBase
{
    public string NotContains { get; private set; }
    public RuleNotContainsCaseInsensitive(string notContains)
    {
        NotContains = notContains;
    }
}
