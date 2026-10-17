using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleStartsWith : RuleBase
{
    public RuleStartsWith(string start)
    {
        Start = start;
    }

    public string Start { get; set; }
}
