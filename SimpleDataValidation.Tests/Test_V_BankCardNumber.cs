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
    public void CarNumber()
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

}
