# What is SimpleDataValidation?

SimpleDataValidation is an open-source .NET library designed to validate data in a simple and intuitive way.

It provides more than 30 built-in validation functions to check data types, lengths, formats, and much more. These include NotNull, Length, StartsWith, Email, IBAN, and CreditCardNumber.

The library is written in C# and developed using Visual Studio 2026. It targets both .NET 8 and .NET 10.

The codebase is covered by 78 unit tests to ensure reliability and prevent regressions as new features and improvements are introduced.

# A quick example

Usage is very simple: you just need to call one of the static validation methods of the V class, passing the name of the data and its value.
If validation fails, the method returns an error message; otherwise, it returns an empty string.

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

The following examples show some common scenarios:

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

You can also chain validation methods to perform multiple checks on the same data value.

```
// Validate a string value to check if it's not null and has a minimum length of 8 characters
errMsg = V.Define("Name", "John").AddNotNull().AddMinLength(8).Validate();     
  -> ok, errMsg is empty

errMsg = V.Define("Name", "john").AddNotNull().AddStartsWith("jo").Validate();
  -> ok, errMsg is empty
```

Start by calling the Define static method of the V class, passing the name of the data and its value.
Then, chain validation methods to check the data value against multiple validation rules.
Finally, call the Validate method to execute the validation and return any error messages.

All validation rules will be executed, and any resulting error messages will be concatenated.

# Features

The library provides a wide range of validation methods to check data types, lengths, formats, and much more.


## Available validation methods

List of Available Direct Validation Methods:

```
True                       Check that the bool value is true.
False                      Check that the bool value is false.
Null                       Check that the object value is null.
NotNull                    Check that the object value is not null.
NotNullOrEmpty             Check that the string value is not null or empty.
NotNullOrWhiteSpace        Check that the string value is not null or whitespace.
Text                       Check that the string contains a text, same as NotNullOrWhiteSpace.

Letters                    Check that the string contains only letter.
Digits                     Check that the string contains only digit.
LettersDigitsUnderscore    Check that the string contains only letter, digit or underscore.

StartsWith                 Check that the string starts with the provided string, case sensitive. 
StartsWithCaseInsensitive  Check that the string starts with the provided string, case insensitive.
EndsWith                   Check that the string ends with the provided string, case sensitive. 
EndsWithCaseInsensitive    Check that the string ends with the provided string, case insensitive.
Contains                   Check that the string contains the provided string, case sensitive. 
ContainsCaseInsensitive    Check that the string contains the provided string, case insensitive. 
NotContains                Check that the string does not contain the provided string, case sensitive.
NotContainsCaseInsensitive Check that the string does not contain the provided string, case insensitive.

FirstCharIn                Check that the first char of the string is one of provided chars.
FirstCharNotIn             Check that the first char of the string is not one of provided chars.

MinLength                  Check that the string value has a minimum length.
MaxLength                  Check that the string value has a maximum length.
BetweenLength              Check that the length of string is between a min and a max value.
ExactLength                Check that the string value has an exact length.

EmailFormat                Check that the email format is valid: a@b.c
Email                      Check that the string value is a valid email address.
EmailStrict                Check that the email format is valid , more strict but more time consuming.
 
Bool                       Check that the object value is a boolean.
Int                        Check that the object value is an integer.
Number                     Check that the object value is a number: integer, double, float or BigInteger.
String                     Check that the object value is a string.

FormatDate                 Check that the string match the provided (one or more) date format.

BankIban                   Check that the string value is a valid bank IBAN number.
BankCardNumber             Check that the string is a valid bank card number.
```


List of available Chained validation Methods:

```
AddTrue
AddFalse
AddNull
AddNotNull
AddNotNullOrEmpty
AddNotNullOrWhiteSpace
AddText

AddStartsWith
AddStartsWithCaseInsensitive
AddEndsWith
AddEndsWithCaseInsensitive
AddContains                    
AddContainsCaseInsensitive     
AddNotContains                
AddNotContainsCaseInsensitive 

AddFirstCharIn
AddFirstCharNotIn

AddMinLength
AddMaxLength
AddBetweenLength
AddExactLength
AddBankCardNumber
```

## Error Messages

Error messages are available in the following languages: English (US), English (UK), French, Spanish, German, Italian, Danish, Portuguese, Brazilian Portuguese, Chinese, and Hindi.

You can also customize error messages for each validation method by passing your own message as a parameter.

The default language for error messages is English (en-en).
```
string nameValue = null;
errMsg = V.NotNull("Name",nameValue, "The name is mandatory!");
Console.WriteLine($"-> errorMessage: {errMsg}");

// will display the following error message:
-> errorMessage: The name is mandatory!
```

You can change the language used for error messages by calling the SetLanguage method of the V class and passing the desired language code as a parameter.

```
// list of available languages:
"en-en"  English    -The default language-
"en-us"  American 
"fr-fr"  French
"es-es"  Spanish
"de-de"  German
"it-it"  Italian
"da-dk"  Danish
"pt-pt"  Portuguese
"pt-br"  Brazilian Portuguese
"zh-cn"  Chinese
"hi-in"  Hindi 

// example: Set the language for error messages to be in French
V.SetLanguage("fr-fr");
```

You can also choose whether error messages should end with a period by calling the SetEndMessageDot method of the V class.

``` 
// example of an error message, by default:
The name is required
```

```
// put a . char at the end of each error message
V.SetMessageEndDot();
The name is required.
```

Or put something else:

```
// put a ! char at the end of each error message
V.SetMessageEnd("!");
The name is required!
```

You can customize the separator between error messages when using chained validation.
By default, a hyphen (-) is used to separate messages.

```
// now put a | between messages if many errors occurs
V.SetMessageSeparator(" | ");

example:
The name is required | The length of name is too short | ....
```

# Some samples

## Check string content

Do some checks on a string value.

```
// Check that the value starts with the provided string.
errMsg = V.StartsWith("field", "hello", "hgj");  -> ok, errMsg will be empty

// Check that the  first char of the value 'hello' is one of 'xyz'.
errMsg = V.FirstCharIn("field", "hello", "xyz");  -> error! 
```

## Check date 

Check if a date match the provided format:

```
// one format to match: will be ok
errMsg = V.FormatDate("name", "10/12/2026", "dd/MM/yyyy");
 -> ok
 
// the date can match one format among the both provided
errMsg = V.FormatDate("name", "2026-10-25", new[] { "dd/MM/yyyy", "yyyy-MM-dd" });
 -> ok

// the date can match one format among the both provided, if an error occurs, return the custom message
errMsg = V.FormatDate("name", "10/12/202", new[] { "dd/MM/yyyy", "yyyy-MM-dd" }, "Custom error message");
 -> The date is wrong: errMsg will be: "Custom error message"

// a more complex case: match date and time
errMsg = V.FormatDate("name", "2026-12-20 10:30:00,123", "yyyy-MM-dd HH:mm:ss,fff");
 -> ok
```

## Check bank Iban and card Number

Validate an IBAN, with or without spaces.


```
// with whitespaces:
string iban = "GB82 WEST 1234 5698 7654 32";
errMsg = V.BankIban("field", iban);  -> ok

iban = "GB82WEST12345698765432";
errMsg = V.BankIban("field", iban);  -> ok
```

Validate a bank card number:

Ensure that it contains only digits and spaces.
Check its length and verify its checksum using the Luhn algorithm.

```
// the card number bank should be valid over all banks, with whitespaces:
errMsg = V.BankCardNumber("field", "4111 1111 4555 1142");

// the card number bank should be Visa, with whitespaces:
errMsg = V.BankCardNumber("field", "4111 1111 4555 1142", CardBank.Visa);

errMsg = V.BankCardNumber("field", "4111111145551142", CardBank.Visa);

// the card number bank should be Visa or Mastercard
errMsg = V.BankCardNumber("field", "4111 1111 4555 1142", CardBank.Visa | CardBank.Mastercard);

// the card number bank should be Visa or Mastercard or American Express
errMsg = V.BankCardNumber("field", "4111 1111 4555 1142", CardBank.Visa | CardBank.Mastercard | CardBank.AmericanExpress);
```

Special cases for Dankort cards co-branded with Visa: all the following cases are accepted:

```
// Pure Dankord
errMsg = V.BankCardNumber("field", "5019 5555 4444 5555", BankCardBank.DankortPure);

// Dankord cobranded with Visa
errMsg = V.BankCardNumber("field", "4571 0000 0000 0001", BankCardBank.Visa);
errMsg = V.BankCardNumber("field", "4571 0000 0000 0001", BankCardBank.VisaDankort);
errMsg = V.BankCardNumber("field", "4571 0000 0000 0001", BankCardBank.Dankort);
```

Bank validation implemented: Visa, Mastercard, American Express, Dankort, Dinners Club, Discover, HiperCard, JCB, RuPay and China UnionPay.
 
## Apply several validation on a data

You can perform multiple checks more fluently by chaining validation methods to validate the same data value against several rules.

By default, all validation rules are executed, and any resulting error messages are concatenated and separated by -. You can customize the separator by calling the SetMessageSeparator method.

Alternatively, you can stop the validation process after the first error by using the ValidOptions.StopOnFirstError option.


```
errMsg = V.Define("Card Number", "4111 1111 4555 1142").AddNotNull().AddCardNumber(CardBank.Visa).Validate();
 -> ok

// continue even if error occurs, so the max length validation will be executed and the error message will be concatenated
errMsg = V.Define("field", "johnjohn").AddMinLength(10).AddMaxLength(5).Validate();
 -> errMsg contains all error messages: "field must be at least 10 characters long - field must be no more than 5 characters long"

// will stop on the first error, so the max length validation will not be executed
errMsg = V.Define("field", "johnjohn").AddMinLength(10).AddMaxLength(4).Validate(ValidOptions.StopOnFirstError);
  -> errMsg contains only the first error: "field must be at least 10 characters long"
```

## Use an instance in place of V

Another option is to create an instance of the VInst class instead of using the static V class.

This is a better approach in multithreaded environments, as each instance maintains its own validation settings.
You can create as many VInst instances as you need.

All the methods available in the static V class are also available in the VInst class.


```
// use the default language (en-en)
VInst vInst = V.CreateInst();
errMsg = vInst.NotNull("field", null);
 -> "field is required"

// use a specific language, example here: French
VInst vInst = V.CreateInst("fr-fr");
errMsg = vInst.NotNull("field", null);
 -> "field est requis"
 
// the default validator is still available in the defined language
errMsg = V.NotNull("field", null);
 -> "field is required"
```



# Source code, documentation and nuget

SimpleDataValidation library is packaged as a nuget ready to use:

https://www.nuget.org/packages/SimpleDataValidation

Github source repository:

https://github.com/Pierlam/SimpleDataValidation/


## Contact 

Have any comments or questions? Would you like to request a new feature?

The error messages were generated using AI, so some of them may be incorrect or unclear. If you notice any issues, please let me know so I can fix them.

Feel free to send me an email at:

pierlam-project@outlook.com


## Resources 


A dotnet well-known data validation library:
https://docs.fluentvalidation.net/en/latest/index.html

Iban validation:
https://medium.com/@matlabb/iban-structure-and-mod-97-validation-algorithm-719e3d4db5f2
