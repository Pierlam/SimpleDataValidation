using SimpleDataValidation.ErrorMsg;
using SimpleDataValidation.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;

public abstract class VBase
{
    /// <summary>
    /// The ErrorMessageMgr instance is responsible for managing error messages, including retrieving the appropriate error message based on the current language and error code. It also provides functionality to set the current language and build the table of error messages for that language.
    /// </summary>
    protected static ErrorMessageMgr _errorMessageMgr = new ErrorMessageMgr();

    /// <summary>
    /// The name of the data field being validated. This is used in error messages to indicate which field has failed validation.
    /// </summary>
    protected string _dataName;

    /// <summary>
    /// The value being validated. This is the actual data that will be checked against the defined validation rules.
    /// </summary>
    protected string _value;

    /// <summary>
    /// To save the list of validation rules that have been defined for this instance of the V class. Each rule is represented by an instance of a class that inherits from RuleBase.
    /// </summary>
    protected List<RuleBase> _ruleBases = new List<RuleBase>();

    /// <summary>
    /// Initializes the static members of the V class, including the default language and the error message table for that language. This static constructor is called automatically before any static members are accessed or any instances of the class are created.
    /// </summary>
    static VBase()
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

    public static void SetEndMessage(string endMessage)
    {
        _errorMessageMgr.EndMessage = endMessage;
    }

    public static void SetEndMessageDot()
    {
        _errorMessageMgr.EndMessage = ".";
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
    public static V Define(string dataName, string value)
    {
        V v = new V(dataName, value);
        return v;
    }

    /// <summary>
    /// Apply the defined validation rules to the value and return an error message if any rule fails. If all rules pass, return an empty string.
    /// </summary>
    /// <returns></returns>
    public string Validate()
    {
        string finalErrMsg = string.Empty;
        foreach (var rule in _ruleBases)
        {
            string errMsg = RuleValidator.Validate(_errorMessageMgr, rule, _dataName, _value);
            if (!string.IsNullOrEmpty(errMsg))
            {
                if(!string.IsNullOrEmpty(finalErrMsg))
                {
                    finalErrMsg += _errorMessageMgr.BetweenMsg;
                }
                finalErrMsg += errMsg;
            }
        }
        return finalErrMsg.Trim();
    }    
}
