using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;

/// <summary>
/// Build table of error messages for each language. The error messages are stored in a dictionary, where the key is a combination of the language code and the error code, and the value is the corresponding error message. This allows for easy retrieval of error messages based on the current language settings.
/// </summary>
internal class ErrorMessagesTableBuilder
{
    /// <summary>
    /// Build the table of error messages for the specified language.
    /// </summary>
    /// <param name="lang"></param>
    /// <returns></returns>
    public static Dictionary<string, string> Build(string lang)
    {
        // build the table of error messages
        if(lang.Equals("en-gb", StringComparison.OrdinalIgnoreCase))
        {
            return Build_en_gb();
        }

        if (lang.Equals("fr-fr", StringComparison.OrdinalIgnoreCase))
        {
            return Build_fr_fr();
        }

        throw new NotImplementedException("Language not implemented: " + lang);
    }

    static Dictionary<string, string> Build_en_gb()
    {
        string lang = "en-gb.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.NotNull, "{0} is required" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} is required" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} is required" },
            { lang + ErrorCode.Letters, "{0} must contains only letter" },
            { lang + ErrorCode.Digits, "{0} must contains only digit" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} must contains only letter, digit or underscore" },
            { lang + ErrorCode.BetweenLength, "{0} must be between {1} and {2} characters long" },
            { lang + ErrorCode.MinLength, "{0} must be at least {1} characters long" },
            { lang + ErrorCode.MaxLength, "{0} must be no more than {1} characters long" },
            { lang + ErrorCode.ExactLength, "{0} must be exactly {1} characters long" },
            { lang + ErrorCode.Email, "{0} must be a valid email address" },
            { lang + ErrorCode.Int, "{0} must be an integer" },
            { lang + ErrorCode.Iban, "{0} must be a valid IBAN" },
            { lang + ErrorCode.CardNumber, "{0} must be a valid Card Number" },

        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_fr_fr()
    {
        string lang = "fr-fr.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.NotNull, "{0} est requis" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} est requis" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} est requis" },
            { lang + ErrorCode.Letters, "{0} doit contenir seulement des lettres" },
            { lang + ErrorCode.Digits, "{0} doit contenir seulement des chiffres" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} doit contenir seulement des lettres, chiffres ou le caractère underscore" },
            { lang + ErrorCode.BetweenLength, "{0} doit contenir entre {1} et {2} caractères" },
            { lang + ErrorCode.MinLength, "{0} doit contenir au moins {1} caractères"  },
            { lang + ErrorCode.MaxLength, "{0} doit contenir au maximum {1} caractères" },
            { lang + ErrorCode.ExactLength, "{0} doit contenir exactement {1} caractères"  },
            { lang + ErrorCode.Email, "{0} doit être une adresse email valide" },
            { lang + ErrorCode.Int, "{0} doit être un entier" },
            { lang + ErrorCode.Iban, "{0} doit être un IBAN valide" },
            { lang + ErrorCode.CardNumber, "{0} doit être un numéro de carte valide" },

        };

        return tableErrorMsg;
    }

}
