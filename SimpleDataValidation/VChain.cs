using SimpleDataValidation.ErrorMsg;
using SimpleDataValidation.Rule;

namespace SimpleDataValidation;

/// <summary>
/// The V class is a simple data validation utility that provides methods to validate data based on defined rules. 
/// It supports multiple languages for error messages and allows chaining of validation rules for a given data field.
/// </summary>
public partial class VChain
{
    /// <summary>
    /// The ErrorMessageMgr instance is responsible for managing error messages, including retrieving the appropriate error message based on the current language and error code. It also provides functionality to set the current language and build the table of error messages for that language.
    /// </summary>
    protected ErrorMessageMgr _errorMessageMgr;

    /// <summary>
    /// The name of the data field being validated. This is used in error messages to indicate which field has failed validation.
    /// </summary>
    protected string _dataName;

    /// <summary>
    /// The value being validated. This is the actual data that will be checked against the defined validation rules.
    /// </summary>
    protected object _value;

    /// <summary>
    /// To save the list of validation rules that have been defined for this instance of the V class. Each rule is represented by an instance of a class that inherits from RuleBase.
    /// </summary>
    protected List<RuleBase> _ruleBases = new List<RuleBase>();


    public VChain(ErrorMessageMgr errorMessageMgr, string dataName, object value)
    {
        _errorMessageMgr = errorMessageMgr;
        _dataName = dataName;
        _value = value;
    }

    public VChain AddTrue()
    {
        _ruleBases.Add(new RuleTrue());
        return this;
    }

    public VChain AddFalse()
    {
        _ruleBases.Add(new RuleFalse());
        return this;
    }

    public VChain AddNull()
    {
        _ruleBases.Add(new RuleNull());
        return this;
    }

    public VChain AddNotNull()
    {
        _ruleBases.Add(new RuleNotNull());
        return this;
    }

    public VChain AddNotNullOrEmpty()
    {
        _ruleBases.Add(new RuleNotNullOrEmpty());
        return this;
    }
    public VChain AddNotNullOrWhiteSpace()
    {
        _ruleBases.Add(new RuleNotNullOrWhiteSpace());
        return this;
    }

    public VChain AddText()
    {
        _ruleBases.Add(new RuleNotNullOrWhiteSpace());
        return this;
    }

    public VChain AddStartsWith(string start)
    {
        _ruleBases.Add(new RuleStartsWith(start));
        return this;
    }

    public VChain AddStartsWithCaseInsensitive(string start)
    {
        _ruleBases.Add(new RuleStartsWithCaseInsensitive(start));
        return this;
    }

    public VChain AddEndsWith(string end)
    {
        _ruleBases.Add(new RuleEndsWith(end));
        return this;
    }

    public VChain AddEndsWithCaseInsensitive(string end)
    {
        _ruleBases.Add(new RuleEndsWithCaseInsensitive(end));
        return this;
    }

    public VChain AddContains(string substring)
    {
        _ruleBases.Add(new RuleContains(substring));
        return this;
    }

    public VChain AddContainsCaseInsensitive(string substring)
    {
        _ruleBases.Add(new RuleContainsCaseInsensitive(substring));
        return this;
    }

    public VChain AddNotContains(string substring)
    {
        _ruleBases.Add(new RuleNotContains(substring));
        return this;
    }

    public VChain AddNotContainsCaseInsensitive(string substring)
    {
        _ruleBases.Add(new RuleNotContainsCaseInsensitive(substring));
        return this;
    }

    public VChain AddFirstCharIn(string chars)
    {
        _ruleBases.Add(new RuleFirstCharIn(chars));
        return this;
    }

    public VChain AddFirstCharNotIn(string chars)
    {
        _ruleBases.Add(new RuleFirstCharNotIn(chars));
        return this;
    }

    public VChain AddMinLength(int length)
    {
        _ruleBases.Add(new RuleMinLength(length));
        return this;
    }

    public VChain AddMaxLength(int length)
    {
        _ruleBases.Add(new RuleMaxLength(length));
        return this;
    }

    public VChain AddBetweenLength(int minLength, int maxLength)
    {
        _ruleBases.Add(new RuleBetweenLength(minLength, maxLength));
        return this;
    }

    public VChain AddBetweenLength(int minLength, int maxLength, string errorMessage)
    {
        _ruleBases.Add(new RuleBetweenLength(minLength, maxLength, errorMessage));
        return this;
    }

    public VChain AddExactLength(int length)
    {
        _ruleBases.Add(new RuleExactLength(length));
        return this;
    }

    public VChain AddBankCardNumber(BankCardBank cardBank)
    {
        _ruleBases.Add(new RuleBankCardNumber(cardBank));
        return this;
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
