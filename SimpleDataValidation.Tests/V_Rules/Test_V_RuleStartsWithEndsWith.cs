using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_RuleStartsWithEndsWith
{
    [TestMethod]
    public void StartsWith()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddStartsWith("jo").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddStartsWith("abc").Validate();
        Assert.AreEqual("field must starts with: abc", errMsg);

        errMsg = V.Define("field", null).AddStartsWith("jo").Validate();
        Assert.AreEqual("field must starts with: jo", errMsg);
    }

    [TestMethod]
    public void StartsWithCaseInsensitive()
    {
        string errMsg;
        errMsg = V.Define("field", "John").AddStartsWithCaseInsensitive("jo").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "JOHN").AddStartsWithCaseInsensitive("jo").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddStartsWithCaseInsensitive("JO").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddStartsWithCaseInsensitive("abc").Validate();
        Assert.AreEqual("field must starts with: abc", errMsg);

        errMsg = V.Define("field", null).AddStartsWithCaseInsensitive("jo").Validate();
        Assert.AreEqual("field must starts with: jo", errMsg);
    }

    [TestMethod]
    public void EndsWith()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddEndsWith("hn").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddEndsWith("abc").Validate();
        Assert.AreEqual("field must ends with: abc", errMsg);

        errMsg = V.Define("field", null).AddEndsWith("jo").Validate();
        Assert.AreEqual("field must ends with: jo", errMsg);
    }

    [TestMethod]
    public void EndsWithCaseInsensitive()
    {
        string errMsg;
        errMsg = V.Define("field", "John").AddEndsWithCaseInsensitive("hn").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "JOHN").AddEndsWithCaseInsensitive("hn").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddEndsWithCaseInsensitive("HN").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddEndsWithCaseInsensitive("abc").Validate();
        Assert.AreEqual("field must ends with: abc", errMsg);

        errMsg = V.Define("field", null).AddEndsWithCaseInsensitive("jo").Validate();
        Assert.AreEqual("field must ends with: jo", errMsg);
    }
}
