using SimpleDataValidation.ErrorMsg;

namespace SimpleDataValidation;

public partial class V
{
    /// <summary>
    /// The default language for error messages. This value is used when no specific language is set or when the specified language is not found in the error message table. The default value is "en-gb" (English - Great Britain).
    /// </summary>
    static string _defaultLang = "en-gb";

    /// <summary>
    /// The default instance used by static methods.
    /// </summary>
    protected static VInst _defaultInst;

    /// <summary>
    /// Initializes the static members of the V class, including the default language and the error message table for that language. This static constructor is called automatically before any static members are accessed or any instances of the class are created.
    /// </summary>
    static V()
    {
        _defaultInst = new VInst();

        // build the table of error messages
        Setlanguage(_defaultLang);
    }

    /// <summary>
    /// Create an instance of V.
    /// </summary>
    /// <returns></returns>
    public static VInst CreateInst()
    {
        VInst vinst= new VInst();
        vinst.Setlanguage(_defaultLang);
        return vinst;
    }

    public static void Setlanguage(string lang)
    {
        _defaultInst.Setlanguage(lang);
        //_errorMessageMgr.CurrentLang = lang;

        // build the table of error messages
        //_errorMessageMgr.TableErrorMsg = ErrorMessagesTableBuilder.Build(_errorMessageMgr.CurrentLang);
    }

    public static void SetMessageSeparator(string separator)
    {
        _defaultInst.SetMessageSeparator(separator);
    }

    public static void SetMessageEnd(string endMessage)
    {
        _defaultInst.SetMessageEnd(endMessage);
    }

    public static void SetMessageEndDot()
    {
        _defaultInst.SetMessageEnd(".");
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
    public static VChain Define(string dataName, string value)
    {
        return _defaultInst.Define(dataName, value);
    }
}
