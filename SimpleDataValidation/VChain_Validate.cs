using SimpleDataValidation.ErrorMsg;
using SimpleDataValidation.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;

public partial class VChain
{
    /// <summary>
    /// Apply the defined validation rules to the value and return an error message if any rule fails. If all rules pass, return an empty string.
    /// </summary>
    /// <returns></returns>
    public string Validate()
    {
        return Validate(ValidOptions.ContinueOnAllErrors);
    }

    /// <summary>
    /// Only one rule have to be validate, then the returned error message will be empty.
    /// </summary>
    /// <returns></returns>
    public string ValidateMinOne()
    {
        return Validate(ValidOptions.ContinueOnAllErrors, true);
    }

    /// <summary>
    /// Apply the defined validation rules to the value and return an error message if any rule fails. If all rules pass, return an empty string.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public string Validate(ValidOptions options)
    {
        return Validate(options, false);
    }

    /// <summary>
    /// Apply the defined validation rules to the value and return an error message if any rule fails. If all rules pass, return an empty string.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    private string Validate(ValidOptions options, bool minOne)
    {
        string finalErrMsg = string.Empty;
        foreach (var rule in _ruleBases)
        {
            string errMsg = RuleValidator.Validate(_errorMessageMgr, rule, _dataName, _value);

            // minOne flag is true?
            if(minOne && string.IsNullOrEmpty(errMsg))
            {
                return string.Empty;
            }

            if (!string.IsNullOrEmpty(errMsg))
            {
                if (!string.IsNullOrEmpty(finalErrMsg))
                {
                    finalErrMsg += _errorMessageMgr.BetweenMsg;
                }
                finalErrMsg += errMsg;
            }

            // stop on the first error, if the option is set to StopOnFirstError and an error message has been generated
            if (options == ValidOptions.StopOnFirstError && !string.IsNullOrEmpty(finalErrMsg))
            {
                return finalErrMsg.Trim();
                //break;
            }
        }

        // trim the final error message to remove any leading or trailing whitespace and return it
        return finalErrMsg.Trim();
    }

}
