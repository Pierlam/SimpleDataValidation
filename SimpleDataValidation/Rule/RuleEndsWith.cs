using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleEndsWith: RuleBase
{
    public string End { get; private set; }
    public RuleEndsWith(string end)
    {
        End = end;
    }   
}
