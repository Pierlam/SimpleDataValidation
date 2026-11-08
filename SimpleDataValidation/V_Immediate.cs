
namespace SimpleDataValidation;

/// <summary>
/// Immediate validation.
/// </summary>
public partial class V
{
    /// <summary>
    /// The value should be null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    public static string Null(string dataName, object value) => _defaultInst.Null(dataName, value);

    /// <summary>
    /// The value should be null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    public static string Null(string dataName, object value, string errorMessage) => _defaultInst.Null(dataName, value, errorMessage);

    /// <summary>
    /// The value should be NOT null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    public static string NotNull(string dataName, object value) => _defaultInst.NotNull(dataName, value);

    /// <summary>
    /// The value should be Not null. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    public static string NotNull(string dataName, object value, string errorMessage) => _defaultInst.NotNull(dataName, value, errorMessage);

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    public static string NotNullOrEmpty(string dataName, string value) => _defaultInst.NotNullOrEmpty(dataName, value);

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    public static string NotNullOrEmpty(string dataName, string value, string errorMessage) => _defaultInst.NotNullOrEmpty(dataName, value, errorMessage);

    /// <summary>
    /// Same as NotNullOrWhiteSpace.
    /// </summary>
    public static string Text(string dataName, string value) => NotNullOrWhiteSpace(dataName, value);

    /// <summary>
    /// Same as NotNullOrWhiteSpace.
    /// </summary>
    public static string Text(string dataName, string value, string errorMessage) => NotNullOrWhiteSpace(dataName, value, errorMessage);


    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    public static string NotNullOrWhiteSpace(string dataName, string value) => _defaultInst.NotNullOrWhiteSpace(dataName, value);

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    public static string NotNullOrWhiteSpace(string dataName, string value, string errorMessage) => _defaultInst.NotNullOrWhiteSpace(dataName, value, errorMessage);

    /// <summary>
    /// The value should contains only letters.
    /// </summary>
    public static string Letters(string dataName, string value) => _defaultInst.Letters(dataName, value);

    /// <summary>
    /// The value should contains only letters.
    /// </summary>
    public static string Letters(string dataName, string value, string errorMessage) => _defaultInst.Letters(dataName, value, errorMessage);

    /// <summary>
    /// The value should contains only digits (number).
    /// </summary>
    public static string Digits(string dataName, string value) => _defaultInst.Digits(dataName, value);

    /// <summary>
    /// The value should contains only digits (number).
    /// </summary>
    public static string Digits(string dataName, string value, string errorMessage) => _defaultInst.Digits(dataName, value, errorMessage);

    /// <summary>
    /// The value should contains only letters, digits or underscore.
    /// </summary>
    public static string LettersDigitsUnderscore(string dataName, string value) => _defaultInst.LettersDigitsUnderscore(dataName, value);

    /// <summary>
    /// The value should contains only letters, digits or underscore.
    /// </summary>
    public static string LettersDigitsUnderscore(string dataName, string value, string errorMessage) => _defaultInst.LettersDigitsUnderscore(dataName, value, errorMessage);

    public static string StartsWith(string dataName, string value, string start) => _defaultInst.StartsWith(dataName, value, start);

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string StartsWith(string dataName, string value, string start, string errorMessage)=> _defaultInst.StartsWith(dataName, value, start, errorMessage);

    public static string EndsWith(string dataName, string value, string start, string errorMessage) => _defaultInst.EndsWith(dataName, value, start, errorMessage);

    public static string EndsWith(string dataName, string value, string start) => _defaultInst.EndsWith(dataName, value, start);

    public static string StartsWithCaseInsensitive(string dataName, string value, string start) => _defaultInst.StartsWithCaseInsensitive(dataName, value, start);

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string StartsWithCaseInsensitive(string dataName, string value, string start, string errorMessage) => _defaultInst.StartsWithCaseInsensitive(dataName, value, start, errorMessage);

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EndsWithCaseInsensitive(string dataName, string value, string start, string errorMessage) => _defaultInst.EndsWithCaseInsensitive(dataName, value, start, errorMessage);

    public static string EndsWithCaseInsensitive(string dataName, string value, string start) => _defaultInst.EndsWithCaseInsensitive(dataName, value, start);

    public static string Contains(string dataName, string value, string start, string errorMessage)=> _defaultInst.Contains(dataName, value, start, errorMessage);

    public static string Contains(string dataName, string value, string start) => _defaultInst.Contains(dataName, value, start);

    public static string ContainsCaseInsensitive(string dataName, string value, string start, string errorMessage) => _defaultInst.ContainsCaseInsensitive(dataName, value, start, errorMessage);

    public static string ContainsCaseInsensitive(string dataName, string value, string start) => _defaultInst.ContainsCaseInsensitive(dataName, value, start);

    public static string NotContains(string dataName, string value, string start, string errorMessage) => _defaultInst.NotContains(dataName, value, start, errorMessage);

    public static string NotContains(string dataName, string value, string start) => _defaultInst.NotContains(dataName, value, start);

    public static string NotContainsCaseInsensitive(string dataName, string value, string start, string errorMessage)=> _defaultInst.NotContainsCaseInsensitive(dataName, value, start, errorMessage);

    public static string NotContainsCaseInsensitive(string dataName, string value, string start)=> _defaultInst.NotContainsCaseInsensitive(dataName, value, start);

    public static string FirstCharIn(string dataName, string value, string chars)=> _defaultInst.FirstCharIn(dataName, value, chars);

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string FirstCharIn(string dataName, string value, string chars, string errorMessage)=> _defaultInst.FirstCharIn(dataName, value, chars, errorMessage);

    public static string FirstCharNotIn(string dataName, string value, string chars)=> _defaultInst.FirstCharNotIn(dataName, value, chars);

    /// <summary>
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string FirstCharNotIn(string dataName, string value, string chars, string errorMessage) => _defaultInst.FirstCharNotIn(dataName, value, chars, errorMessage);

    /// <summary>
    /// Check that the length of string is between a min (included) and a max (included) value.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string BetweenLength(string dataName, string value, int minLength, int maxLength)=> _defaultInst.BetweenLength(dataName, value, minLength, maxLength);

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string BetweenLength(string dataName, string value, int minLength, int maxLength, string errorMessage)=> _defaultInst.BetweenLength(dataName, value, minLength, maxLength, errorMessage);

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MinLength(string dataName, string value, int minLength) => _defaultInst.MinLength(dataName, value, minLength);

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MinLength(string dataName, string value, int minLength, string errorMessage) => _defaultInst.MinLength(dataName, value, minLength, errorMessage);

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MaxLength(string dataName, string value, int maxLength) => _defaultInst.MaxLength(dataName, value, maxLength);

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string MaxLength(string dataName, string value, int maxLength, string errorMessage) => _defaultInst.MaxLength(dataName, value, maxLength, errorMessage);

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ExactLength(string dataName, string value, int exactLength) => _defaultInst.ExactLength(dataName, value, exactLength);

    /// <summary>
    /// The length of the value should be between specified limits. If it is not, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ExactLength(string dataName, string value, int exactLength, string errorMessage)=> _defaultInst.ExactLength(dataName, value, exactLength, errorMessage);

    /// <summary>
    /// Validates that the provided value is a boolean.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Bool(string dataName, object value) => _defaultInst.Bool(dataName, value);

    /// <summary>
    /// Validates that the provided value is a boolean.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string Bool(string dataName, object value, string errorMessage) => _defaultInst.Bool(dataName, value, errorMessage);

    /// <summary>
    /// Validates that the provided value is an integer.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Int(string dataName, object value) => _defaultInst.Int(dataName, value);    

    /// <summary>
    /// Validates that the provided value is an integer.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string Int(string dataName, object value, string errorMessage) => _defaultInst.Int(dataName, value, errorMessage);

    /// <summary>
    /// Validates that the provided value is a number: int or double or real.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Number(string dataName, object value) => _defaultInst.Number(dataName, value);

    /// <summary>
    /// Validates that the provided value is a number: int or double.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string Number(string dataName, object value, string errorMessage) => _defaultInst.Number(dataName, value, errorMessage);

    /// <summary>
    /// Validates that the provided value is a string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string String(string dataName, object value) => _defaultInst.String(dataName, value);

    /// <summary>
    /// Validates that the provided value is a string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    public static string String(string dataName, object value, string errorMessage) => _defaultInst.String(dataName, value, errorMessage);

    public static string FormatDate(string dataName, string value, string format) => _defaultInst.FormatDate(dataName, value, format);

    public static string FormatDate(string dataName, string value, string format, string errorMessage) => _defaultInst.FormatDate(dataName, value, format, errorMessage);

    public static string FormatDate(string dataName, string value, string[] formats) => _defaultInst.FormatDate(dataName, value, formats);

    public static string FormatDate(string dataName, string value, string[] formats, string errorMessage) => _defaultInst.FormatDate(dataName, value, formats, errorMessage);

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailFormat(string dataName, string value) => _defaultInst.EmailFormat(dataName, value);

    /// <summary>
    /// Very simple (useful for quick checks)
    /// This pattern checks for something @something.something with no spaces.
    /// see: https://www.c-sharpcorner.com/article/validate-email-addresses-with-regular-expressions-in-c-sharp
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailFormat(string dataName, string value, string errorMessage) => _defaultInst.EmailFormat(dataName, value, errorMessage);

    /// <summary>
    /// Very simple (useful for quick checks)
    /// This pattern checks for something @something.something with no spaces.
    /// see: https://www.c-sharpcorner.com/article/validate-email-addresses-with-regular-expressions-in-c-sharp
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Email(string dataName, string value, string errorMessage) => _defaultInst.Email(dataName, value, errorMessage);

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string Email(string dataName, string value) => _defaultInst.Email(dataName, value);

    /// <summary>
    /// The value should be not null or empty. If it is, return an error message; otherwise, return an empty string.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailStrict(string dataName, string value) => _defaultInst.EmailStrict(dataName, value);

    /// <summary>
    /// Very simple (useful for quick checks)
    /// This pattern checks for something @something.something with no spaces.
    /// see: https://www.c-sharpcorner.com/article/validate-email-addresses-with-regular-expressions-in-c-sharp
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string EmailStrict(string dataName, string value, string errorMessage) => _defaultInst.EmailStrict(dataName, value, errorMessage);

    public static string BankIban(string dataName, string value) => _defaultInst.BankIban(dataName, value);

    public static string BankIban(string dataName, string value, string errorMessage) => _defaultInst.BankIban(dataName, value, errorMessage);

    public static string BankCardNumber(string dataName, string value, BankCardBank cardbank) => _defaultInst.BankCardNumber(dataName, value, cardbank);

    public static string BankCardNumber(string dataName, string value, BankCardBank cardbank, string errorMessage) => _defaultInst.BankCardNumber(dataName, value, cardbank, errorMessage);

    /// <summary>
    /// Accept all bank.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string BankCardNumber(string dataName, string value)
    {
        // all banks
        BankCardBank cardbank = BankCardBank.Visa | BankCardBank.Mastercard | BankCardBank.AmericanExpress 
            | BankCardBank.Discover | BankCardBank.DinersClub | BankCardBank.JCB | BankCardBank.ChinaUnionPay | BankCardBank.Dankord 
            | BankCardBank.DankordPure | BankCardBank.VisaDankord | BankCardBank.HiperCard | BankCardBank.JCBRuPay | BankCardBank.RuPay;

        return _defaultInst.BankCardNumber(dataName, value, cardbank);
    }

    public static string BankCardNumber(string dataName, string value, string errorMessage)
    {
        // all banks
        BankCardBank cardbank = BankCardBank.Visa | BankCardBank.Mastercard | BankCardBank.AmericanExpress | BankCardBank.Discover | BankCardBank.DinersClub | BankCardBank.JCB | BankCardBank.ChinaUnionPay;
        return _defaultInst.BankCardNumber(dataName, value, cardbank, errorMessage);
    }

}
