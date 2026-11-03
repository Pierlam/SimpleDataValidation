using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;


/// <summary>
/// Validation options, uses in validation chain.
/// </summary>
public enum ValidOptions
{
    StopOnFirstError,
    ContinueOnAllErrors,

    /// <summary>
    /// Gets or sets a value indicating whether to display warning messages in place of default error messages.
    /// </summary>
    //MsgWarning

}
