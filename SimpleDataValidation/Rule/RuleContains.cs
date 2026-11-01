using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleContains:RuleBase
{
    public RuleContains(string contains)
    {
        Contains = contains;
    }
    public string Contains { get; set; }
}
