using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_BankCardNumber
{
    [TestMethod]
    public void BankCarNumber()
    {
        string errMsg;
        errMsg = V.BankCardNumber("field", "4111 1111 4555 1142", BankCardBank.Visa);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.BankCardNumber("field", "4111 1111 4555 1142", BankCardBank.Visa | BankCardBank.Mastercard);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.BankCardNumber("field", null, BankCardBank.Visa);
        Assert.AreEqual("field must be a valid Card Number", errMsg);

        errMsg = V.BankCardNumber("field", null, BankCardBank.Visa, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    /// <summary>
    /// Dankort: Danemark
    /// Pure Dankort: Typically starts with the prefix 5019
    /// Visa/Dankort: Co-branded cards typically start with the Visa prefix 4571
    /// </summary>
    [TestMethod]
    public void BankCardNumberDankordAndVisa()
    {
        string errMsg;

        // only Dankord, not Visa/Dankord
        errMsg = V.BankCardNumber("field", "5019 5555 4444 5555", BankCardBank.DankordPure);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.BankCardNumber("field", "5019 5555 4444 5555", BankCardBank.Visa);
        Assert.AreEqual("field must be a valid Card Number", errMsg);

        // Dankord cobranded with Visa, so it's also Visa
        errMsg = V.BankCardNumber("field", "4571 0000 0000 0001", BankCardBank.Visa);
        Assert.AreEqual(string.Empty, errMsg);

        // Visa/Dankord 
        errMsg = V.BankCardNumber("field", "4571 0000 0000 0001", BankCardBank.VisaDankord);
        Assert.AreEqual(string.Empty, errMsg);

        // cobranded with Visa, but accepted as Dankord
        errMsg = V.BankCardNumber("field", "4571 0000 0000 0001", BankCardBank.Dankord);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.BankCardNumber("field", "4571 0000 0000 0001", BankCardBank.Visa | BankCardBank.Mastercard);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.BankCardNumber("field", "4571 0000 0000 0001", BankCardBank.Visa | BankCardBank.Dankord);
        Assert.AreEqual(string.Empty, errMsg);
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
        errMsg = V.BankCardNumber("field", "6370 9511 1122 2231", BankCardBank.HiperCard);
        Assert.AreEqual(string.Empty, errMsg);

        // 637568 : 
        errMsg = V.BankCardNumber("field", "6375 6811 1122 2239", BankCardBank.HiperCard);
        Assert.AreEqual(string.Empty, errMsg);

        // 637599 : 
        errMsg = V.BankCardNumber("field", "6375 9911 1122 2232", BankCardBank.HiperCard);
        Assert.AreEqual(string.Empty, errMsg);

        // 637600 : 
        errMsg = V.BankCardNumber("field", "6376 0011 1122 2239", BankCardBank.HiperCard);
        Assert.AreEqual(string.Empty, errMsg);

        // 637609 : 
        errMsg = V.BankCardNumber("field", "6376 0911 1122 2230", BankCardBank.HiperCard);
        Assert.AreEqual(string.Empty, errMsg);

        // 637612 : 
        errMsg = V.BankCardNumber("field", "6376 1211 1122 2235", BankCardBank.HiperCard);
        Assert.AreEqual(string.Empty, errMsg);

        // 606282 : 
        errMsg = V.BankCardNumber("field", "6062 8211 1122 2239", BankCardBank.HiperCard);
        Assert.AreEqual(string.Empty, errMsg);

        // 384100 : 
        errMsg = V.BankCardNumber("field", "3841 0011 1122 2233 338", BankCardBank.HiperCard);
        Assert.AreEqual(string.Empty, errMsg);

        // 384140 : 
        errMsg = V.BankCardNumber("field", "3841 4011 1122 2233 334", BankCardBank.HiperCard);
        Assert.AreEqual(string.Empty, errMsg);

        // 384160 : 
        errMsg = V.BankCardNumber("field", "3841 6011 1122 2233 332", BankCardBank.HiperCard);
        Assert.AreEqual(string.Empty, errMsg);
    }
}
