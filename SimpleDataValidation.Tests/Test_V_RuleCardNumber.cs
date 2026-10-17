using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_RuleCardNumber
{
    [TestMethod]
    public void NotNullCardNumber()
    {
        string errMsg;
        errMsg = V.Define("field", "4111 1111 4555 1142").AddNotNull().AddCardNumber(CardBank.Visa).Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "4XXX 1111 4555 1142").AddNotNull().AddCardNumber(CardBank.Visa).Validate();
        Assert.AreEqual("field must be a valid Card Number", errMsg);

        errMsg = V.Define("field", null).AddNotNull().AddCardNumber(CardBank.Visa).Validate();
        Assert.AreEqual("field is required - field must be a valid Card Number", errMsg);
    }

}
