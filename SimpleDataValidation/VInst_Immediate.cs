using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;

public partial class VInst
{
    /// <summary>
    /// The value should be true. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string True(string dataName, bool value)
    {
        return RuleValidator.True(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should be true. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string True(string dataName, bool value, string errorMessage)
    {
        return RuleValidator.True(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should be false. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string False(string dataName, bool value)
    {
        return RuleValidator.False(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should be false. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string False(string dataName, bool value, string errorMessage)
    {
        return RuleValidator.False(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should be null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Null(string dataName, object value)
    {
        return RuleValidator.Null(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should be null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Null(string dataName, object value, string errorMessage)
    {
        return RuleValidator.Null(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should be NOT null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string NotNull(string dataName, object value)
    {
        return RuleValidator.NotNull(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should be Not null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string NotNull(string dataName, object value, string errorMessage)
    {
        return RuleValidator.NotNull(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string NotNullOrEmpty(string dataName, string value)
    {
        return RuleValidator.NotNullOrEmpty(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string NotNullOrEmpty(string dataName, string value, string errorMessage)
    {
        return RuleValidator.NotNullOrEmpty(dataName, value, errorMessage);
    }

    /// <summary>
    /// Same as NotNullOrWhiteSpace.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Text(string dataName, string value)
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
    public string Text(string dataName, string value, string errorMessage)
    {
        return NotNullOrWhiteSpace(dataName, value, errorMessage);
    }


    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string NotNullOrWhiteSpace(string dataName, string value)
    {
        return RuleValidator.NotNullOrWhiteSpace(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string NotNullOrWhiteSpace(string dataName, string value, string errorMessage)
    {
        return RuleValidator.NotNullOrWhiteSpace(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should contains only letters.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Letters(string dataName, string value)
    {
        return RuleValidator.Letters(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should contains only letters.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Letters(string dataName, string value, string errorMessage)
    {
        return RuleValidator.Letters(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should contains only digits (number).
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Digits(string dataName, string value)
    {
        return RuleValidator.Digits(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should contains only digits (number).
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Digits(string dataName, string value, string errorMessage)
    {
        return RuleValidator.Digits(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should contains only letters, digits or underscore.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string LettersDigitsUnderscore(string dataName, string value)
    {
        return RuleValidator.LettersDigitsUnderscore(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should contains only letters, digits or underscore.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string LettersDigitsUnderscore(string dataName, string value, string errorMessage)
    {
        return RuleValidator.LettersDigitsUnderscore(dataName, value, errorMessage);
    }

    public string StartsWith(string dataName, string value, string start)
    {
        return RuleValidator.StartsWith(_errorMessageMgr, dataName, value, start);
    }

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string StartsWith(string dataName, string value, string start, string errorMessage)
    {
        return RuleValidator.StartsWith(dataName, value, start, errorMessage);
    }

    public string EndsWith(string dataName, string value, string start, string errorMessage)
    {
        return RuleValidator.EndsWith(dataName, value, start, errorMessage);
    }

    public string EndsWith(string dataName, string value, string start)
    {
        return RuleValidator.EndsWith(_errorMessageMgr, dataName, value, start);
    }

    public string StartsWithCaseInsensitive(string dataName, string value, string start)
    {
        return RuleValidator.StartsWithCaseInsensitive(_errorMessageMgr, dataName, value, start);
    }

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string StartsWithCaseInsensitive(string dataName, string value, string start, string errorMessage)
    {
        return RuleValidator.StartsWithCaseInsensitive(dataName, value, start, errorMessage);
    }

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string EndsWithCaseInsensitive(string dataName, string value, string start, string errorMessage)
    {
        return RuleValidator.EndsWithCaseInsensitive(dataName, value, start, errorMessage);
    }

    public string EndsWithCaseInsensitive(string dataName, string value, string start)
    {
        return RuleValidator.EndsWithCaseInsensitive(_errorMessageMgr, dataName, value, start);
    }

    public string Contains(string dataName, string value, string start, string errorMessage)
    {
        return RuleValidator.Contains(dataName, value, start, errorMessage);
    }

    public string Contains(string dataName, string value, string start)
    {
        return RuleValidator.Contains(_errorMessageMgr, dataName, value, start);
    }

    public string ContainsCaseInsensitive(string dataName, string value, string start, string errorMessage)
    {
        return RuleValidator.ContainsCaseInsensitive(dataName, value, start, errorMessage);
    }

    public string ContainsCaseInsensitive(string dataName, string value, string start)
    {
        return RuleValidator.ContainsCaseInsensitive(_errorMessageMgr, dataName, value, start);
    }

    public string NotContains(string dataName, string value, string start, string errorMessage)
    {
        return RuleValidator.NotContains(dataName, value, start, errorMessage);
    }

    public string NotContains(string dataName, string value, string start)
    {
        return RuleValidator.NotContains(_errorMessageMgr, dataName, value, start);
    }

    public string NotContainsCaseInsensitive(string dataName, string value, string start, string errorMessage)
    {
        return RuleValidator.NotContainsCaseInsensitive(dataName, value, start, errorMessage);
    }

    public string NotContainsCaseInsensitive(string dataName, string value, string start)
    {
        return RuleValidator.NotContainsCaseInsensitive(_errorMessageMgr, dataName, value, start);
    }


    public string FirstCharIn(string dataName, string value, string chars)
    {
        return RuleValidator.FirstCharIn(_errorMessageMgr, dataName, value, chars);
    }

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string FirstCharIn(string dataName, string value, string chars, string errorMessage)
    {
        return RuleValidator.FirstCharIn(dataName, value, chars, errorMessage);
    }

    public string FirstCharNotIn(string dataName, string value, string chars)
    {
        return RuleValidator.FirstCharNotIn(_errorMessageMgr, dataName, value, chars);
    }

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string FirstCharNotIn(string dataName, string value, string chars, string errorMessage)
    {
        return RuleValidator.FirstCharNotIn(dataName, value, chars, errorMessage);
    }

    /// <summary>
    /// Check that the length of string is between a min (included) and a max (included) value.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string BetweenLength(string dataName, string value, int minLength, int maxLength)
    {
        return RuleValidator.BetweenLength(_errorMessageMgr, dataName, value, minLength, maxLength);
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string BetweenLength(string dataName, string value, int minLength, int maxLength, string errorMessage)
    {
        return RuleValidator.BetweenLength(dataName, value, minLength, maxLength, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string MinLength(string dataName, string value, int minLength)
    {
        return RuleValidator.MinLength(_errorMessageMgr, dataName, value, minLength);
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string MinLength(string dataName, string value, int minLength, string errorMessage)
    {
        return RuleValidator.MinLength(dataName, value, minLength, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string MaxLength(string dataName, string value, int maxLength)
    {
        return RuleValidator.MaxLength(_errorMessageMgr, dataName, value, maxLength);
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string MaxLength(string dataName, string value, int maxLength, string errorMessage)
    {
        return RuleValidator.MaxLength(dataName, value, maxLength, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string ExactLength(string dataName, string value, int exactLength)
    {
        return RuleValidator.ExactLength(_errorMessageMgr, dataName, value, exactLength);
    }

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string ExactLength(string dataName, string value, int exactLength, string errorMessage)
    {
        return RuleValidator.ExactLength(dataName, value, exactLength, errorMessage);
    }


    /// <summary>
    /// Validates that the provided value is a boolean.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Bool(string dataName, object value)
    {
        return RuleValidator.Bool(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// Validates that the provided value is a boolean.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public string Bool(string dataName, object value, string errorMessage)
    {
        return RuleValidator.Bool(dataName, value, errorMessage);
    }

    /// <summary>
    /// Validates that the provided value is an integer.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Int(string dataName, object value)
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
    public string Int(string dataName, object value, string errorMessage)
    {
        return RuleValidator.Int(dataName, value, errorMessage);
    }

    /// <summary>
    /// Validates that the provided value is a number: int or double or real.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Number(string dataName, object value)
    {
        return RuleValidator.Number(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// Validates that the provided value is a number: int or double.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public string Number(string dataName, object value, string errorMessage)
    {
        return RuleValidator.Number(dataName, value, errorMessage);
    }

    /// <summary>
    /// Validates that the provided value is a string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string String(string dataName, object value)
    {
        return RuleValidator.String(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// Validates that the provided value is a string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public string String(string dataName, object value, string errorMessage)
    {
        return RuleValidator.String(dataName, value, errorMessage);
    }

    public string FormatDate(string dataName, string value, string format)
    {
        return RuleValidator.FormatDate(_errorMessageMgr, dataName, value, format);
    }

    public string FormatDate(string dataName, string value, string format, string errorMessage)
    {
        return RuleValidator.FormatDate(dataName, value, format, errorMessage);
    }

    public string FormatDate(string dataName, string value, string[] formats)
    {
        return RuleValidator.FormatDate(_errorMessageMgr, dataName, value, formats);
    }

    public string FormatDate(string dataName, string value, string[] formats, string errorMessage)
    {
        return RuleValidator.FormatDate(dataName, value, formats, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string EmailFormat(string dataName, string value)
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
    public string EmailFormat(string dataName, string value, string errorMessage)
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
    public string Email(string dataName, string value, string errorMessage)
    {
        return RuleValidator.Email(dataName, value, errorMessage);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string Email(string dataName, string value)
    {
        return RuleValidator.Email(_errorMessageMgr, dataName, value);
    }

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string EmailStrict(string dataName, string value)
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
    public string EmailStrict(string dataName, string value, string errorMessage)
    {
        return RuleValidator.EmailStrict(dataName, value, errorMessage);
    }

    public string BankIban(string dataName, string value)
    {
        return RuleValidator.BankIban(_errorMessageMgr, dataName, value);
    }

    public string BankIban(string dataName, string value, string errorMessage)
    {
        return RuleValidator.BankIban(dataName, value, errorMessage);
    }

    public string BankCardNumber(string dataName, string value, BankCardBank cardbank)
    {
        return RuleValidator.BankCardNumber(_errorMessageMgr, dataName, value, cardbank);
    }

    public string BankCardNumber(string dataName, string value, BankCardBank cardbank, string errorMessage)
    {
        return RuleValidator.BankCardNumber(dataName, value, cardbank, errorMessage);
    }

    public string BankCardNumber(string dataName, string value)
    {
        // all banks
        BankCardBank cardbank = BankCardBank.Visa | BankCardBank.Mastercard | BankCardBank.AmericanExpress | BankCardBank.Discover | BankCardBank.DinersClub | BankCardBank.JCB | BankCardBank.ChinaUnionPay;

        return RuleValidator.BankCardNumber(_errorMessageMgr, dataName, value, cardbank);
    }

    public string BankCardNumber(string dataName, string value, string errorMessage)
    {
        // all banks
        BankCardBank cardbank = BankCardBank.Visa | BankCardBank.Mastercard | BankCardBank.AmericanExpress | BankCardBank.Discover | BankCardBank.DinersClub | BankCardBank.JCB | BankCardBank.ChinaUnionPay;
        return RuleValidator.BankCardNumber(dataName, value, cardbank, errorMessage);
    }
}
