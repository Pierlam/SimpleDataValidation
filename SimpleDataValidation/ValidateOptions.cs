using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;

public enum ValidateOptions
{
    StopOnFirstError,
    ContinueOnAllErrors,

    /// <summary>
    /// Gets or sets a value indicating whether to display warning messages in place of default error messages.
    /// </summary>
    //MsgWarning

}
