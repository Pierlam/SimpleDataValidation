using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleStartsWithCaseInsensitive : RuleBase
{
    public RuleStartsWithCaseInsensitive(string start)
    {
        Start = start;
    }

    public string Start { get; set; }

}
