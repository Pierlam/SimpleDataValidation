using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_RuleContainsAndNot
{
    [TestMethod]
    public void Contains()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddContains("oh").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddContains("abc").Validate();
        Assert.AreEqual("field must contain: abc", errMsg);

        errMsg = V.Define("field", null).AddContains("jo").Validate();
        Assert.AreEqual("field must contain: jo", errMsg);
    }

    [TestMethod]
    public void ContainsCaseInsensitive()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddContainsCaseInsensitive("OH").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddContainsCaseInsensitive("ABC").Validate();
        Assert.AreEqual("field must contain: ABC", errMsg);

        errMsg = V.Define("field", null).AddContainsCaseInsensitive("JO").Validate();
        Assert.AreEqual("field must contain: JO", errMsg);
    }

    [TestMethod]
    public void NotContains()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddNotContains("ab").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddNotContains("oh").Validate();
        Assert.AreEqual("field must not contain: oh", errMsg);

        errMsg = V.Define("field", null).AddNotContains("jo").Validate();
        Assert.AreEqual(string.Empty, errMsg);
    }

    [TestMethod]
    public void NotContainsCaseInsensitive()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddNotContainsCaseInsensitive("AB").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddNotContainsCaseInsensitive("OH").Validate();
        Assert.AreEqual("field must not contain: OH", errMsg);

        errMsg = V.Define("field", null).AddNotContainsCaseInsensitive("JO").Validate();
        Assert.AreEqual(string.Empty, errMsg);
    }

}
