using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;

public enum ErrorCode
{
    True,
    False,

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

    FirstCharLetter,

    BetweenLength,

    MinLength,

    MaxLength,

    ExactLength,

    Email,

    Bool,

    Int,

    Number,


    String,

    EqualsString,
    EqualsDate,

    FormatDate,

    BankIban,

    BankCardNumber
}
