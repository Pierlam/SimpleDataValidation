using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleBetweenLength : RuleBase
{
    public RuleBetweenLength(int minLength, int maxLength)
        : this(minLength, maxLength, null)
    {
    }

    public RuleBetweenLength(int minLength, int maxLength, string errorMessage)
    {
        MinLength = minLength;
        MaxLength = maxLength;
        ErrorMessage = errorMessage;
    }

    public int MinLength { get; }

    public int MaxLength { get; }

    public string ErrorMessage { get; }
}
