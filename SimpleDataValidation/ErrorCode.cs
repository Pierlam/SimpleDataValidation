using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;

public enum ErrorCode
{
    NotNull,
    NotNullOrEmpty,

    NotNullOrWhiteSpace,

    Letters,

    Digits,
    LettersDigitsUnderscore,

    StarsWith,

    FirstCharIn,

    FirstCharNotIn,

    BetweenLength,

    MinLength,

    MaxLength,

    ExactLength,

    Email,

    Int,

    Number,

    String,

    Iban,

    CardNumber
}
