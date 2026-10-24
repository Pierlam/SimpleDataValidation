# What is SimpleDataValidation?

SimpleDataValidation is an open-source .NET library for validating data in a simple and intuitive way.

It's written in C#/NET8 with VS2026. The code is covered by 40 unit tests to ensure the non-regression of incoming evolutions.


# A quick example

The usage is very simple, you just need to call one of validation static method of the V class, passing the name of the data and its value.
Then if the validation failed, the function returns an error message or an empty string if validation finished successfully.

```
Syntax:
string errMsg = V.Function(DataName, Value);

If the validation fails  -> The error message is returned in the errMsg variable. 
If the validation passes -> An empty string is returned.
```

Check easily if an error occurs:

```
Syntax:
string errMsg = V.Function(DataName, Value);

// if an error occurs, there is a message
if(V.Error(errMsg)) DoSomethingError();

// no error, no message
if(V.Ok(errMsg)) DoSomethingOk(); 
```

The following example shows some usual cases:

```
using SimpleDataValidation;

//--Validate that the string value contains a text, it is not null, not empty and without any whitespace.
errMsg = V.Text("Name", "John");

if(V.Error(errMsg))
	Console.WriteLine($"-> errorMessage: {errMsg}");   <- Not diplayed

if(V.Ok(errMsg))
	Console.WriteLine($"The Name value is correct!");  <- Displayed

//--Validate that the value has 8 chars length minimum
errMsg = V.MinLength("Name", "John", 8);

if(V.Error(errMsg))
	Console.WriteLine($"-> errorMessage: {errMsg}");   <- Displayed


> Output:
The Name value is correct!
-> errorMessage: Name must be at least 8 characters long
```

# Another way to validate data

You can also do several checks in a more fluent way, by chaining the validation methods to validate a data value many times.

```
// Validate a string value to check if it's not null and has a minimum length of 8 characters
errMsg = V.Define("Name", "John").AddNotNull().AddMinLength(8).Validate();

errMsg = V.Define("Name", "john").AddNotNull().AddStartsWith("jo").Validate();

errMsg = V.Define("Card Number", "4111 1111 4555 1142").AddNotNull().AddCardNumber(CardBank.Visa).Validate();

```

Start by calling the validation static method Define of the V class, passing the name of the data and its value. 
Then, you can chain the validation methods to validate the data value many times. 
Finally, call the Validate method to perform the validation and return the error message if any.

All validation rules will be executed. Error messages will be concatened.

# Features

There are many available features to validate data, by type, by length, and by format.

## Available validation methods

```
// List of available direct validation methods:
NotNull                  Check that the object value is not null.
NotNullOrEmpty           Check that the string value is not null or empty.
NotNullOrWhiteSpace      Check that the string value is not null or whitespace.
Text                     Check that the string contains a text, same as NotNullOrWhiteSpace.

Letters                  Check that the string contains only letter.
Digits                   Check that the string contains only digit.
LettersDigitsUnderscore  Check that the string contains only letter, digit or underscore.

StartsWith               Check that the string starts with the provided string.
FirstCharIn              Check that the first char of the string is one of provided chars.
FirstCharNotIn           Check that the first char of the string is not one of provided chars.

BetweenLength            Check that the length of string is between a min and a max value.
MinLength                Check that the string value has a minimum length.
MaxLength                Check that the string value has a maximum length.
ExactLength              Check that the string value has an exact length.

EmailFormat              Check that the email format is valid: a@b.c
Email                    Check that the string value is a valid email address.
EmailStrict              Check that the email format is valid , more strict but more time consuming.

Int                      Check that the object value is an integer.
Number                   Check that the object value is a number: integer, double float or BigInteger.
String                   Check that the object value is a string.

Iban                     Check that the string value is a valid IBAN number.
CardNumber               Check that the string is a valid card number.


// List of available chained validation methods:
AddNotNull
AddNotNullOrEmpty
AddNotNullOrWhiteSpace
AddText
AddStartsWith
AddFirstCharIn
AddFirstCharNotIn
AddMinLength
AddMaxLength
AddCardNumber
```

## Error Messages

English, French Spanish, German and Italian languages are supported for error messages, other languages will be added in the future.

You can also set your own error messages for each validation method, by passing the error message as a parameter to the validation method.

```
string nameValue = null;
errMsg = V.NotNull("Name",nameValue, "The name is mandatory!");
Console.WriteLine($"-> errorMessage: {errMsg}");

// will display the following error message:
-> errorMessage: The name is mandatory!
```

The default language for error messages is English, but you can change it to another one by calling the SetLanguage method of the V class, passing the language code as a parameter.

```
// Set the language for error messages to French
V.SetLanguage("fr-fr");

// list of available languages:
"en-en"  English   default
"es-es"  Spanish
"de-de"  German
"it-it"  Italian
```

You can also set the end of the error message with a dot or not, by calling the SetEndMessageDot method of the V class, passing a boolean value as a parameter.

Below are results of the error message: The name is required.


``` 
// by default:
The name is required
```

```
// put a . char at the end of the error message:
V.SetEndMessageDot();
The name is required.
```

Or put something else:

```
// put a ! char at the end of the error message:
V.SetEndMessage("!");
The name is required!
```

# Some samples

## Check string content

Do some checks on a string value.


```
// Check that the value starts with the provided string.
errMsg = V.StartsWith("field", "hello", "hgj");  -> ok, errMsg will be empty

// Check that the value first char is one of 'xyz'.
errMsg = V.FirstCharIn("field", "hello", "xyz");  -> error! 
```

## Check Iban and card Number

Check if an Iban number is valid:
With or without space chars.

```
// with whitespaces:
string iban = "GB82 WEST 1234 5698 7654 32";
errMsg = V.Iban("field", iban);  -> ok

iban = "GB82WEST12345698765432";
errMsg = V.Iban("field", iban);  -> ok
```

Check if a card number is valid:

Should contains only digits and char space.
Verify the length and the check sum, apply the Luhn algo.

```
// the card number bank should be Visa, with whitespaces:
errMsg = V.CardNumber("field", "4111 1111 4555 1142", CardBank.Visa);

errMsg = V.CardNumber("field", "4111111145551142", CardBank.Visa);

// the card number bank should be Visa or Mastercard
errMsg = V.CardNumber("field", "4111 1111 4555 1142", CardBank.Visa | CardBank.Mastercard);

// the card number bank should be Visa or Mastercard or American Express
errMsg = V.CardNumber("field", "4111 1111 4555 1142", CardBank.Visa | CardBank.Mastercard | CardBank.AmericanExpress);
```

Bank validation implemented: Visa, Mastercard, American Express, Dinners Club, Discover, JCB and China UnionPay.
 

# Source code, documentation and nuget

SimpleDataValidation library is packaged as a nuget ready to use:

https://www.nuget.org/packages/SimpleDataValidation

Github source repository:

https://github.com/Pierlam/SimpleDataValidation/


## Contact 

Have a comment to do? A question to ask? Want to request a new feature?

Don't hesitate to send me an email: 

pierlam-project@outlook.com


## Resources 


A dotnet well-known data validation library:
https://docs.fluentvalidation.net/en/latest/index.html

Iban validation:
https://medium.com/@matlabb/iban-structure-and-mod-97-validation-algorithm-719e3d4db5f2
