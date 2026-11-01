using SimpleDataValidation.ErrorMsg;
using SimpleDataValidation.Rule;
using System.Text.RegularExpressions;

namespace SimpleDataValidation;

/// <summary>
/// The V class is a simple data validation utility that provides methods to validate data based on defined rules. 
/// It supports multiple languages for error messages and allows chaining of validation rules for a given data field.
/// </summary>
public class V : VImmediateBase
{
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

    #region -- Add rule validation --

    public V AddNull()
    {
        _ruleBases.Add(new RuleNull());
        return this;
    }

    public V AddNotNull()
    {
        _ruleBases.Add(new RuleNotNull());
        return this;
    }

    public V AddNotNullOrEmpty()
    {
        _ruleBases.Add(new RuleNotNullOrEmpty());
        return this;
    }
    public V AddNotNullOrWhiteSpace()
    {
        _ruleBases.Add(new RuleNotNullOrWhiteSpace());
        return this;
    }

    public V AddText()
    {
        _ruleBases.Add(new RuleNotNullOrWhiteSpace());
        return this;
    }

    public V AddStartsWith(string start)
    {
        _ruleBases.Add(new RuleStartsWith(start));
        return this;
    }

    public V AddFirstCharIn(string chars)
    {
        _ruleBases.Add(new RuleFirstCharIn(chars));
        return this;
    }

    public V AddFirstCharNotIn(string chars)
    {
        _ruleBases.Add(new RuleFirstCharNotIn(chars));
        return this;
    }

    public V AddMinLength(int length)
    {
        _ruleBases.Add(new RuleMinLength(length));
        return this;
    }

    public V AddMaxLength(int length)
    {
        _ruleBases.Add(new RuleMaxLength(length));
        return this;
    }

    public V AddBetweenLength(int minLength, int maxLength)
    {
        _ruleBases.Add(new RuleBetweenLength(minLength, maxLength));
        return this;
    }

    public V AddBetweenLength(int minLength, int maxLength, string errorMessage)
    {
        _ruleBases.Add(new RuleBetweenLength(minLength, maxLength, errorMessage));
        return this;
    }

    public V AddExactLength(int length)
    {
        _ruleBases.Add(new RuleExactLength(length));
        return this;
    }

    public V AddBankCardNumber(BankCardBank cardBank)
    {
        _ruleBases.Add(new RuleBankCardNumber(cardBank));
        return this;
    }

    #endregion
}
