using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_StartsWithAndFirstChar
{
    [TestMethod]
    public void StartsWith()
    {
        string errMsg;
        errMsg = V.StartsWith("field", "john", "jo");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.StartsWith("field", null, "jo");
        Assert.AreEqual("field must starts with: jo", errMsg);

        errMsg = V.StartsWith("field", null, "jo", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void FirstCharIn()
    {
        string errMsg;
        errMsg = V.FirstCharIn("field", "john", "jxz");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.FirstCharIn("field", "john", "abc");
        Assert.AreEqual("field first char must be in: abc", errMsg);

        errMsg = V.FirstCharIn("field", null, "jo");
        Assert.AreEqual("field first char must be in: jo", errMsg);

        errMsg = V.FirstCharIn("field", null, "jo", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void FirstCharNotIn()
    {
        string errMsg;
        errMsg = V.FirstCharNotIn("field", "john", "abc");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.FirstCharNotIn("field", null, "jo");
        Assert.AreEqual("field first char must be not in: jo", errMsg);

        errMsg = V.FirstCharNotIn("field", "john", "jo");
        Assert.AreEqual("field first char must be not in: jo", errMsg);

        errMsg = V.FirstCharNotIn("field", null, "jo", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

}
