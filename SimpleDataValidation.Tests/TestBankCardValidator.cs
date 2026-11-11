using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

/// <summary>
/// 1: Err, null or empty.
/// 2: Only digits allowed.
/// 3: Number length is wrong.
/// 4: The number is invalid.
/// 5: The number doesn't match the bank
/// 
/// https://docs.adyen.com/development-resources/test-cards-and-credentials/test-card-numbers#mastercard
/// https://docs.stripe.com/testing
/// </summary>
[TestClass]
public class TestBankCardValidator
{
    [TestMethod]
    public void CardWrong()
    {
        int res = BankCardValidator.CheckCardNumber(BankCardBank.Visa, "");
        Assert.AreEqual(1, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Visa, "41XSZ 1111 4555 1142");
        Assert.AreEqual(2, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Visa, "4111 1111 4555 1142 4567");
        Assert.AreEqual(3, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Visa, "4111 1111 4555");
        Assert.AreEqual(3, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Visa, "4111 1111 4555 1149");
        Assert.AreEqual(4, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.AmericanExpress, "4111 1111 4555 1142");
        Assert.AreEqual(5, res);
    }

    [TestMethod]
    public void CardVisa()
    {
        int res = BankCardValidator.CheckCardNumber(BankCardBank.Visa, "4111 1111 4555 1142");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Visa, "4111111145551142");
        Assert.AreEqual(0, res);

        //4242 4242 4242 4242, 4000 0566 5566 5556
    }

    [TestMethod]
    public void CardVisaDankord()
    {
        int res = BankCardValidator.CheckCardNumber(BankCardBank.DankortPure, "5019 5555 4444 5555");
        Assert.AreEqual(0, res);

        // eror
        res = BankCardValidator.CheckCardNumber(BankCardBank.Visa, "5019 5555 4444 5555");
        Assert.AreEqual(5, res);

        // Dankord cobranded with Visa, so it's also Visa
        res = BankCardValidator.CheckCardNumber(BankCardBank.Visa, "4571 0000 0000 0001");
        Assert.AreEqual(0, res);

        // Visa/Dankord 
        res = BankCardValidator.CheckCardNumber(BankCardBank.VisaDankort, "4571 0000 0000 0001");
        Assert.AreEqual(0, res);

        // cobranded with Visa, but accepted as Dankord
        res = BankCardValidator.CheckCardNumber(BankCardBank.Dankort, "4571 0000 0000 0001");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void CardVisaMulti()
    {
        int res = BankCardValidator.CheckCardNumber(BankCardBank.Visa | BankCardBank.AmericanExpress, "4111 1111 4555 1142");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.AmericanExpress | BankCardBank.Visa | BankCardBank.DinersClub, "4111 1111 4555 1142");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void CardAmericaExpress()
    {
        int res = BankCardValidator.CheckCardNumber(BankCardBank.AmericanExpress, "3700 0000 0000 002");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.AmericanExpress, "3700 0000 0100 018");
        Assert.AreEqual(0, res);

        // 3782 822463 10005
    }

    [TestMethod]
    public void CardMastercard()
    {
        int res = BankCardValidator.CheckCardNumber(BankCardBank.Mastercard, "2222 4000 7000 0005");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Mastercard, "2223 0000 4841 0010");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Mastercard, "5100 0600 0000 0002");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Mastercard, "5103 2219 1119 9245");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Mastercard, "5130 2900 0000 0009");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Mastercard, "5555 5555 5555 4444");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Mastercard, "5577 0000 5577 0004");
        Assert.AreEqual(0, res);

        // 5555 5555 5555 4444
    }

    [TestMethod]
    public void CardDiscover()
    {
        int res = BankCardValidator.CheckCardNumber(BankCardBank.Discover, "6011 1111 1111 1117");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Discover, "6011 9811 1111 1113");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.Discover, "6011 0009 9013 9424");
        Assert.AreEqual(0, res);
        
        // 19 digits
        res = BankCardValidator.CheckCardNumber(BankCardBank.Discover, "6450 2708 4463 4057 678");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void CardDinersClub()
    {
        int res = BankCardValidator.CheckCardNumber(BankCardBank.DinersClub, "3600 6666 3333 44");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.DinersClub, "3607 0500 0010 20");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.DinersClub, "3622 7206 2716 67");
        Assert.AreEqual(0, res);

        // not HiperCard but DinersClub
        res = BankCardValidator.CheckCardNumber(BankCardBank.DinersClub, "3800 1111 1122 27");
        Assert.AreEqual(0, res);

    }

    [TestMethod]
    public void CardChinaUnionPay()
    {
        int res = BankCardValidator.CheckCardNumber(BankCardBank.ChinaUnionPay, "6247 2049 7121 3457");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.ChinaUnionPay, "6200 0000 0000 0005");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.ChinaUnionPay, "6205 5000 0000 0000 004");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.ChinaUnionPay, "8171 9999 2766 0000");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.ChinaUnionPay, "8171 9999 0000 0000 021");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void CardJCB()
    {
        int res = BankCardValidator.CheckCardNumber(BankCardBank.JCB, "3569 9900 1009 5841");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.JCB, "3566 0020 2036 0505");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.JCB, "3542 9693 1355 5276 538");
        Assert.AreEqual(0, res);
    }

    /// <summary>
    /// Prefix: 
    /// 384100, 384140, 384160   ->  19 digits
    /// 606282 -> 16 or 19 digits
    /// 637095, 637568, 637599, 637600, 637609, 637612   -> 16 digits
    /// </summary>
    [TestMethod]
    public void BankCardNumberHiperCard()
    {
        string errMsg;

        // 637095 : 
        int res = BankCardValidator.CheckCardNumber(BankCardBank.HiperCard, "6370 9511 1122 2231");
        Assert.AreEqual(0, res);

        // 637568 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.HiperCard, "6375 6811 1122 2239");
        Assert.AreEqual(0, res);

        // 637599 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.HiperCard, "6375 9911 1122 2232");
        Assert.AreEqual(0, res);

        // 637600 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.HiperCard, "6376 0011 1122 2239");
        Assert.AreEqual(0, res);

        // 637609 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.HiperCard, "6376 0911 1122 2230");
        Assert.AreEqual(0, res);

        // 637612 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.HiperCard, "6376 1211 1122 2235");
        Assert.AreEqual(0, res);

        // 606282 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.HiperCard, "6062 8211 1122 2239");
        Assert.AreEqual(0, res);

        // 384100 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.HiperCard, "3841 0011 1122 2233 338");
        Assert.AreEqual(0, res);

        // 384140 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.HiperCard, "3841 4011 1122 2233 334");
        Assert.AreEqual(0, res);

        // 384160 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.HiperCard, "3841 6011 1122 2233 332");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void CardRuPay()
    {
        int res;

        // 5085 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "5085 0011 1122 2233");
        Assert.AreEqual(0, res);

        // 5086 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "5086 0011 1122 2232");
        Assert.AreEqual(0, res);

        // 5087 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "5087 0011 1122 2231");
        Assert.AreEqual(0, res);

        // 5088 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "5088 0011 1122 2230");
        Assert.AreEqual(0, res);

        // 5089 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "5089 0011 1122 2239");
        Assert.AreEqual(0, res);

        // Todo:

        // 6068 to 6089
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "6068 0011 1122 2232");
        Assert.AreEqual(0, res);


        // 6072:
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "6072 0011 1122 2236");
        Assert.AreEqual(0, res);

        // 6085:
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "6085 0011 1122 2231");
        Assert.AreEqual(0, res);


        // 6521:
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "6521 0011 1122 2233");
        Assert.AreEqual(0, res);

        // 6522:
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "6522 0011 1122 2232");
        Assert.AreEqual(0, res);

        // 6527 :
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "6527 6589 0000 1005");
        Assert.AreEqual(0, res);

        // 6529:
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "6529 0211 1122 2233");
        Assert.AreEqual(0, res);

        // 8172 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "8172 0011 1122 2231");
        Assert.AreEqual(0, res);

        // 82 : 
        res = BankCardValidator.CheckCardNumber(BankCardBank.RuPay, "8200 1111 2222 3338");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void BankCardJCBRuPay()
    {
        int res;

        // cobrandé: RuPay-JCB  353 et 356 
        res = BankCardValidator.CheckCardNumber(BankCardBank.JCBRuPay, "3539 0400 0000 0000");
        Assert.AreEqual(0, res);

        res = BankCardValidator.CheckCardNumber(BankCardBank.JCBRuPay, "3561 4600 0000 0001");
        Assert.AreEqual(0, res);
    }
}
