using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_IntNumberString
{
    [TestMethod]
    public void Int()
    {
        string errMsg;
        errMsg = V.Int("field", 12);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Int("field", null);
        Assert.AreEqual("field must be an integer", errMsg);

        errMsg = V.Int("field", null, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void Number()
    {
        string errMsg;
        errMsg = V.Number("field", 12);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Number("field", 12.34);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Number("field", (double)12.34);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Number("field", (float)12.34);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Number("field", null);
        Assert.AreEqual("field must be a number", errMsg);

        errMsg = V.Number("field", null, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void String()
    {
        string errMsg;
        errMsg = V.String("field", "string");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.String("field", null);
        Assert.AreEqual("field must be a string", errMsg);

        errMsg = V.String("field", null, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

}
