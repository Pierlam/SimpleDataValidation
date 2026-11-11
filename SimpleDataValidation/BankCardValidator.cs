using SimpleDataValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleDataValidation;


/// <summary>
/// To check debit, prepaid card numbers.
/// prefixes are used to find the bank of the card number
/// </summary>
public class BankCardValidator
{
    static PrefixToBankMapper prefixToBankMapper = new PrefixToBankMapper();

    static BankCardValidator()
    {
        //--HiperCard: 
        prefixToBankMapper.AddStart("384100", BankCardBank.HiperCard, 19, true);
        prefixToBankMapper.AddStart("384140", BankCardBank.HiperCard, 19, true);
        prefixToBankMapper.AddStart("384160", BankCardBank.HiperCard, 19, true);

        prefixToBankMapper.AddStart("606282", BankCardBank.HiperCard, 16, true);
        prefixToBankMapper.AddStart("637095", BankCardBank.HiperCard, 16, true);
        prefixToBankMapper.AddStart("637568", BankCardBank.HiperCard, 16, true);
        prefixToBankMapper.AddStart("637599", BankCardBank.HiperCard, 16, true);
        prefixToBankMapper.AddStart("637600", BankCardBank.HiperCard, 16, true);
        prefixToBankMapper.AddStart("637609", BankCardBank.HiperCard, 16, true);
        prefixToBankMapper.AddStart("637612", BankCardBank.HiperCard, 16, true);

        //--RuPay:  60,82, 353, 356 are below
        prefixToBankMapper.AddStart("345678", BankCardBank.RuPay, 16, true);        
        prefixToBankMapper.AddStart("5028", BankCardBank.RuPay, 16, true);        
        prefixToBankMapper.AddStart("5029", BankCardBank.RuPay, 16, true);        
        prefixToBankMapper.AddStart("5040", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("5054", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("5085", BankCardBank.RuPay, 16, true);        
        prefixToBankMapper.AddStart("5086", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("5087", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("5088", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("5089", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("6068", "6089", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("6521", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("6522", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("6527", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("6529", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("8172", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("8173", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("818", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("819", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("820", BankCardBank.RuPay, 16, true);

        //--Visa/Dankord, Dankord
        prefixToBankMapper.AddStart("4571", BankCardBank.VisaDankort, 16, true);
        prefixToBankMapper.AddStart("5019", BankCardBank.DankortPure, 16, true);

        // cobranding: RuPay-JCB  353 et 356 (to place before JCB)
        prefixToBankMapper.AddStart("353", BankCardBank.JCBRuPay, 16, true);
        prefixToBankMapper.AddStart("356", BankCardBank.JCBRuPay, 16, true);

        //--JCB: begins with 35, specifically from 3528 through 3589
        prefixToBankMapper.AddStart("3528", "3589", BankCardBank.JCB, 16, 19, true);


        //--Dinners club, begins with 300 to 305, or 36 or 38. length: 14 
        prefixToBankMapper.AddStart("300", "305", BankCardBank.DinersClub, 14, true);
        prefixToBankMapper.AddStart("36", BankCardBank.DinersClub, 14, true);
        prefixToBankMapper.AddStart("38", BankCardBank.DinersClub, 14, true);

        //--Discover: Begins with 6011, 644 to 649, or 65 (but 6521 and 6522 are RuPay). length: 16 digits
        prefixToBankMapper.AddStart("6011", BankCardBank.Discover, 16, true);
        prefixToBankMapper.AddStart("65", BankCardBank.Discover, 16, true);
        prefixToBankMapper.AddStart("644", "649", BankCardBank.Discover, 19, true);

        //--Mastercard: Start with 51 to 55, 2221–2720
        prefixToBankMapper.AddStart("51", "55", BankCardBank.Mastercard, 16, true);
        prefixToBankMapper.AddStart("2221", "2720", BankCardBank.Mastercard, 16, true);

        //--American Express: Start with 34 or 37. length: 15
        prefixToBankMapper.AddStart("34", BankCardBank.AmericanExpress, 15, true);
        prefixToBankMapper.AddStart("37", BankCardBank.AmericanExpress, 15, true);

        // ChinaUnionPay: begins with 62 or 81, length: 16 - 19
        prefixToBankMapper.AddStart("62", BankCardBank.ChinaUnionPay, 16,19, true);
        prefixToBankMapper.AddStart("81", BankCardBank.ChinaUnionPay, 16,19, true);

        //--RuPay
        prefixToBankMapper.AddStart("60", BankCardBank.RuPay, 16, true);
        prefixToBankMapper.AddStart("82", BankCardBank.RuPay, 16, true);

        //--Visa
        prefixToBankMapper.AddStart("4", BankCardBank.Visa, 16, true);
    }


    /// <summary>
    /// Check that the card number match the bank and also that the number is correct.
    /// return an int value:
    /// 0: ok, the card number is valid and match on of banks.
    /// 1: Err, null or empty.
    /// 2: Only digits allowed.
    /// 3: Number length is wrong.
    /// 4: The number is invalid.
    /// 5: The number doesn't match the bank.
    /// </summary>
    /// <param name="dataName"></param>
    /// <param name="CardBanks"></param>
    /// <param name="cardNumber"></param>
    /// <returns></returns>
    public static int CheckCardNumber(BankCardBank cardBanks, string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber)) return 1;

        // every char should be a digit, clean it, remove space chars
        if(!CheckAndCleanCardNumber(cardNumber, out string card))
                return 2;

        // check length, 14,15,16 or 19
        if ((card.Length < 14 || card.Length > 16) && card.Length != 19) return 3;

        string cardStr = card.ToString();

        //--get the bank of the card number
        BankCardBank cardBankRes = new BankCardBank();

        //--find the bank
        PrefixToBankItem item = prefixToBankMapper.GetItem(cardStr);
        if (item == null)
            // 5: Unable to get the bank from the number
            return 5;

        if (!item.LengthCheckResult)
            // 3: wrong length
            return 3;

        if(item.AppyLuhnCheck)
            if (!LuhnValidation(cardStr)) return 4;

        // final check: length and Luhn calculation
        return FinalCheckLengthAndLuhnCalc(cardStr, cardBanks, item.Bank, item.AppyLuhnCheck);
    }

    /// <summary>
    /// Final checks: length and Luhn calculation
    /// </summary>
    /// <param name="cardStr"></param>
    /// <param name="cardBanks"></param>
    /// <param name="cardBankToCheck"></param>
    /// <returns></returns>
    static int FinalCheckLengthAndLuhnCalc(string cardStr, BankCardBank cardBanks, BankCardBank cardBankToCheck, bool checkLuhn)
    {
        //--is it a pure Dankord card?
        if (CheckCardBank(BankCardBank.DankortPure, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        //--is it a Visa/Dankord card?
        if (cardBanks.HasFlag(BankCardBank.Dankort) && cardBankToCheck.HasFlag(BankCardBank.VisaDankort))
        {
            return 0;
        }

        //--is it a Visa card?
        if (CheckCardBank(BankCardBank.Visa, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        //--is it a Visa/Dankord card?
        if(cardBanks.HasFlag(BankCardBank.Visa) && cardBankToCheck.HasFlag(BankCardBank.VisaDankort))
        {
            return 0;
        }

        if (CheckCardBank(BankCardBank.VisaDankort, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        //--is it an American Express?
        if (CheckCardBank(BankCardBank.AmericanExpress, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        //--is it a Mastercard?
        if (CheckCardBank(BankCardBank.Mastercard, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        //--is it a Discover?
        if (CheckCardBank(BankCardBank.Discover, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        //--is it a DinnersClub?
        if (CheckCardBank(BankCardBank.DinersClub, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        //--is it a China UnionPay?
        if (CheckCardBank(BankCardBank.ChinaUnionPay, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        //--is it a JCB-RUPay?
        if (CheckCardBank(BankCardBank.JCBRuPay, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        //--is it a JCB?
        if (CheckCardBank(BankCardBank.JCB, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        if (cardBanks.HasFlag(BankCardBank.JCB) && cardBankToCheck.HasFlag(BankCardBank.JCBRuPay))
        {
            return 0;
        }

        //--is it a RuPay?
        if (CheckCardBank(BankCardBank.RuPay, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        if (cardBanks.HasFlag(BankCardBank.RuPay) && cardBankToCheck.HasFlag(BankCardBank.JCBRuPay))
        {
            return 0;
        }

        //--is it an HiperCard?
        if (CheckCardBank(BankCardBank.HiperCard, cardBanks, cardBankToCheck))
        {
            return 0;
        }

        // 5: The number doesn't match the bank
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

    public static bool CheckCardBank(BankCardBank cardBankExpected, BankCardBank cardBankA, BankCardBank cardBankB)
    {
        return cardBankA.HasFlag(cardBankExpected) && cardBankB.HasFlag(cardBankExpected);
    }

}
