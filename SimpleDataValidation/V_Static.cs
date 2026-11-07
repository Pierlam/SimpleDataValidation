using SimpleDataValidation.ErrorMsg;

namespace SimpleDataValidation;

public partial class V
{
    /// <summary>
    /// The ErrorMessageMgr instance is responsible for managing error messages, including retrieving the appropriate error message based on the current language and error code. It also provides functionality to set the current language and build the table of error messages for that language.
    /// </summary>
    protected static ErrorMessageMgr _errorMessageMgr = new ErrorMessageMgr();

    /// <summary>
    /// Initializes the static members of the V class, including the default language and the error message table for that language. This static constructor is called automatically before any static members are accessed or any instances of the class are created.
    /// </summary>
    static V()
    {
        // build the table of error messages
        Setlanguage(_errorMessageMgr.CurrentLang);
    }

    public static void Setlanguage(string lang)
    {
        _errorMessageMgr.CurrentLang = lang;

        // build the table of error messages
        _errorMessageMgr.TableErrorMsg = ErrorMessagesTableBuilder.Build(_errorMessageMgr.CurrentLang);
    }

    public static void SetMessageSeparator(string separator)
    {
        _errorMessageMgr.BetweenMsg = separator;
    }

    public static void SetMessageEnd(string endMessage)
    {
        _errorMessageMgr.MessageEnd = endMessage;
    }

    public static void SetMessageEndDot()
    {
        _errorMessageMgr.MessageEnd = ".";
    }

    /// <summary>
    /// If the error message contains a text, it's an error, so return true.
    /// </summary>
    /// <param name="errMsg"></param>
    /// <returns></returns>
    public static bool Error(string errMsg)
    {
        if (string.IsNullOrWhiteSpace(errMsg)) return false;
        return true;
    }

    /// <summary>
    /// If the error message is empty, it's not an error but a success so return true.
    /// </summary>
    /// <param name="errMsg"></param>
    /// <returns></returns>
    public static bool Ok(string errMsg)
    {
        if (!string.IsNullOrWhiteSpace(errMsg)) return false;
        return true;
    }

    /// <summary>
    /// Defines a new validation context for a given data field, allowing the chaining of validation rules.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static V  Define(string dataName, string value)
    {
        V v = new V(dataName, value);
        return v;
    }
}
