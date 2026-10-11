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

    LettersDigitsUnderscore,
    BetweenLength,

    MinLength,

    MaxLength,

    ExactLength,

    Email,

    Int,

    Iban
}
