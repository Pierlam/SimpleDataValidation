## 0.2.0 Release (2026-XX-XX)

-New validation available:
Text				     Check that the string contains a text, same as NotNullOrWhiteSpace.
Letters  				 Check that the string contains only letter.
Digits  				 Check that the string contains only digit.
LettersDigitsUnderscore  Check that the string contains only letter, digit or underscore.
StartsWith				Check that the string starts with the provided string.
FirstCharIn				Check that the first char of the string is one of provided chars.
FirstCharNotIn			Check that the first char of the string is not one of provided chars.
Number					 Check that the object value is a number: integer, dou ble float or BigInteger.
String 					 Check that the object value is a string.
CardNumber				 Check that the string is a valid card number.

-New chain validation available:
AddNotNullOrEmpty
AddNotNullOrWhiteSpace
AddText
AddCardNumber

-Other functions:
V.Error(errMsg)			return true if the errMsg contains a text.
V.Ok(errMsg)			return true if the errMsg is empty, it's not an error.

-37 unit tests, all are green.

## 0.1.0 Release (2026-10-10)

First version of the library.
Default language for error message is English.
Each message has no end char.

-List of available direct validation methods:
NotNull              Check that the object value is not null.
NotNullOrEmpty       Check that the string value is not empty.
NotNullOrWhiteSpace Check that the string value is not whitespace.
MinLength            Check that the string value has a minimum length.
MaxLength            Check that the string value has a maximum length.
ExactLength         Check that the string value has an exact length.
Email                Check that the string value is a valid email address.
Int                  Check that the object value is an integer.
Iban                 Check that the string value is a valid IBAN number.

-List of available chained validation methods:
AddNotNull  
AddMinLength
AddMaxLength

-Set the language for error messages to French
V.SetLanguage("fr-fr")

You can add a dot to each error message:
V.SetEndMessageDot()

-13 unit tests, all are green.


