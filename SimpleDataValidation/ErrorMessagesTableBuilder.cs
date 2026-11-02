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

        // french
        if (lang.Equals("fr-fr", StringComparison.OrdinalIgnoreCase))
        {
            return Build_fr_fr();
        }

        // spanish
        if (lang.Equals("es-es", StringComparison.OrdinalIgnoreCase))
        {
            return Build_es_es();
        }

        // german
        if (lang.Equals("de-de", StringComparison.OrdinalIgnoreCase))
        {
            return Build_de_de();
        }

        // italian
        if (lang.Equals("it-it", StringComparison.OrdinalIgnoreCase))
        {
            return Build_it_it();
        }

        // chinese
        if (lang.Equals("zh-cn", StringComparison.OrdinalIgnoreCase))
        {
            return Build_zh_cn();
        }

        // hindi
        if (lang.Equals("hi-in", StringComparison.OrdinalIgnoreCase))
        {
            return Build_hi_in();
        }

        // portuguese
        if (lang.Equals("pt-pt", StringComparison.OrdinalIgnoreCase))
        {
            return Build_pt_pt();
        }

        // brazilian portuguese
        if (lang.Equals("pt-br", StringComparison.OrdinalIgnoreCase))
        {
            return Build_pt_br();
        }

        throw new NotImplementedException("Language not implemented: " + lang);
    }

    static Dictionary<string, string> Build_en_gb()
    {
        string lang = "en-gb.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.Null, "{0} must be null" },
            { lang + ErrorCode.NotNull, "{0} is required" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} is required" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} is required" },

            { lang + ErrorCode.Letters, "{0} must contains only letter" },
            { lang + ErrorCode.Digits, "{0} must contains only digit" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} must contains only letter, digit or underscore" },

            { lang + ErrorCode.StartsWith, "{0} must starts with: {1}" },
            { lang + ErrorCode.EndsWith, "{0} must ends with: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0} first char must be in: {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0} first char must be not in: {1}" },
            { lang + ErrorCode.Contains, "{0} must contain: {1}" },
            { lang + ErrorCode.NotContains, "{0} must not contain: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} must be between {1} and {2} characters long" },
            { lang + ErrorCode.MinLength, "{0} must be at least {1} characters long" },
            { lang + ErrorCode.MaxLength, "{0} must be no more than {1} characters long" },
            { lang + ErrorCode.ExactLength, "{0} must be exactly {1} characters long" },

            { lang + ErrorCode.Bool, "{0} must be a boolean" },
            { lang + ErrorCode.Int, "{0} must be an integer" },
            { lang + ErrorCode.Number, "{0} must be a number" },
            { lang + ErrorCode.String, "{0} must be a string" },

            { lang + ErrorCode.FormatDate, "{0} must be a valid date" },

            { lang + ErrorCode.Email, "{0} must be a valid email address" },

            { lang + ErrorCode.BankIban, "{0} must be a valid IBAN" },
            { lang + ErrorCode.BankCardNumber, "{0} must be a valid Card Number" },
        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_it_it()
    {
        string lang = "it-it.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.Null, "{0} deve essere null" },
            { lang + ErrorCode.NotNull, "{0} è obbligatorio" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} è obbligatorio" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} è obbligatorio" },

            { lang + ErrorCode.Letters, "{0} deve contenere solo lettere" },
            { lang + ErrorCode.Digits, "{0} deve contenere solo cifre" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} deve contenere solo lettere, cifre o il carattere underscore" },

            { lang + ErrorCode.StartsWith, "{0} deve iniziare con: {1}" },
            { lang + ErrorCode.EndsWith, "{0} deve terminare con: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0}: il primo carattere deve essere uno dei seguenti: {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0}: il primo carattere non deve essere uno dei seguenti: {1}" },
            { lang + ErrorCode.Contains, "{0} deve contenere: {1}" },
            { lang + ErrorCode.NotContains, "{0} non deve contenere: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} deve avere una lunghezza compresa tra {1} e {2} caratteri" },
            { lang + ErrorCode.MinLength, "{0} deve avere almeno {1} caratteri"  },
            { lang + ErrorCode.MaxLength, "{0} non deve avere più di {1} caratteri" },
            { lang + ErrorCode.ExactLength, "{0} deve avere esattamente {1} caratteri"  },

            { lang + ErrorCode.Bool, "{0} deve essere un valore booleano" },
            { lang + ErrorCode.Int, "{0} deve essere un numero intero" },
            { lang + ErrorCode.Number, "{0} deve essere un numero" },
            { lang + ErrorCode.String, "{0} deve essere una stringa" },

            { lang + ErrorCode.FormatDate, "{0} deve essere una data valida" },

            { lang + ErrorCode.Email, "{0} deve essere un indirizzo email valido" },

            { lang + ErrorCode.BankIban, "{0} deve essere un IBAN valido" },
            { lang + ErrorCode.BankCardNumber, "{0} deve essere un numero di carta valido" },

        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_de_de()
    {
        string lang = "de-de.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.Null, "{0} muss null sein" },
            { lang + ErrorCode.NotNull, "{0} ist erforderlich" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} ist erforderlich" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} ist erforderlich" },

            { lang + ErrorCode.Letters, "{0} darf nur Buchstaben enthalten" },
            { lang + ErrorCode.Digits, "{0} darf nur Ziffern enthalten" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} darf nur Buchstaben, Ziffern oder Unterstriche enthalten" },

            { lang + ErrorCode.StartsWith, "{0} muss mit folgendem beginnen: {1}" },
            { lang + ErrorCode.EndsWith, "{0} muss mit folgendem enden: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0}: das erste Zeichen muss eines der folgenden sein: {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0}: das erste Zeichen darf nicht eines der folgenden sein: {1}" },
            { lang + ErrorCode.Contains, "{0} muss Folgendes enthalten: {1}" },
            { lang + ErrorCode.NotContains, "{0} darf Folgendes nicht enthalten: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} muss zwischen {1} und {2} Zeichen lang sein" },
            { lang + ErrorCode.MinLength, "{0} muss mindestens {1} Zeichen lang sein"  },
            { lang + ErrorCode.MaxLength, "{0} darf höchstens {1} Zeichen lang sein" },
            { lang + ErrorCode.ExactLength, "{0} muss genau {1} Zeichen lang sein"  },

            { lang + ErrorCode.Bool, "{0} muss ein boolescher Wert sein" },
            { lang + ErrorCode.Int, "{0} muss eine ganze Zahl sein" },
            { lang + ErrorCode.Number, "{0} muss eine Zahl sein" },
            { lang + ErrorCode.String, "{0} muss eine Zeichenkette sein" },

            { lang + ErrorCode.FormatDate, "{0} muss ein gültiges Datum sein" },

            { lang + ErrorCode.Email, "{0} muss eine gültige E-Mail-Adresse sein" },

            { lang + ErrorCode.BankIban, "{0} muss eine gültige IBAN sein" },
            { lang + ErrorCode.BankCardNumber, "{0} muss eine gültige Kartennummer sein" },
        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_es_es()
    {
        string lang = "es-es.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.Null, "{0} debe ser nulo" },
            { lang + ErrorCode.NotNull, "{0} es obligatorio" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} es obligatorio" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} es obligatorio" },

            { lang + ErrorCode.Letters, "{0} debe contener solo letras" },
            { lang + ErrorCode.Digits, "{0} debe contener solo dígitos" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} debe contener solo letras, dígitos o el carácter carácter de subrayado (guion bajo)" },

            { lang + ErrorCode.StartsWith, "{0} debe comenzar por: {1}" },
            { lang + ErrorCode.EndsWith, "{0} debe terminar en: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0} debe tener como primer carácter uno de los siguientes: {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0} no debe tener como primer carácter uno de los siguientes: {1}" },
            { lang + ErrorCode.Contains, "{0} debe contener: {1}" },
            { lang + ErrorCode.NotContains, "{0} no debe contener: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} debe tener entre {1} y {2} caracteres" },
            { lang + ErrorCode.MinLength, "{0} debe tener al menos {1} caracteres"  },
            { lang + ErrorCode.MaxLength, "{0} no debe tener más de {1} caracteres" },
            { lang + ErrorCode.ExactLength, "{0} debe tener exactamente {1} caracteres"  },

            { lang + ErrorCode.Bool, "{0} debe ser un valor booleano" },
            { lang + ErrorCode.Int, "{0} debe ser un número entero" },
            { lang + ErrorCode.Number, "{0} debe ser un número" },
            { lang + ErrorCode.String, "{0} debe ser una cadena de texto" },

            { lang + ErrorCode.FormatDate, "{0} debe ser una fecha válida" },

            { lang + ErrorCode.Email, "{0} debe ser una dirección de correo electrónico válida" },

            { lang + ErrorCode.BankIban, "{0} debe ser un IBAN válido" },
            { lang + ErrorCode.BankCardNumber, "{0} debe ser un número de tarjeta válido" },
        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_fr_fr()
    {
        string lang = "fr-fr.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.Null, "{0} doit être null" },
            { lang + ErrorCode.NotNull, "{0} est requis" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} est requis" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} est requis" },
            { lang + ErrorCode.Letters, "{0} doit contenir seulement des lettres" },
            { lang + ErrorCode.Digits, "{0} doit contenir seulement des chiffres" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} doit contenir seulement des lettres, chiffres ou le caractère underscore" },

            { lang + ErrorCode.StartsWith, "{0} doit commencer par: {1}" },
            { lang + ErrorCode.EndsWith, "{0} doit se terminer par: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0} doit avoir en premier un de ces caractère(s): {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0} ne doit pas avoir en premier un de ces caractère(s): {1}" },
            { lang + ErrorCode.Contains, "{0} doit contenir: {1}" },
            { lang + ErrorCode.NotContains, "{0} ne doit pas contenir: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} doit contenir entre {1} et {2} caractères" },
            { lang + ErrorCode.MinLength, "{0} doit contenir au moins {1} caractères"  },
            { lang + ErrorCode.MaxLength, "{0} doit contenir au maximum {1} caractères" },
            { lang + ErrorCode.ExactLength, "{0} doit contenir exactement {1} caractères"  },

            { lang + ErrorCode.Bool, "{0} doit être une valeur booléenne" },
            { lang + ErrorCode.Int, "{0} doit être un entier" },
            { lang + ErrorCode.Number, "{0} doit être un nombre" },
            { lang + ErrorCode.String, "{0} doit être une chaîne de caractères" },

            { lang + ErrorCode.FormatDate, "{0} doit être une date valide" },

            { lang + ErrorCode.Email, "{0} doit être une adresse email valide" },

            { lang + ErrorCode.BankIban, "{0} doit être un IBAN valide" },
            { lang + ErrorCode.BankCardNumber, "{0} doit être un numéro de carte valide" },

        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_zh_cn()
    {
        string lang = "zh-cn.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.Null, "{0} 必须为 null" },
            { lang + ErrorCode.NotNull, "{0} 为必填项" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} 为必填项" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} 为必填项" },

            { lang + ErrorCode.Letters, "{0} 只能包含字母" },
            { lang + ErrorCode.Digits, "{0} 只能包含数字" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} 只能包含字母、数字或下划线" },

            { lang + ErrorCode.StartsWith, "{0} 必须以以下内容开头：{1}" },
            { lang + ErrorCode.EndsWith, "{0} 必须以以下内容结尾：{1}" },
            { lang + ErrorCode.Contains, "{0} 必须包含：{1}" },
            { lang + ErrorCode.NotContains, "{0} 不能包含：{1}" },
            { lang + ErrorCode.FirstCharIn, "{0} 的第一个字符必须是以下字符之一：{1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0} 的第一个字符不能是以下字符之一：{1}" },

            { lang + ErrorCode.BetweenLength, "{0} 的长度必须介于 {1} 和 {2} 个字符之间" },
            { lang + ErrorCode.MinLength, "{0} 的长度至少为 {1} 个字符" },
            { lang + ErrorCode.MaxLength, "{0} 的长度不能超过 {1} 个字符" },
            { lang + ErrorCode.ExactLength, "{0} 的长度必须正好为 {1} 个字符" },

            { lang + ErrorCode.Bool, "{0} 必须是布尔值" },
            { lang + ErrorCode.Int, "{0} 必须是整数" },
            { lang + ErrorCode.Number, "{0} 必须是数字" },
            { lang + ErrorCode.String, "{0} 必须是字符串" },
            { lang + ErrorCode.FormatDate, "{0} 必须是有效的日期" },

            { lang + ErrorCode.Email, "{0} 必须是有效的电子邮件地址" },
            { lang + ErrorCode.BankIban, "{0} 必须是有效的 IBAN" },
            { lang + ErrorCode.BankCardNumber, "{0} 必须是有效的银行卡号" },
        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_hi_in()
    {
        string lang = "hi-in.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.Null, "{0} का मान null होना चाहिए" },
            { lang + ErrorCode.NotNull, "{0} आवश्यक है" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} आवश्यक है" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} आवश्यक है" },

            { lang + ErrorCode.Letters, "{0} में केवल अक्षर होने चाहिए" },
            { lang + ErrorCode.Digits, "{0} में केवल अंक होने चाहिए" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} में केवल अक्षर, अंक या अंडरस्कोर होना चाहिए" },

            { lang + ErrorCode.StartsWith, "{0} की शुरुआत इनसे होनी चाहिए: {1}" },
            { lang + ErrorCode.EndsWith, "{0} का अंत इनसे होना चाहिए: {1}" },
            { lang + ErrorCode.Contains, "{0} में यह शामिल होना चाहिए: {1}" },
            { lang + ErrorCode.NotContains, "{0} में यह शामिल नहीं होना चाहिए: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0} का पहला अक्षर इनमें से एक होना चाहिए: {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0} का पहला अक्षर इनमें से कोई नहीं होना चाहिए: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} की लंबाई {1} और {2} अक्षरों के बीच होनी चाहिए" },
            { lang + ErrorCode.MinLength, "{0} की लंबाई कम से कम {1} अक्षर होनी चाहिए" },
            { lang + ErrorCode.MaxLength, "{0} की लंबाई अधिकतम {1} अक्षर होनी चाहिए" },
            { lang + ErrorCode.ExactLength, "{0} की लंबाई ठीक {1} अक्षर होनी चाहिए" },

            { lang + ErrorCode.Bool, "{0} एक बूलियन मान होना चाहिए" },
            { lang + ErrorCode.Int, "{0} एक पूर्णांक होना चाहिए" },
            { lang + ErrorCode.Number, "{0} एक संख्या होनी चाहिए" },
            { lang + ErrorCode.String, "{0} एक स्ट्रिंग होनी चाहिए" },
            { lang + ErrorCode.FormatDate, "{0} एक मान्य दिनांक होनी चाहिए" },

            { lang + ErrorCode.Email, "{0} एक मान्य ई-मेल पता होना चाहिए" },
            { lang + ErrorCode.BankIban, "{0} एक मान्य IBAN होना चाहिए" },
            { lang + ErrorCode.BankCardNumber, "{0} एक मान्य कार्ड नंबर होना चाहिए" },
        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_pt_pt()
    {
        string lang = "pt-pt.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.Null, "{0} deve ser nulo" },
            { lang + ErrorCode.NotNull, "{0} é obrigatório" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} é obrigatório" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} é obrigatório" },

            { lang + ErrorCode.Letters, "{0} deve conter apenas letras" },
            { lang + ErrorCode.Digits, "{0} deve conter apenas algarismos" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} deve conter apenas letras, algarismos ou o carácter de sublinhado" },

            { lang + ErrorCode.StartsWith, "{0} deve começar por: {1}" },
            { lang + ErrorCode.EndsWith, "{0} deve terminar por: {1}" },
            { lang + ErrorCode.Contains, "{0} deve conter: {1}" },
            { lang + ErrorCode.NotContains, "{0} não deve conter: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0} deve ter como primeiro carácter um dos seguintes: {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0} não deve ter como primeiro carácter um dos seguintes: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} deve ter entre {1} e {2} caracteres" },
            { lang + ErrorCode.MinLength, "{0} deve ter pelo menos {1} caracteres" },
            { lang + ErrorCode.MaxLength, "{0} não deve ter mais de {1} caracteres" },
            { lang + ErrorCode.ExactLength, "{0} deve ter exactamente {1} caracteres" },

            { lang + ErrorCode.Bool, "{0} deve ser um valor booleano" },
            { lang + ErrorCode.Int, "{0} deve ser um número inteiro" },
            { lang + ErrorCode.Number, "{0} deve ser um número" },
            { lang + ErrorCode.String, "{0} deve ser uma cadeia de caracteres" },
            { lang + ErrorCode.FormatDate, "{0} deve ser uma data válida" },

            { lang + ErrorCode.Email, "{0} deve ser um endereço de e-mail válido" },
            { lang + ErrorCode.BankIban, "{0} deve ser um IBAN válido" },
            { lang + ErrorCode.BankCardNumber, "{0} deve ser um número de cartão válido" },
        };

        return tableErrorMsg;
    }

    static Dictionary<string, string> Build_pt_br()
    {
        string lang = "pt-br.";
        Dictionary<string, string> tableErrorMsg = new Dictionary<string, string>
        {
            { lang + ErrorCode.Null, "{0} deve ser nulo" },
            { lang + ErrorCode.NotNull, "{0} é obrigatório" },
            { lang + ErrorCode.NotNullOrEmpty, "{0} é obrigatório" },
            { lang + ErrorCode.NotNullOrWhiteSpace, "{0} é obrigatório" },

            { lang + ErrorCode.Letters, "{0} deve conter apenas letras" },
            { lang + ErrorCode.Digits, "{0} deve conter apenas dígitos" },
            { lang + ErrorCode.LettersDigitsUnderscore, "{0} deve conter apenas letras, dígitos ou sublinhado" },

            { lang + ErrorCode.StartsWith, "{0} deve começar com: {1}" },
            { lang + ErrorCode.EndsWith, "{0} deve terminar com: {1}" },
            { lang + ErrorCode.Contains, "{0} deve conter: {1}" },
            { lang + ErrorCode.NotContains, "{0} não deve conter: {1}" },
            { lang + ErrorCode.FirstCharIn, "{0} deve ter como primeiro caractere um dos seguintes: {1}" },
            { lang + ErrorCode.FirstCharNotIn, "{0} não deve ter como primeiro caractere um dos seguintes: {1}" },

            { lang + ErrorCode.BetweenLength, "{0} deve ter entre {1} e {2} caracteres" },
            { lang + ErrorCode.MinLength, "{0} deve ter pelo menos {1} caracteres" },
            { lang + ErrorCode.MaxLength, "{0} não deve ter mais de {1} caracteres" },
            { lang + ErrorCode.ExactLength, "{0} deve ter exatamente {1} caracteres" },

            { lang + ErrorCode.Bool, "{0} deve ser um valor booleano" },
            { lang + ErrorCode.Int, "{0} deve ser um número inteiro" },
            { lang + ErrorCode.Number, "{0} deve ser um número" },
            { lang + ErrorCode.String, "{0} deve ser uma string" },
            { lang + ErrorCode.FormatDate, "{0} deve ser uma data válida" },

            { lang + ErrorCode.Email, "{0} deve ser um endereço de e-mail válido" },
            { lang + ErrorCode.BankIban, "{0} deve ser um IBAN válido" },
            { lang + ErrorCode.BankCardNumber, "{0} deve ser um número de cartão válido" },
        };

        return tableErrorMsg;
    }

}
