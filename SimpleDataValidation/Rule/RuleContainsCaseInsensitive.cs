using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleContainsCaseInsensitive: RuleBase
{
    public string Contains { get; private set; }
    public RuleContainsCaseInsensitive(string contains)
    {
        Contains = contains;
    }
}
