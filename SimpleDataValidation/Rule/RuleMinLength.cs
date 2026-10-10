using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleMinLength : RuleBase
{
    public RuleMinLength(int minLength)
    {
        MinLength = minLength;
    }

    public int MinLength { get; }

}
