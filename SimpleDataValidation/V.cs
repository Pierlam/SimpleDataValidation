using SimpleDataValidation.ErrorMsg;
using SimpleDataValidation.Rule;
using System.Text.RegularExpressions;

namespace SimpleDataValidation;

/// <summary>
/// The V class is a simple data validation utility that provides methods to validate data based on defined rules. 
/// It supports multiple languages for error messages and allows chaining of validation rules for a given data field.
/// </summary>
public class V : VBase
{

    #region -- Immediate validation --

    /// <summary>
    /// The value should be not null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNull(string dataName, object value)
    {
        return RuleValidator.NotNull(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should be not null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNull(string dataName, object value, string errorMessage)
    {
        return RuleValidator.NotNull(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrEmpty(string dataName, string value)
    {
        return RuleValidator.NotNullOrEmpty(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrEmpty(string dataName, string value, string errorMessage)
    {
        return RuleValidator.NotNullOrEmpty(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrWhiteSpace(string dataName, string value)
    {
        return RuleValidator.NotNullOrWhiteSpace(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrWhiteSpace(string dataName, string value, string errorMessage)
    {
        return RuleValidator.NotNullOrWhiteSpace(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string BetweenLength(string dataName, string value, int minLength, int maxLength)
    {
        return RuleValidator.BetweenLength(_errorMessageMgr, dataName, value, minLength, maxLength);
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string BetweenLength(string dataName, string value, int minLength, int maxLength, string errorMessage)
    {
        return RuleValidator.BetweenLength(dataName, value, minLength, maxLength, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MinLength(string dataName, string value, int minLength)
    {
        return RuleValidator.MinLength(_errorMessageMgr, dataName, value, minLength);
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MinLength(string dataName, string value, int minLength, string errorMessage)
    {
        return RuleValidator.MinLength(dataName, value, minLength, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MaxLength(string dataName, string value, int maxLength)
    {
        return RuleValidator.MaxLength(_errorMessageMgr, dataName, value, maxLength);
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MaxLength(string dataName, string value, int maxLength, string errorMessage)
    {
        return RuleValidator.MaxLength(dataName, value, maxLength, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ExactLength(string dataName, string value, int exactLength)
    {
        return RuleValidator.ExactLength(_errorMessageMgr, dataName, value, exactLength);
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ExactLength(string dataName, string value, int exactLength, string errorMessage)
    {
        return RuleValidator.ExactLength(dataName, value, exactLength, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailFormat(string dataName, string value)
    {
        return RuleValidator.EmailFormat(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// Very simple (useful for quick checks)
    /// This pattern checks for something @something.something with no spaces.
    /// see: https://www.c-sharpcorner.com/article/validate-email-addresses-with-regular-expressions-in-c-sharp
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailFormat(string dataName, string value, string errorMessage)
    {
        return RuleValidator.EmailFormat(dataName, value, errorMessage);
    }

    /// <summary>
    /// Very simple (useful for quick checks)
    /// This pattern checks for something @something.something with no spaces.
    /// see: https://www.c-sharpcorner.com/article/validate-email-addresses-with-regular-expressions-in-c-sharp
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Email(string dataName, string value, string errorMessage)
    {
        return RuleValidator.Email(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Email(string dataName, string value)
    {
        return RuleValidator.Email(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailStrict(string dataName, string value)
    {
        return RuleValidator.EmailStrict(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// Very simple (useful for quick checks)
    /// This pattern checks for something @something.something with no spaces.
    /// see: https://www.c-sharpcorner.com/article/validate-email-addresses-with-regular-expressions-in-c-sharp
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailStrict(string dataName, string value, string errorMessage)
    {
        return RuleValidator.EmailStrict(dataName, value, errorMessage);
    }

    /// <summary>
    /// Validates that the provided value is an integer.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Int(string dataName, object value)
    {
        return RuleValidator.Int(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// Validates that the provided value is an integer.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string Int(string dataName, object value,string errorMessage)
    {
        return RuleValidator.Int(dataName, value, errorMessage);
    }

    public static string Iban(string dataName, string value)
    {
        return RuleValidator.Iban(_errorMessageMgr, dataName, value);
    }

    public static string Iban(string dataName, string value, string errorMessage)
    {
        return RuleValidator.Iban(dataName, value, errorMessage);
    }

    #endregion

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

    #region -- Add validation --

    public V AddNotNull()
    {
        _ruleBases.Add(new RuleNotNull());
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

    #endregion
}
