using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;

public enum ErrorCode
{
    Null,
    NotNull,
    NotNullOrEmpty,

    NotNullOrWhiteSpace,

    Letters,

    Digits,
    LettersDigitsUnderscore,

    StartsWith,
    EndsWith,
    Contains,

    NotContains,

    FirstCharIn,

    FirstCharNotIn,

    BetweenLength,

    MinLength,

    MaxLength,

    ExactLength,

    Email,

    Bool,

    Int,

    Number,


    String,

    FormatDate,

    BankIban,

    BankCardNumber
}
