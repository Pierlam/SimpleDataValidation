using SimpleDataValidation.Rule;

namespace SimpleDataValidation;

public partial class V
{
    /// <summary>
    /// The name of the data field being validated. This is used in error messages to indicate which field has failed validation.
    /// </summary>
    protected string _dataName;

    /// <summary>
    /// The value being validated. This is the actual data that will be checked against the defined validation rules.
    /// </summary>
    protected string _value;

    /// <summary>
    /// To save the list of validation rules that have been defined for this instance of the V class. Each rule is represented by an instance of a class that inherits from RuleBase.
    /// </summary>
    protected List<RuleBase> _ruleBases = new List<RuleBase>();

    /// <summary>
    /// Constructor for the V class, initializing the validation context with the specified field name and value.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    public V(string dataName, string value)
    {
        _dataName = dataName;
        _value = value;
    }

    /// <summary>
    /// Apply the defined validation rules to the value and return an error message if any rule fails. If all rules pass, return an empty string.
    /// </summary>
    /// <returns></returns>
    public string Validate()
    {
        return Validate(ValidOptions.ContinueOnAllErrors);
    }

    /// <summary>
    /// Apply the defined validation rules to the value and return an error message if any rule fails. If all rules pass, return an empty string.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public string Validate(ValidOptions options)
    {
        string finalErrMsg = string.Empty;
        foreach (var rule in _ruleBases)
        {
            string errMsg = RuleValidator.Validate(_errorMessageMgr, rule, _dataName, _value);
            if (!string.IsNullOrEmpty(errMsg))
            {
                if (!string.IsNullOrEmpty(finalErrMsg))
                {
                    finalErrMsg += _errorMessageMgr.BetweenMsg;
                }
                finalErrMsg += errMsg;
            }
            if (options == ValidOptions.StopOnFirstError && !string.IsNullOrEmpty(finalErrMsg))
            {
                break;
            }
        }
        return finalErrMsg.Trim();
    }

}
