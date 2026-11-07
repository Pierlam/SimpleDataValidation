using Microsoft.VisualBasic;
using SimpleDataValidation.ErrorMsg;
using SimpleDataValidation.Rule;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleDataValidation;

/// <summary>
/// The RuleValidator class provides static methods for validating data against various rules. It uses the ErrorMessageMgr to retrieve error messages based on the current language and error code. The class includes methods for validating null values, string lengths, email formats, and integer types, returning appropriate error messages when validation fails.
/// </summary>
public partial class RuleValidator 
{
    public static string Validate(ErrorMessageMgr errorMessageMgr, RuleBase rule, string dataName, object value)
    {
        if(rule == null) throw new ArgumentNullException(nameof(rule));

        if (rule is RuleNull)
            return Null(errorMessageMgr, dataName, value?.ToString());

        if (rule is RuleNotNull)
            return NotNull(errorMessageMgr, dataName, value?.ToString());

        if (rule is RuleNotNullOrEmpty)
            return NotNullOrEmpty(errorMessageMgr, dataName, value?.ToString());

        if(rule is RuleNotNullOrWhiteSpace)
            return NotNullOrWhiteSpace(errorMessageMgr, dataName, value?.ToString());

        if (rule is RuleStartsWith ruleStartsWith)
            return StartsWith(errorMessageMgr, dataName, value?.ToString(), ruleStartsWith.Start);

        if(rule is RuleStartsWithCaseInsensitive ruleStartsWithCaseInsensitive)
            return StartsWithCaseInsensitive(errorMessageMgr, dataName, value?.ToString(), ruleStartsWithCaseInsensitive.Start);

        if (rule is RuleEndsWith ruleEndsWith)
            return EndsWith(errorMessageMgr, dataName, value?.ToString(), ruleEndsWith.End);

        if (rule is RuleEndsWithCaseInsensitive ruleEndsWithCaseInsensitive)
            return EndsWithCaseInsensitive(errorMessageMgr, dataName, value?.ToString(), ruleEndsWithCaseInsensitive.End);

        if(rule is RuleContains ruleContains)
            return Contains(errorMessageMgr, dataName, value?.ToString(), ruleContains.Contains);

        if (rule is RuleContainsCaseInsensitive ruleContainsCaseInsensitive)
            return ContainsCaseInsensitive(errorMessageMgr, dataName, value?.ToString(), ruleContainsCaseInsensitive.Contains);

        if (rule is RuleNotContains ruleNotContains)
            return NotContains(errorMessageMgr, dataName, value?.ToString(), ruleNotContains.NotContains);

        if (rule is RuleNotContainsCaseInsensitive ruleNotContainsCaseInsensitive)
            return NotContainsCaseInsensitive(errorMessageMgr, dataName, value?.ToString(), ruleNotContainsCaseInsensitive.NotContains);

        if (rule is RuleFirstCharIn ruleFirstCharIn)
            return FirstCharIn(errorMessageMgr, dataName, value?.ToString(), ruleFirstCharIn.Chars);

        if (rule is RuleFirstCharNotIn ruleFirstCharNotIn)
            return FirstCharNotIn(errorMessageMgr, dataName, value?.ToString(), ruleFirstCharNotIn.Chars);

        if (rule is RuleBetweenLength ruleBetweenLength)
            return BetweenLength(errorMessageMgr, dataName, value?.ToString(), ruleBetweenLength.MinLength, ruleBetweenLength.MaxLength);

        if (rule is RuleMinLength ruleMinLength)
            return MinLength(errorMessageMgr, dataName, value?.ToString(), ruleMinLength.MinLength);

        if(rule is RuleMaxLength ruleMaxLength)
            return MaxLength(errorMessageMgr, dataName, value?.ToString(), ruleMaxLength.MaxLength);

        if (rule is RuleExactLength ruleExactLength)
            return ExactLength(errorMessageMgr, dataName, value?.ToString(), ruleExactLength.Length);

        if (rule is RuleBankCardNumber bankCardNumber)
            return BankCardNumber(errorMessageMgr, dataName, value?.ToString(), bankCardNumber.CardBank);

        throw new NotImplementedException(nameof(rule));
    }


}
