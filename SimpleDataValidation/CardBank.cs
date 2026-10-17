using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;

/// <summary>
/// Used to check card number.
/// </summary>
[Flags]
public enum CardBank
{
    Visa = 1,
    Mastercard = 2,
    AmericanExpress = 4,
    Discover = 8,

    DinersClub = 16,

    ChinaUnionPay=32,

    JCB=64,
}
