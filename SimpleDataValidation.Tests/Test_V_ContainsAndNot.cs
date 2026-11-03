using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_ContainsAndNot
{
    [TestMethod]
    public void Contains()
    {
        string errMsg;
        errMsg = V.Contains("field", "john", "oh");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Contains("field", null, "oh");
        Assert.AreEqual("field must contain: oh", errMsg);

        errMsg = V.Contains("field", null, "oh", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void ContainsCaseInsensitive()
    {
        string errMsg;
        errMsg = V.ContainsCaseInsensitive("field", "john", "OH");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.ContainsCaseInsensitive("field", null, "oh");
        Assert.AreEqual("field must contain: oh", errMsg);

        errMsg = V.ContainsCaseInsensitive("field", null, "oh", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void NotContains()
    {
        string errMsg;
        errMsg = V.NotContains("field", "john", "abc");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.NotContains("field", "john", "oh");
        Assert.AreEqual("field must not contain: oh", errMsg);

        errMsg = V.NotContains("field", null, "ieh");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.NotContains("field", "john", "oh", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void NotContainsCaseInsensitive()
    {
        string errMsg;
        errMsg = V.NotContainsCaseInsensitive("field", "john", "ABC");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.NotContainsCaseInsensitive("field", null, "ABC");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.NotContainsCaseInsensitive("field", "john", "OH");
        Assert.AreEqual("field must not contain: OH", errMsg);

        errMsg = V.NotContainsCaseInsensitive("field", "john", "OH", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

}
