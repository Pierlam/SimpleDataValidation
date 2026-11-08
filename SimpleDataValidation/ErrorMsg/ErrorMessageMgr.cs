using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.ErrorMsg;

public class ErrorMessageMgr
{
    // starting from NET9
    //private readonly Lock lockObject = new();
    /// <summary>
    /// In a strong multi-thread env, some trouble to get the message from the dictionary should occurs.
    /// </summary>
    private readonly object _lock = new();

    /// <summary>
    /// https://www.andiamo.co.uk/resources/iso-language-codes/
    /// Lang -> ErrorCode -> Msg
    /// 2 levels: Lang.ErrorCode -> Msg
    /// exp: en-gb.NotNull  -> "The {0} is required"
    /// </summary>
    public Dictionary<string, string> TableErrorMsg;

    public string CurrentLang = "en-gb";

    public string DefaultErrorMessage = "An error occurred, code: {0}";

    /// <summary>
    /// last part of the error message, for example: "." or "!"
    /// </summary>
    public string MessageEnd = string.Empty;

    /// <summary>
    /// string to put between two error messages, used in chain validation.
    /// </summary>
    public string BetweenMsg = " - ";

    /// <summary>
    /// Retrieves the error message corresponding to the specified error code and field name, formatted according to the current language settings. If the error code is not found in the error message table, a default error message is returned.
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="dataName"></param>
    /// <returns></returns>
    public string GetMessage(ErrorCode errorCode, string dataName)
    {
        lock (_lock)
        {
            // current language
            string key = CurrentLang + "." + errorCode.ToString();

            if (TableErrorMsg.TryGetValue(key, out string msg))
            {
                // replace msg params
                return string.Format(msg, dataName) + MessageEnd;
            }

            // sometimes failed in multi-thread env, so try again
            if (TableErrorMsg.TryGetValue(key, out msg))
            {
                // replace msg params
                return string.Format(msg, dataName) + MessageEnd;
            }
        }
        // return the default error message if the specific error code is not found in the error message table
        return string.Format(DefaultErrorMessage, errorCode.ToString()) + MessageEnd;
    }

    /// <summary>
    /// Retrieves the error message corresponding to the specified error code and field name, formatted according to the current language settings. If the error code is not found in the error message table, a default error message is returned.
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="dataName"></param>
    /// <returns></returns>
    public string GetMessage(ErrorCode errorCode, string dataName, string p1)
    {
        lock (_lock)
        {
            // current language
            string key = CurrentLang + "." + errorCode.ToString();

            if (TableErrorMsg.TryGetValue(key, out string msg))
            {
                // replace msg params
                return string.Format(msg, dataName, p1) + MessageEnd;
            }
            // sometimes failed in multi-thread env, so try again
            if (TableErrorMsg.TryGetValue(key, out msg))
            {
                // replace msg params
                return string.Format(msg, dataName, p1) + MessageEnd;
            }
        }
        // return the default error message if the specific error code is not found in the error message table
        return string.Format(DefaultErrorMessage, errorCode.ToString()) + MessageEnd;
    }

    /// <summary>
    /// Retrieves the error message corresponding to the specified error code and field name, formatted according to the current language settings. If the error code is not found in the error message table, a default error message is returned.
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="dataName"></param>
    /// <returns></returns>
    public string GetMessage(ErrorCode errorCode, string dataName, string p1, string p2)
    {
        lock (_lock)
        {
            // current language
            string key = CurrentLang + "." + errorCode.ToString();
            if (TableErrorMsg.TryGetValue(key, out string msg))
            {
                // replace msg params
                return string.Format(msg, dataName, p1, p2) + MessageEnd;
            }
            // sometimes failed in multi-thread env, so try again
            if (TableErrorMsg.TryGetValue(key, out msg))
            {
                // replace msg params
                return string.Format(msg, dataName, p1, p2) + MessageEnd;
            }
        }
        // return the default error message if the specific error code is not found in the error message table
        return string.Format(DefaultErrorMessage, errorCode.ToString()) + MessageEnd;
    }
}
