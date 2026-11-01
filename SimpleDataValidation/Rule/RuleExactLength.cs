using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleExactLength : RuleBase
{
    public RuleExactLength(int length)
        : this(length, null)
    {
    }
    public RuleExactLength(int length, string errorMessage)
    {
        Length = length;
    }
    public int Length { get; }
}
