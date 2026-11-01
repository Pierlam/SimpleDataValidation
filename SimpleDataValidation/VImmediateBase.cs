using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;

/// <summary>
/// Immediate validation.
/// </summary>
public class VImmediateBase: VBase
{

    /// <summary>
    /// The value should be null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Null(string dataName, object value)
    {
        string errMsg = RuleValidator.Null(_errorMessageMgr, dataName, value);
        return errMsg;
    }

    /// <summary>
    /// The value should be null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Null(string dataName, object value, string errorMessage)
    {
        string errMsg = RuleValidator.Null(dataName, value, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// The value should be NOT null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNull(string dataName, object value)
    {
        string errMsg = RuleValidator.NotNull(_errorMessageMgr, dataName, value);
        return errMsg;
    }

    /// <summary>
    /// The value should be Not null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNull(string dataName, object value, string errorMessage)
    {
        string errMsg = RuleValidator.NotNull(dataName, value, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrEmpty(string dataName, string value)
    {
        string errMsg = RuleValidator.NotNullOrEmpty(_errorMessageMgr, dataName, value);
        return errMsg;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrEmpty(string dataName, string value, string errorMessage)
    {
        string errMsg = RuleValidator.NotNullOrEmpty(dataName, value, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// Same as NotNullOrWhiteSpace.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Text(string dataName, string value)
    {
        return NotNullOrWhiteSpace(dataName, value);
    }

    /// <summary>
    /// Same as NotNullOrWhiteSpace.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string Text(string dataName, string value, string errorMessage)
    {
        return NotNullOrWhiteSpace(dataName, value, errorMessage);
    }


    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrWhiteSpace(string dataName, string value)
    {
        string errMsg = RuleValidator.NotNullOrWhiteSpace(_errorMessageMgr, dataName, value);
        return errMsg;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string NotNullOrWhiteSpace(string dataName, string value, string errorMessage)
    {
        string errMsg = RuleValidator.NotNullOrWhiteSpace(dataName, value, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// The value should contains only letters.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Letters(string dataName, string value)
    {
        string errMsg = RuleValidator.Letters(_errorMessageMgr, dataName, value);
        return errMsg;

    }

    /// <summary>
    /// The value should contains only letters.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Letters(string dataName, string value, string errorMessage)
    {
        string errMsg = RuleValidator.Letters(dataName, value, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// The value should contains only digits (number).
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Digits(string dataName, string value)
    {
        string errMsg = RuleValidator.Digits(_errorMessageMgr, dataName, value);
        return errMsg;

    }

    /// <summary>
    /// The value should contains only letters.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Digits(string dataName, string value, string errorMessage)
    {
        string errMsg = RuleValidator.Digits(dataName, value, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// The value should contains only letters, digits or underscore.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string LettersDigitsUnderscore(string dataName, string value)
    {
        string errMsg = RuleValidator.LettersDigitsUnderscore(_errorMessageMgr, dataName, value);
        return errMsg;

    }

    /// <summary>
    /// The value should contains only letters, digits or underscore.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string LettersDigitsUnderscore(string dataName, string value, string errorMessage)
    {
        string errMsg = RuleValidator.LettersDigitsUnderscore(dataName, value, errorMessage);
        return errMsg;
    }

    public static string StartsWith(string dataName, string value, string start)
    {
        string errMsg = RuleValidator.StartsWith(_errorMessageMgr, dataName, value, start);
        return errMsg;
    }

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string StartsWith(string dataName, string value, string start, string errorMessage)
    {
        string errMsg = RuleValidator.StartsWith(dataName, value, start, errorMessage);
        return errMsg;
    }

    public static string FirstCharIn(string dataName, string value, string chars)
    {
        string errMsg = RuleValidator.FirstCharIn(_errorMessageMgr, dataName, value, chars);
        return errMsg;

    }

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string FirstCharIn(string dataName, string value, string chars, string errorMessage)
    {
        string errMsg = RuleValidator.FirstCharIn(dataName, value, chars, errorMessage);
        return errMsg;
    }

    public static string FirstCharNotIn(string dataName, string value, string chars)
    {
        string errMsg = RuleValidator.FirstCharNotIn(_errorMessageMgr, dataName, value, chars);
        return errMsg;

    }

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string FirstCharNotIn(string dataName, string value, string chars, string errorMessage)
    {
        string errMsg = RuleValidator.FirstCharNotIn(dataName, value, chars, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// Check that the length of string is between a min (included) and a max (included) value.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string BetweenLength(string dataName, string value, int minLength, int maxLength)
    {
        string errMsg = RuleValidator.BetweenLength(_errorMessageMgr, dataName, value, minLength, maxLength);
        return errMsg;
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string BetweenLength(string dataName, string value, int minLength, int maxLength, string errorMessage)
    {
        string errMsg = RuleValidator.BetweenLength(dataName, value, minLength, maxLength, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MinLength(string dataName, string value, int minLength)
    {
        string errMsg = RuleValidator.MinLength(_errorMessageMgr, dataName, value, minLength);
        return errMsg;
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MinLength(string dataName, string value, int minLength, string errorMessage)
    {
        string errMsg = RuleValidator.MinLength(dataName, value, minLength, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MaxLength(string dataName, string value, int maxLength)
    {
        string errMsg = RuleValidator.MaxLength(_errorMessageMgr, dataName, value, maxLength);
        return errMsg;
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MaxLength(string dataName, string value, int maxLength, string errorMessage)
    {
        string errMsg = RuleValidator.MaxLength(dataName, value, maxLength, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ExactLength(string dataName, string value, int exactLength)
    {
        string errMsg = RuleValidator.ExactLength(_errorMessageMgr, dataName, value, exactLength);
        return errMsg;
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ExactLength(string dataName, string value, int exactLength, string errorMessage)
    {
        string errMsg = RuleValidator.ExactLength(dataName, value, exactLength, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailFormat(string dataName, string value)
    {
        string errMsg = RuleValidator.EmailFormat(_errorMessageMgr, dataName, value);
        return errMsg;
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
        string errMsg = RuleValidator.EmailFormat(dataName, value, errorMessage);
        return errMsg;
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
        string errMsg = RuleValidator.Email(dataName, value, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Email(string dataName, string value)
    {
        string errMsg = RuleValidator.Email(_errorMessageMgr, dataName, value);
        return errMsg;
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailStrict(string dataName, string value)
    {
        string errMsg = RuleValidator.EmailStrict(_errorMessageMgr, dataName, value);
        return errMsg;
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
        string errMsg = RuleValidator.EmailStrict(dataName, value, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// Validates that the provided value is a boolean.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Bool(string dataName, object value)
    {
        string errMsg = RuleValidator.Bool(_errorMessageMgr, dataName, value);
        return errMsg;
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
        string errMsg = RuleValidator.Bool(dataName, value, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// Validates that the provided value is an integer.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Int(string dataName, object value)
    {
        string errMsg = RuleValidator.Int(_errorMessageMgr, dataName, value);
        return errMsg;
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
        string errMsg = RuleValidator.Int(dataName, value, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// Validates that the provided value is a number: int or double or real.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Number(string dataName, object value)
    {
        string errMsg = RuleValidator.Number(_errorMessageMgr, dataName, value);
        return errMsg;
    }

    /// <summary>
    /// Validates that the provided value is a number: int or double.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string Number(string dataName, object value, string errorMessage)
    {
        string errMsg = RuleValidator.Number(dataName, value, errorMessage);
        return errMsg;
    }

    /// <summary>
    /// Validates that the provided value is a string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string String(string dataName, object value)
    {
        string errMsg = RuleValidator.String(_errorMessageMgr, dataName, value);
        return errMsg;
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
        string errMsg = RuleValidator.String(dataName, value, errorMessage);
        return errMsg;
    }

    public static string BankIban(string dataName, string value)
    {
        string errMsg = RuleValidator.Iban(_errorMessageMgr, dataName, value);
        return errMsg;
    }

    public static string BankIban(string dataName, string value, string errorMessage)
    {
        string errMsg = RuleValidator.BankIban(dataName, value, errorMessage);
        return errMsg;
    }

    public static string BankCardNumber(string dataName, string value, BankCardBank cardbank)
    {
        string errMsg = RuleValidator.BankCardNumber(_errorMessageMgr, dataName, value, cardbank);
        return errMsg;
    }

    public static string BankCardNumber(string dataName, string value, BankCardBank cardbank, string errorMessage)
    {
        string errMsg = RuleValidator.BankCardNumber(dataName, value, cardbank, errorMessage);
        return errMsg;
    }

    public static string BankCardNumber(string dataName, string value)
    {
        // all banks
        BankCardBank cardbank = BankCardBank.Visa | BankCardBank.Mastercard | BankCardBank.AmericanExpress | BankCardBank.Discover | BankCardBank.DinersClub | BankCardBank.JCB | BankCardBank.ChinaUnionPay;

        string errMsg = RuleValidator.BankCardNumber(_errorMessageMgr, dataName, value, cardbank);
        return errMsg;
    }

    public static string BankCardNumber(string dataName, string value, string errorMessage)
    {
        // all banks
        BankCardBank cardbank = BankCardBank.Visa | BankCardBank.Mastercard | BankCardBank.AmericanExpress | BankCardBank.Discover | BankCardBank.DinersClub | BankCardBank.JCB | BankCardBank.ChinaUnionPay;
        string errMsg = RuleValidator.BankCardNumber(dataName, value, cardbank, errorMessage);
        return errMsg;
    }

}
