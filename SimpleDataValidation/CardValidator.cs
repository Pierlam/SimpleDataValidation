using SimpleDataValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;


/// <summary>
/// To check debit, prepaid card numbers.
/// </summary>
public class CardValidator
{
    /// <summary>
    /// Check that the card number match the bank and also that the number is correct.
    /// return an int value:
    /// 0: ok, the card number is valid and match on of banks.
    /// 1: Err, null or empty.
    /// 2: Only digits allowed.
    /// 3: Number length is wrong.
    /// 4: The number is invalid.
    /// 5: The number doesn't match the bank
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="CardBanks"></param>
    /// <param name="cardNumber"></param>
    /// <returns></returns>
    public static int CheckCardNumber(CardBank cardBanks, string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber)) return 1;

        // every char should be a digit, clean it, remove space chars
        if(!CheckAndCleanCardNumber(cardNumber, out string card))
                return 2;

        // check length, 14,15,16 or 19
        if ((card.Length < 14 || card.Length > 16) && card.Length != 19) return 3;

        string cardStr = card.ToString();

        //--get the bank of the card number
        CardBank cardBankRes = new CardBank();

        //--find the bank
        if(!FindBank(cardStr, out cardBankRes))
            // 5: Unable to get the bank from the number
            return 5;

        // final check: length and Luhn calculation
        return FinalCheckLengthAndLuhnCalc(cardStr, cardBanks, cardBankRes);
    }

    /// <summary>
    /// Find the bank based on first chars.
    /// </summary>
    /// <param name="cardStr"></param>
    /// <param name="cardBankRes"></param>
    /// <returns></returns>
    static bool FindBank(string cardStr, out CardBank cardBankRes)
    {
        //--visa
        if (cardStr.StartsWith("4"))
        {
            cardBankRes = CardBank.Visa;
            return true;
        }

        //--American Express
        if (cardStr.StartsWith("34") || cardStr.StartsWith("37"))
        {
            cardBankRes = CardBank.AmericanExpress;
            return true;
        }

        //--Mastercard: Start with 51 to 55.
        if (cardStr.StartsWith("51") || cardStr.StartsWith("52") || cardStr.StartsWith("53") || cardStr.StartsWith("54") || cardStr.StartsWith("55"))
        {
            cardBankRes = CardBank.Mastercard;
            return true;
        }

        //--Mastercard BIN2, Start with 2.  2221 à 2720
        // todo:

        //--other banks: Discover, Dinner Clubs, ...

        cardBankRes = new CardBank();
        return false;

    }


    // final check: length and Luhn calculation
    static int FinalCheckLengthAndLuhnCalc(string cardStr, CardBank cardBanks, CardBank cardBankRes)
    {
        //--is it a Visa card?
        if (CheckCardBank(CardBank.Visa, cardBanks, cardBankRes))
        {
            if (cardStr.Length != 16) return 3;
            if (!LuhnValidation(cardStr)) return 4;
            // card number is good
            return 0;
        }

        //--is it an American Express?
        if (CheckCardBank(CardBank.AmericanExpress, cardBanks, cardBankRes))
        {
            if (cardStr.Length != 15) return 3;
            if (!LuhnValidation(cardStr)) return 4;
            // card number is good
            return 0;
        }

        //--is it a Mastercard?
        if (CheckCardBank(CardBank.Mastercard, cardBanks, cardBankRes))
        {
            if (cardStr.Length != 16) return 3;
            if (!LuhnValidation(cardStr)) return 4;
            // card number is good
            return 0;
        }

        // 5: The number dones't match the bank
        return 5;
    }

    /// <summary>
    /// Every char should be a digit, remove space char.
    /// </summary>
    /// <param name="cardNumber"></param>
    /// <param name="cardCleaned"></param>
    /// <returns></returns>
    static bool CheckAndCleanCardNumber(string cardNumber, out string cardCleaned)
     {
        cardCleaned = string.Empty;

        StringBuilder card = new StringBuilder();
        for (int i = 0; i < cardNumber.Length; i++)
        {
            char c = cardNumber[i];

            // remove space
            if (c == ' ') continue;

            // the char should be a digit
            if (!char.IsDigit(c)) return false;
            card.Append(c);
        }

        cardCleaned = card.ToString();
        return true;
    }

    /// <summary>
    ///  Luhn Algorithm
    /// https://medium.com/@michael.harges/implementing-the-luhn-algorithm-in-c-9232c414da3a
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool LuhnValidation(string str)
    {
        if (string.IsNullOrEmpty(str) || str.Length < 2) return false;

        Int32[] doubledValues = new Int32[] { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };

        var sum = 0;
        var shouldApplyDouble = true;
        for (var index = str.Length - 2; index >= 0; index--)
        {
            var currentDigit = str[index] - '0';
            if (currentDigit < 0 || currentDigit > 9)
            {
                return false;
            }
            sum += shouldApplyDouble ? doubledValues[currentDigit] : currentDigit;
            shouldApplyDouble = !shouldApplyDouble;
        }
        var checkDigit = (10 - (sum % 10)) % 10;

        return str[^1] - '0' == checkDigit;
    }

    public static bool CheckCardBank(CardBank cardBankExpected, CardBank cardBankA, CardBank cardBankB)
    {
        return cardBankA.HasFlag(cardBankExpected) && cardBankB.HasFlag(cardBankExpected);
    }

}
