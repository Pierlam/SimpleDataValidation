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
/// </summary>
[TestClass]
public class TestCardValidator
{
    [TestMethod]
    public void CardWrong()
    {
        int res = CardValidator.CheckCardNumber(CardBank.Visa, "");
        Assert.AreEqual(1, res);

        res = CardValidator.CheckCardNumber(CardBank.Visa, "41XSZ 1111 4555 1142");
        Assert.AreEqual(2, res);

        res = CardValidator.CheckCardNumber(CardBank.Visa, "4111 1111 4555 1142 4567");
        Assert.AreEqual(3, res);

        res = CardValidator.CheckCardNumber(CardBank.Visa, "4111 1111 4555");
        Assert.AreEqual(3, res);

        res = CardValidator.CheckCardNumber(CardBank.Visa, "4111 1111 4555 1149");
        Assert.AreEqual(4, res);

        res = CardValidator.CheckCardNumber(CardBank.AmericanExpress, "4111 1111 4555 1142");
        Assert.AreEqual(5, res);
    }

    [TestMethod]
    public void CardVisaOk()
    {
        int res = CardValidator.CheckCardNumber(CardBank.Visa, "4111 1111 4555 1142");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.Visa, "4111111145551142");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void CardAmericaExpressOk()
    {
        int res = CardValidator.CheckCardNumber(CardBank.AmericanExpress, "3700 0000 0000 002");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.AmericanExpress, "3700 0000 0100 018");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void CardMastercardOk()
    {
        int res = CardValidator.CheckCardNumber(CardBank.Mastercard, "2222 4000 7000 0005");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.Mastercard, "2223 0000 4841 0010");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.Mastercard, "5100 0600 0000 0002");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.Mastercard, "5103 2219 1119 9245");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.Mastercard, "5130 2900 0000 0009");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.Mastercard, "5555 5555 5555 4444");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.Mastercard, "5577 0000 5577 0004");
        Assert.AreEqual(0, res);
    }
}
