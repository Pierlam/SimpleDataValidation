using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_TrueFalse
{
    [TestMethod]
    public void TrueFalse()
    {
        string errMsg;
        errMsg = V.True("field", 10==10);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.False("field", 12 == 10);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.True("field", 10 == 12);
        Assert.AreEqual("field must be true", errMsg);

        errMsg = V.True("field", 10 == 12, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);

        errMsg = V.False("field", 12 == 12);
        Assert.AreEqual("field must be false", errMsg);

        errMsg = V.False("field", 12 == 12, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }
}
