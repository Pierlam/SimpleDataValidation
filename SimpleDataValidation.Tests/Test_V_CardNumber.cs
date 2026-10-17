using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_CardNumber
{
    [TestMethod]
    public void CarNumber()
    {
        string errMsg;
        errMsg = V.CardNumber("field", "4111 1111 4555 1142", CardBank.Visa);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.CardNumber("field", "4111 1111 4555 1142", CardBank.Visa | CardBank.Mastercard);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.CardNumber("field", null, CardBank.Visa);
        Assert.AreEqual("field must be a valid Card Number", errMsg);

        errMsg = V.CardNumber("field", null, CardBank.Visa, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

}
