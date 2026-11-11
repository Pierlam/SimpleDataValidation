using SimpleDataValidation.ErrorMsg;
using SimpleDataValidation.Rule;

namespace SimpleDataValidation;

public partial class VInst
{
    /// <summary>
    /// The ErrorMessageMgr instance is responsible for managing error messages, including retrieving the appropriate error message based on the current language and error code. It also provides functionality to set the current language and build the table of error messages for that language.
    /// </summary>
    protected ErrorMessageMgr _errorMessageMgr;

    /// <summary>
    /// Constructor for the V class, initializing the validation context with the specified field name and value.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="value"></param>
    public VInst(string lang)
    {
        _errorMessageMgr = new ErrorMessageMgr
        {
            CurrentLang = lang
        };
        // build the table of error messages
        _errorMessageMgr.TableErrorMsg = ErrorMessagesTableBuilder.Build(_errorMessageMgr.CurrentLang);
    }

    public void Setlanguage(string lang)
    {
        _errorMessageMgr.CurrentLang= lang;

        // build the table of error messages
        _errorMessageMgr.TableErrorMsg = ErrorMessagesTableBuilder.Build(_errorMessageMgr.CurrentLang);
    }

    public void SetMessageSeparator(string separator)
    {
        _errorMessageMgr.BetweenMsg = separator;
    }

    public void SetMessageEnd(string endMessage)
    {
        _errorMessageMgr.MessageEnd = endMessage;
    }

    public void SetMessageEndDot()
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
    public VChain Define(string dataName, object value)
    {
        VChain vChain = new VChain(_errorMessageMgr, dataName, value);
        return vChain;
    }

}
