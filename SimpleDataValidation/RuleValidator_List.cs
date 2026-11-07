using SimpleDataValidation.ErrorMsg;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleDataValidation;

public partial class RuleValidator
{
    /// <summary>
    /// The value should be not null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Null(ErrorMessageMgr errorMessageMgr, string dataName, object value)
    {
        return Null(dataName, value, errorMessageMgr.GetMessage(ErrorCode.Null, dataName));
    }

    /// <summary>
    /// The value should be not null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Null(string dataName, object value, string errorMessage)
    {
        if (value == null) return string.Empty;
        return errorMessage;
    }

    /// <summary>
    /// The value should be not null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNull(ErrorMessageMgr errorMessageMgr, string dataName, object value)
    {
        return NotNull(dataName, value, errorMessageMgr.GetMessage(ErrorCode.NotNull, dataName));
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
    public static string NotNullOrEmpty(ErrorMessageMgr errorMessageMgr, string dataName, string value)
    {
        return NotNullOrEmpty(dataName, value, errorMessageMgr.GetMessage(ErrorCode.NotNullOrEmpty, dataName));
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
    public static string NotNullOrWhiteSpace(ErrorMessageMgr errorMessageMgr, string dataName, string value)
    {
        return NotNullOrWhiteSpace(dataName, value, errorMessageMgr.GetMessage(ErrorCode.NotNullOrWhiteSpace, dataName));
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
        // ok
        return string.Empty;
    }

    public static string Letters(ErrorMessageMgr errorMessageMgr, string dataName, string value)
    {
        return Letters(dataName, value, errorMessageMgr.GetMessage(ErrorCode.Letters, dataName));
    }

    public static string Letters(string dataName, string value, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        foreach (char c in value)
        {
            if (!char.IsLetter(c)) return errorMessage;
        }
        // ok
        return string.Empty;

    }

    public static string Digits(ErrorMessageMgr errorMessageMgr, string dataName, string value)
    {
        return Digits(dataName, value, errorMessageMgr.GetMessage(ErrorCode.Digits, dataName));
    }

    public static string Digits(string dataName, string value, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        foreach (char c in value)
        {
            if (!char.IsDigit(c)) return errorMessage;
        }
        // ok
        return string.Empty;
    }

    public static string LettersDigitsUnderscore(ErrorMessageMgr errorMessageMgr, string dataName, string value)
    {
        return LettersDigitsUnderscore(dataName, value, errorMessageMgr.GetMessage(ErrorCode.LettersDigitsUnderscore, dataName));
    }

    public static string LettersDigitsUnderscore(string dataName, string value, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        foreach (char c in value)
        {
            if (!char.IsLetterOrDigit(c) && !(c == '_')) return errorMessage;
        }
        // ok
        return string.Empty;
    }

    public static string StartsWith(ErrorMessageMgr errorMessageMgr, string dataName, string value, string start)
    {
        return StartsWith(dataName, value, start, errorMessageMgr.GetMessage(ErrorCode.StartsWith, dataName, start));
    }

    public static string StartsWith(string dataName, string value, string start, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        if (string.IsNullOrWhiteSpace(start)) return errorMessage;

        if (value.StartsWith(start)) return string.Empty;

        return errorMessage;
    }


    public static string EndsWith(ErrorMessageMgr errorMessageMgr, string dataName, string value, string start)
    {
        return EndsWith(dataName, value, start, errorMessageMgr.GetMessage(ErrorCode.EndsWith, dataName, start));
    }

    public static string EndsWith(string dataName, string value, string start, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        if (string.IsNullOrWhiteSpace(start)) return errorMessage;

        if (value.EndsWith(start)) return string.Empty;

        return errorMessage;
    }


    public static string StartsWithCaseInsensitive(ErrorMessageMgr errorMessageMgr, string dataName, string value, string start)
    {
        return StartsWithCaseInsensitive(dataName, value, start, errorMessageMgr.GetMessage(ErrorCode.StartsWith, dataName, start));
    }

    public static string StartsWithCaseInsensitive(string dataName, string value, string start, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        if (string.IsNullOrWhiteSpace(start)) return errorMessage;

        if (value.StartsWith(start, StringComparison.InvariantCultureIgnoreCase)) return string.Empty;

        return errorMessage;
    }

    public static string EndsWithCaseInsensitive(ErrorMessageMgr errorMessageMgr, string dataName, string value, string start)
    {
        return EndsWithCaseInsensitive(dataName, value, start, errorMessageMgr.GetMessage(ErrorCode.EndsWith, dataName, start));
    }

    public static string EndsWithCaseInsensitive(string dataName, string value, string start, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        if (string.IsNullOrWhiteSpace(start)) return errorMessage;

        if (value.EndsWith(start, StringComparison.InvariantCultureIgnoreCase)) return string.Empty;

        return errorMessage;
    }

    public static string Contains(ErrorMessageMgr errorMessageMgr, string dataName, string value, string start)
    {
        return Contains(dataName, value, start, errorMessageMgr.GetMessage(ErrorCode.Contains, dataName, start));
    }

    public static string Contains(string dataName, string value, string start, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        if (string.IsNullOrWhiteSpace(start)) return errorMessage;

        if (value.Contains(start)) return string.Empty;

        return errorMessage;
    }

    public static string ContainsCaseInsensitive(ErrorMessageMgr errorMessageMgr, string dataName, string value, string start)
    {
        return ContainsCaseInsensitive(dataName, value, start, errorMessageMgr.GetMessage(ErrorCode.Contains, dataName, start));
    }

    public static string ContainsCaseInsensitive(string dataName, string value, string start, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        if (string.IsNullOrWhiteSpace(start)) return errorMessage;

        if (value.Contains(start, StringComparison.InvariantCultureIgnoreCase)) return string.Empty;

        return errorMessage;
    }

    public static string NotContains(ErrorMessageMgr errorMessageMgr, string dataName, string value, string start)
    {
        return NotContains(dataName, value, start, errorMessageMgr.GetMessage(ErrorCode.NotContains, dataName, start));
    }

    public static string NotContains(string dataName, string value, string start, string errorMessage)
    {
        // value is null, so it's ok
        if (string.IsNullOrWhiteSpace(value)) return string.Empty;

        if (string.IsNullOrWhiteSpace(start)) return errorMessage;

        if (!value.Contains(start)) return string.Empty;

        return errorMessage;
    }

    public static string NotContainsCaseInsensitive(ErrorMessageMgr errorMessageMgr, string dataName, string value, string start)
    {
        return NotContainsCaseInsensitive(dataName, value, start, errorMessageMgr.GetMessage(ErrorCode.NotContains, dataName, start));
    }

    public static string NotContainsCaseInsensitive(string dataName, string value, string start, string errorMessage)
    {
        // value is null, so it's ok
        if (string.IsNullOrWhiteSpace(value)) return string.Empty;
        if (string.IsNullOrWhiteSpace(start)) return errorMessage;

        if (!value.Contains(start, StringComparison.InvariantCultureIgnoreCase)) return string.Empty;

        return errorMessage;
    }

    //FirstCharIn
    public static string FirstCharIn(ErrorMessageMgr errorMessageMgr, string dataName, string value, string chars)
    {
        return FirstCharIn(dataName, value, chars, errorMessageMgr.GetMessage(ErrorCode.FirstCharIn, dataName, chars));
    }

    public static string FirstCharIn(string dataName, string value, string chars, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        if (string.IsNullOrWhiteSpace(chars)) return errorMessage;

        if (chars.Contains(value[0])) return string.Empty;

        return errorMessage;
    }

    //FirstCharNotsIn
    public static string FirstCharNotIn(ErrorMessageMgr errorMessageMgr, string dataName, string value, string chars)
    {
        return FirstCharNotIn(dataName, value, chars, errorMessageMgr.GetMessage(ErrorCode.FirstCharNotIn, dataName, chars));
    }

    public static string FirstCharNotIn(string dataName, string value, string chars, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;
        if (string.IsNullOrWhiteSpace(chars)) return errorMessage;

        if (!chars.Contains(value[0])) return string.Empty;

        return errorMessage;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string BetweenLength(ErrorMessageMgr errorMessageMgr, string dataName, string value, int minLength, int maxLength)
    {
        return BetweenLength(dataName, value, minLength, maxLength, errorMessageMgr.GetMessage(ErrorCode.BetweenLength, dataName, minLength.ToString(), maxLength.ToString()));
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
    public static string MinLength(ErrorMessageMgr errorMessageMgr, string dataName, string value, int minLength)
    {
        return MinLength(dataName, value, minLength, errorMessageMgr.GetMessage(ErrorCode.MinLength, dataName, minLength.ToString()));
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
    public static string MaxLength(ErrorMessageMgr errorMessageMgr, string dataName, string value, int maxLength)
    {
        return MaxLength(dataName, value, maxLength, errorMessageMgr.GetMessage(ErrorCode.MaxLength, dataName, maxLength.ToString()));
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
    public static string ExactLength(ErrorMessageMgr errorMessageMgr, string dataName, string value, int exactLength)
    {
        return ExactLength(dataName, value, exactLength, errorMessageMgr.GetMessage(ErrorCode.ExactLength, dataName, exactLength.ToString()));
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
    public static string EmailFormat(ErrorMessageMgr errorMessageMgr, string dataName, string value)
    {
        return EmailFormat(dataName, value, errorMessageMgr.GetMessage(ErrorCode.Email, dataName));
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
    public static string Email(ErrorMessageMgr errorMessageMgr, string dataName, string value)
    {
        return Email(dataName, value, errorMessageMgr.GetMessage(ErrorCode.Email, dataName));
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
    public static string EmailStrict(ErrorMessageMgr errorMessageMgr, string dataName, string value)
    {
        return EmailStrict(dataName, value, errorMessageMgr.GetMessage(ErrorCode.Email, dataName));
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
    /// Validates that the provided value is a boolean.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string Bool(string dataName, object value, string errorMessage)
    {
        if (value == null) return errorMessage;

        if (value.GetType() != typeof(bool)) return errorMessage;

        return string.Empty;
    }

    /// <summary>
    /// Validates that the provided value is a boolean.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Bool(ErrorMessageMgr errorMessageMgr, string dataName, object value)
    {
        return Bool(dataName, value, errorMessageMgr.GetMessage(ErrorCode.Bool, dataName));
    }

    /// <summary>
    /// Validates that the provided value is an integer.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Int(ErrorMessageMgr errorMessageMgr, string dataName, object value)
    {
        return Int(dataName, value, errorMessageMgr.GetMessage(ErrorCode.Int, dataName));
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

    /// <summary>
    /// Validates that the provided value is a number: integer or double or float or BigInteger.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Number(ErrorMessageMgr errorMessageMgr, string dataName, object value)
    {
        return Number(dataName, value, errorMessageMgr.GetMessage(ErrorCode.Number, dataName));
    }

    /// <summary>
    /// Validates that the provided value is an integer or float or BigInteger..
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string Number(string dataName, object value, string errorMessage)
    {
        if (value == null) return errorMessage;

        if (value.GetType() != typeof(int) && value.GetType() != typeof(double) && value.GetType() != typeof(float) && value.GetType() != typeof(BigInteger)) return errorMessage;

        return string.Empty;
    }

    /// <summary>
    /// Validates that the provided value is a string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string String(ErrorMessageMgr errorMessageMgr, string dataName, object value)
    {
        return String(dataName, value, errorMessageMgr.GetMessage(ErrorCode.String, dataName));
    }

    /// <summary>
    /// Validates that the provided value is a string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string String(string dataName, object value, string errorMessage)
    {
        if (value == null) return errorMessage;

        if (value.GetType() != typeof(string)) return errorMessage;

        return string.Empty;
    }

    /// <summary>
    /// Check the format of the date, on one format.
    /// exp: dd/MM/YYYY
    /// "yyyy-MM-dd HH:mm:ss,fff"
    /// 
    ///  msg = V.FormatDate("name", "2026-10-25", "dd/MM/yyyy", "yyyy-MM-dd");
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="dateFormat"></param>
    /// <returns></returns>
    public static string FormatDate(ErrorMessageMgr errorMessageMgr, string dataName, string value, string format)
    {
        return FormatDate(dataName, value, format, errorMessageMgr.GetMessage(ErrorCode.FormatDate, dataName));
    }

    public static string FormatDate(string dataName, string value, string format, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(value)) return errorMessage;

        try
        {
            var date = DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
            return string.Empty;
        }
        catch
        {
            // handle incorrect string error
            return errorMessage;
        }
    }

    public static string FormatDate(ErrorMessageMgr errorMessageMgr, string dataName, string value, string[] formats)
    {
        return FormatDate(dataName, value, formats, errorMessageMgr.GetMessage(ErrorCode.FormatDate, dataName));
    }

    public static string FormatDate(string dataName, string value, string[] formats, string errorMessage)
    {
        bool res = false;
        foreach (var dateFormat in formats)
        {
            // one is good, ok
            string errMsg = FormatDate(dataName, value, dateFormat, errorMessage);
            if (errMsg == string.Empty) return string.Empty;
        }
        return errorMessage;
    }


    public static string BankIban(ErrorMessageMgr errorMessageMgr, string dataName, string value)
    {
        return BankIban(dataName, value, errorMessageMgr.GetMessage(ErrorCode.BankIban, dataName));
    }

    public static string BankIban(string dataName, string value, string errorMessage)
    {
        return BankIbanValidator.CheckIban(value) ? string.Empty : errorMessage;
    }

    public static string BankCardNumber(ErrorMessageMgr errorMessageMgr, string dataName, string value, BankCardBank cardBank)
    {
        return BankCardNumber(dataName, value, cardBank, errorMessageMgr.GetMessage(ErrorCode.BankCardNumber, dataName));
    }

    public static string BankCardNumber(string dataName, string value, BankCardBank cardBank, string errorMessage)
    {
        int res = BankCardValidator.CheckCardNumber(cardBank, value);
        if (res == 0) return string.Empty;
        return errorMessage;

    }

}
