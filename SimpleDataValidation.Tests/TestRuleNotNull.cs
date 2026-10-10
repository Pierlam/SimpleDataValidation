using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class TestRuleNotNull
{
    [TestMethod]
    public void NotNull()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddNotNull().Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", null).AddNotNull().Validate();
        Assert.AreEqual("field is required", errMsg);
    }

    [TestMethod]
    public void NotNullMinLength()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddNotNull().AddMinLength(4).Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "louis").AddNotNull().AddMinLength(10).Validate();
        Assert.AreEqual("field must be at least 10 characters long", errMsg);

        // special case
        errMsg = V.Define("field", null).AddNotNull().AddMinLength(10).Validate();
        Assert.AreEqual("field is required - field must be at least 10 characters long", errMsg);
    }

}
