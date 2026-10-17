using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleFirstCharIn :RuleBase
{
    public RuleFirstCharIn(string chars)
    {
        Chars = chars;
    }

    public string Chars { get; set; }
}
