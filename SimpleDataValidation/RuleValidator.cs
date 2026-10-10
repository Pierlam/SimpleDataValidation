using SimpleDataValidation.ErrorMsg;
using SimpleDataValidation.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleDataValidation;

/// <summary>
/// The RuleValidator class provides static methods for validating data against various rules. It uses the ErrorMessageMgr to retrieve error messages based on the current language and error code. The class includes methods for validating null values, string lengths, email formats, and integer types, returning appropriate error messages when validation fails.
/// </summary>
public class RuleValidator
{
    public static string Validate(ErrorMessageMgr errorMsgMgr, RuleBase rule, string dataName, object value)
    {
        if(rule == null) throw new ArgumentNullException(nameof(rule));

        if(rule is RuleNotNull)
            return NotNull(errorMsgMgr, dataName, value?.ToString());

        //if (rule is RuleNotNullOrEmpty ruleNotNullOrEmpty)
        //    return NotNullOrEmpty(errorMsgMgr, dataName, value?.ToString());

        //if(rule is RuleNotNullOrWhiteSpace)
        //    return NotNullOrWhiteSpace(errorMsgMgr, dataName, value?.ToString());

        //if(rule is RuleBetweenLength ruleBetweenLength)
        //    return BetweenLength(errorMsgMgr, dataName, value?.ToString(), ruleBetweenLength.MinLength, ruleBetweenLength.MaxLength);

        if(rule is RuleMinLength ruleMinLength)
            return MinLength(errorMsgMgr, dataName, value?.ToString(), ruleMinLength.MinLength);

        if(rule is RuleMaxLength ruleMaxLength)
            return MaxLength(errorMsgMgr, dataName, value?.ToString(), ruleMaxLength.MaxLength);

        throw new NotImplementedException(nameof(rule));
    }

    /// <summary>
    /// The value should be not null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNull(ErrorMessageMgr errorMsgMgr, string dataName, object value)
    {
        return NotNull(dataName, value, errorMsgMgr.GetMessage(ErrorCode.NotNull, dataName));
    }

    /// <summary>
    /// The value should be not null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNull(string dataName, object value, string errorMessage)
    {
        if (value == null) return errorMessage;
        return string.Empty;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrEmpty(ErrorMessageMgr errorMsgMgr, string dataName, string value)
    {
        return NotNullOrEmpty(dataName, value, errorMsgMgr.GetMessage(ErrorCode.NotNullOrEmpty, dataName));
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrEmpty(string dataName, string value, string errorMessage)
    {
        if (string.IsNullOrEmpty(value)) return errorMessage;
        return string.Empty;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrWhiteSpace(ErrorMessageMgr errorMsgMgr, string dataName, string value)
    {
        return NotNullOrWhiteSpace(dataName, value, errorMsgMgr.GetMessage(ErrorCode.NotNullOrWhiteSpace, dataName));
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrWhiteSpace(string dataName, string value, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        return string.Empty;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string BetweenLength(ErrorMessageMgr errorMsgMgr, string dataName, string value, int minLength, int maxLength)
    {
        return BetweenLength(dataName, value, minLength, maxLength, errorMsgMgr.GetMessage(ErrorCode.BetweenLength, dataName, minLength.ToString(), maxLength.ToString()));
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string BetweenLength(string dataName, string value, int minLength, int maxLength, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        if (value.Length < minLength || value.Length > maxLength) return errorMessage;
        return string.Empty;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MinLength(ErrorMessageMgr errorMsgMgr, string dataName, string value, int minLength)
    {
        return MinLength(dataName, value, minLength, errorMsgMgr.GetMessage(ErrorCode.MinLength, dataName, minLength.ToString()));
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MinLength(string dataName, string value, int minLength, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        if (value.Length < minLength) return errorMessage;
        return string.Empty;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MaxLength(ErrorMessageMgr errorMsgMgr, string dataName, string value, int maxLength)
    {
        return MaxLength(dataName, value, maxLength, errorMsgMgr.GetMessage(ErrorCode.MaxLength, dataName, maxLength.ToString()));
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MaxLength(string dataName, string value, int maxLength, string errorMessage)
    {
        // special case: if value is null or empty, we consider it valid for MaxLength check
        if (string.IsNullOrWhiteSpace(value)) return string.Empty;

        if (value.Length > maxLength) return errorMessage;
        return string.Empty;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ExactLength(ErrorMessageMgr errorMsgMgr, string dataName, string value, int exactLength)
    {
        return ExactLength(dataName, value, exactLength, errorMsgMgr.GetMessage(ErrorCode.ExactLength, dataName, exactLength.ToString()));
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ExactLength(string dataName, string value, int exactLength, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        if (value.Length != exactLength) return errorMessage;
        return string.Empty;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailFormat(ErrorMessageMgr errorMsgMgr, string dataName, string value)
    {
        return EmailFormat(dataName, value, errorMsgMgr.GetMessage(ErrorCode.Email, dataName));
    }

    /// <summary>
    /// Very simple (useful for quick checks)
    /// This pattern checks for something@something.something with no spaces.
    /// see: https://www.c-sharpcorner.com/article/validate-email-addresses-with-regular-expressions-in-c-sharp
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailFormat(string dataName, string value, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;

        //  Very simple (useful for quick checks)
        string pattern = @"^\S+@\S+\.\S+$";
        if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
        {
            return errorMessage;
        }

        return string.Empty;
    }

    /// <summary>
    /// Validates that the provided value is a valid email address.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Email(ErrorMessageMgr errorMsgMgr, string dataName, string value)
    {
        return Email(dataName, value, errorMsgMgr.GetMessage(ErrorCode.Email, dataName));
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
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;

        // Balanced regex pattern
        string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

        if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
        {
            return errorMessage;
        }

        return string.Empty;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailStrict(ErrorMessageMgr errorMsgMgr, string dataName, string value)
    {
        return EmailStrict(dataName, value, errorMsgMgr.GetMessage(ErrorCode.Email, dataName));
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
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;

        // Strict RFC-like regex (very complex), slower
        string pattern = @"^(?:[a-zA-Z0-9_'^&/+-])+(?:\.(?:[a-zA-Z0-9_'^&/+-])+)*@(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$";

        if (!Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
        {
            return errorMessage;
        }

        return string.Empty;
    }

    /// <summary>
    /// Validates that the provided value is an integer.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Int(ErrorMessageMgr errorMsgMgr, string dataName, object value)
    {
        return Int(dataName, value, errorMsgMgr.GetMessage(ErrorCode.Int, dataName));
    }

    /// <summary>
    /// Validates that the provided value is an integer.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string Int(string dataName, object value, string errorMessage)
    {
        if (value == null) return errorMessage;

        if (value.GetType() != typeof(int)) return errorMessage;

        return string.Empty;
    }

    public static string Iban(ErrorMessageMgr errorMsgMgr, string dataName, string value)
    {
        return Iban(dataName, value, errorMsgMgr.GetMessage(ErrorCode.Iban, dataName));
    }

    public static string Iban(string dataName, string value, string errorMessage)
    {
        return IbanValidator.CheckIban(value) ? string.Empty : errorMessage;
    }

}
