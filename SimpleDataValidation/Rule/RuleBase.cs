using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public abstract class RuleBase
{
    /// <summary>
    /// User defined message, override the default one.
    /// </summary>
    public string ErrorMessage { get; }
}
