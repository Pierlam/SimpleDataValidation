using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.ErrorMsg;

public class ErrorMessageMgr
{
    /// <summary>
    /// https://www.andiamo.co.uk/resources/iso-language-codes/
    /// Lang -> ErrorCode -> Msg
    /// 2 levels: Lang.ErrorCode -> Msg
    /// exp: en-gb.NotNull  -> "The {0} is required"
    /// </summary>
    public Dictionary<string, string> TableErrorMsg;

    /// <summary>
    /// The default language for error messages. This value is used when no specific language is set or when the specified language is not found in the error message table. The default value is "en-gb" (English - Great Britain).
    /// </summary>
    public string DefaultLang = "en-gb";

    public string CurrentLang = "en-gb";

    public string DefaultErrorMessage = "An error occurred, code: {0}";

    /// <summary>
    /// last part of the error message, for example: "." or "!"
    /// </summary>
    public string EndMessage = string.Empty;

    public string BetweenMsg = " - ";

    /// <summary>
    /// Retrieves the error message corresponding to the specified error code and field name, formatted according to the current language settings. If the error code is not found in the error message table, a default error message is returned.
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="dataName"></param>
    /// <returns></returns>
    public string GetMessage(ErrorCode errorCode, string dataName)
    {
        // current language
        string key = CurrentLang + "." + errorCode.ToString();

        if (TableErrorMsg.ContainsKey(key))
        {
            string msg = TableErrorMsg[key];

            // replace msg params
            return string.Format(msg, dataName) + EndMessage;
        }
        // return the default error message if the specific error code is not found in the error message table
        return string.Format(DefaultErrorMessage, errorCode.ToString()) + EndMessage;
    }

    /// <summary>
    /// Retrieves the error message corresponding to the specified error code and field name, formatted according to the current language settings. If the error code is not found in the error message table, a default error message is returned.
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="dataName"></param>
    /// <returns></returns>
    public string GetMessage(ErrorCode errorCode, string dataName, string p1)
    {
        // current language
        string key = CurrentLang + "." + errorCode.ToString();

        if (TableErrorMsg.ContainsKey(key))
        {
            string msg = TableErrorMsg[key];

            // replace msg params
            return string.Format(msg, dataName, p1) + EndMessage;
        }
        // return the default error message if the specific error code is not found in the error message table
        return string.Format(DefaultErrorMessage, errorCode.ToString()) + EndMessage;
    }

    /// <summary>
    /// Retrieves the error message corresponding to the specified error code and field name, formatted according to the current language settings. If the error code is not found in the error message table, a default error message is returned.
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="dataName"></param>
    /// <returns></returns>
    public string GetMessage(ErrorCode errorCode, string dataName, string p1, string p2)
    {
        // current language
        string key = CurrentLang + "." + errorCode.ToString();

        if (TableErrorMsg.ContainsKey(key))
        {
            string msg = TableErrorMsg[key];

            // replace msg params
            return string.Format(msg, dataName, p1, p2) + EndMessage;
        }
        // return the default error message if the specific error code is not found in the error message table
        return string.Format(DefaultErrorMessage, errorCode.ToString()) + EndMessage;
    }
}
