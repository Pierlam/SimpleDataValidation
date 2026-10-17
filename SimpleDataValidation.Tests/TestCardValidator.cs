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

        //4242 4242 4242 4242, 4000 0566 5566 5556
    }

    [TestMethod]
    public void CardVisaMultiOk()
    {
        int res = CardValidator.CheckCardNumber(CardBank.Visa | CardBank.AmericanExpress, "4111 1111 4555 1142");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.AmericanExpress | CardBank.Visa | CardBank.DinersClub, "4111 1111 4555 1142");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void CardAmericaExpressOk()
    {
        int res = CardValidator.CheckCardNumber(CardBank.AmericanExpress, "3700 0000 0000 002");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.AmericanExpress, "3700 0000 0100 018");
        Assert.AreEqual(0, res);

        // 3782 822463 10005
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

        // 5555 5555 5555 4444
    }

    [TestMethod]
    public void CardDiscoverOk()
    {
        int res = CardValidator.CheckCardNumber(CardBank.Discover, "6011 1111 1111 1117");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.Discover, "6011 9811 1111 1113");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.Discover, "6011 0009 9013 9424");
        Assert.AreEqual(0, res);
        
        // 19 digits
        res = CardValidator.CheckCardNumber(CardBank.Discover, "6450 2708 4463 4057 678");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void CardDinersClubOk()
    {
        int res = CardValidator.CheckCardNumber(CardBank.DinersClub, "3600 6666 3333 44");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.DinersClub, "3607 0500 0010 20");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.DinersClub, "3622 7206 2716 67");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void CardChinaUnionPayOk()
    {
        int res = CardValidator.CheckCardNumber(CardBank.ChinaUnionPay, "6247 2049 7121 3457");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.ChinaUnionPay, "6200 0000 0000 0005");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.ChinaUnionPay, "6205 5000 0000 0000 004");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.ChinaUnionPay, "8171 9999 2766 0000");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.ChinaUnionPay, "8171 9999 0000 0000 021");
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void CardJCBOk()
    {
        int res = CardValidator.CheckCardNumber(CardBank.JCB, "3569 9900 1009 5841");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.JCB, "3566 0020 2036 0505");
        Assert.AreEqual(0, res);

        res = CardValidator.CheckCardNumber(CardBank.JCB, "3542 9693 1355 5276 538");
        Assert.AreEqual(0, res);

    }

}
