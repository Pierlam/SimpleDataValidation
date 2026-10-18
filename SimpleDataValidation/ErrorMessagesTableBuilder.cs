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

        if (lang.Equals("es-es", StringComparison.OrdinalIgnoreCase))
        {
            return Build_es_es();
        }

        if (lang.Equals("de-de", StringComparison.OrdinalIgnoreCase))
        {
            return Build_de_de();
        }

        if (lang.Equals("it-it", StringComparison.OrdinalIgnoreCase))
        {
            return Build_it_it();
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

            { lang + ErrorCode.StarsWith, "{0} must starts with: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0} first char must be in: {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0} first char must be not in: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} must be between {1} and {2} characters long" },
            { lang + ErrorCode.MinLength, "{0} must be at least {1} characters long" },
            { lang + ErrorCode.MaxLength, "{0} must be no more than {1} characters long" },
            { lang + ErrorCode.ExactLength, "{0} must be exactly {1} characters long" },
            { lang + ErrorCode.Email, "{0} must be a valid email address" },
            { lang + ErrorCode.Int, "{0} must be an integer" },
            { lang + ErrorCode.Number, "{0} must be a number" },
            { lang + ErrorCode.String, "{0} must be a string" },
            { lang + ErrorCode.Iban, "{0} must be a valid IBAN" },
            { lang + ErrorCode.CardNumber, "{0} must be a valid Card Number" },
        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_it_it()
    {
        string lang = "it-it.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.NotNull, "{0} è obbligatorio" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} è obbligatorio" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} è obbligatorio" },
            { lang + ErrorCode.Letters, "{0} deve contenere solo lettere" },
            { lang + ErrorCode.Digits, "{0} deve contenere solo cifre" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} deve contenere solo lettere, cifre o il carattere underscore" },

            { lang + ErrorCode.StarsWith, "{0} deve iniziare con: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0}: il primo carattere deve essere uno dei seguenti: {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0}: il primo carattere non deve essere uno dei seguenti: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} deve avere una lunghezza compresa tra {1} e {2} caratteri" },
            { lang + ErrorCode.MinLength, "{0} deve avere almeno {1} caratteri"  },
            { lang + ErrorCode.MaxLength, "{0} non deve avere più di {1} caratteri" },
            { lang + ErrorCode.ExactLength, "{0} deve avere esattamente {1} caratteri"  },
            { lang + ErrorCode.Email, "{0} deve essere un indirizzo email valido" },
            { lang + ErrorCode.Int, "{0} deve essere un numero intero" },
            { lang + ErrorCode.Number, "{0} deve essere un numero" },
            { lang + ErrorCode.String, "{0} deve essere una stringa" },
            { lang + ErrorCode.Iban, "{0} deve essere un IBAN valido" },
            { lang + ErrorCode.CardNumber, "{0} deve essere un numero di carta valido" },

        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_de_de()
    {
        string lang = "de-de.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.NotNull, "{0} ist erforderlich" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} ist erforderlich" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} ist erforderlich" },
            { lang + ErrorCode.Letters, "{0} darf nur Buchstaben enthalten" },
            { lang + ErrorCode.Digits, "{0} darf nur Ziffern enthalten" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} darf nur Buchstaben, Ziffern oder Unterstriche enthalten" },

            { lang + ErrorCode.StarsWith, "{0} muss mit folgendem beginnen: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0}: das erste Zeichen muss eines der folgenden sein: {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0}: das erste Zeichen darf nicht eines der folgenden sein: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} muss zwischen {1} und {2} Zeichen lang sein" },
            { lang + ErrorCode.MinLength, "{0} muss mindestens {1} Zeichen lang sein"  },
            { lang + ErrorCode.MaxLength, "{0} darf höchstens {1} Zeichen lang sein" },
            { lang + ErrorCode.ExactLength, "{0} muss genau {1} Zeichen lang sein"  },
            { lang + ErrorCode.Email, "{0} muss eine gültige E-Mail-Adresse sein" },
            { lang + ErrorCode.Int, "{0} muss eine ganze Zahl sein" },
            { lang + ErrorCode.Number, "{0} muss eine Zahl sein" },
            { lang + ErrorCode.String, "{0} muss eine Zeichenkette sein" },
            { lang + ErrorCode.Iban, "{0} muss eine gültige IBAN sein" },
            { lang + ErrorCode.CardNumber, "{0} muss eine gültige Kartennummer sein" },
        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_es_es()
    {
        string lang = "es-es.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.NotNull, "{0} es obligatorio" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} es obligatorio" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} es obligatorio" },
            { lang + ErrorCode.Letters, "{0} debe contener solo letras" },
            { lang + ErrorCode.Digits, "{0} debe contener solo dígitos" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} debe contener solo letras, dígitos o el carácter carácter de subrayado (guion bajo)" },

            { lang + ErrorCode.StarsWith, "{0} debe comenzar por: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0} debe tener como primer carácter uno de los siguientes: {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0} no debe tener como primer carácter uno de los siguientes: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} debe tener entre {1} y {2} caracteres" },
            { lang + ErrorCode.MinLength, "{0} debe tener al menos {1} caracteres"  },
            { lang + ErrorCode.MaxLength, "{0} no debe tener más de {1} caracteres" },
            { lang + ErrorCode.ExactLength, "{0} debe tener exactamente {1} caracteres"  },
            { lang + ErrorCode.Email, "{0} debe ser una dirección de correo electrónico válida" },
            { lang + ErrorCode.Int, "{0} debe ser un número entero" },
            { lang + ErrorCode.Number, "{0} debe ser un número" },
            { lang + ErrorCode.String, "{0} debe ser una cadena de texto" },
            { lang + ErrorCode.Iban, "{0} debe ser un IBAN válido" },
            { lang + ErrorCode.CardNumber, "{0} debe ser un número de tarjeta válido" },
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

            { lang + ErrorCode.StarsWith, "{0} doit commencer par: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0} doit avoir en premier un de ces caractère(s): {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0} ne doit pas avoir en premier un de ces caractère(s): {1}" },

            { lang + ErrorCode.BetweenLength, "{0} doit contenir entre {1} et {2} caractères" },
            { lang + ErrorCode.MinLength, "{0} doit contenir au moins {1} caractères"  },
            { lang + ErrorCode.MaxLength, "{0} doit contenir au maximum {1} caractères" },
            { lang + ErrorCode.ExactLength, "{0} doit contenir exactement {1} caractères"  },
            { lang + ErrorCode.Email, "{0} doit être une adresse email valide" },
            { lang + ErrorCode.Int, "{0} doit être un entier" },
            { lang + ErrorCode.Number, "{0} doit être un nombre" },
            { lang + ErrorCode.String, "{0} doit être une chaîne de caractères" },
            { lang + ErrorCode.Iban, "{0} doit être un IBAN valide" },
            { lang + ErrorCode.CardNumber, "{0} doit être un numéro de carte valide" },

        };

        return tableErrorMsg;
    }

}
