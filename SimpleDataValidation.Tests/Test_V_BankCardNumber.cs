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

}
