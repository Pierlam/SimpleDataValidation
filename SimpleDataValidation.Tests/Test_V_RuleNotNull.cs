using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_RuleNotNull
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
    public void NotNullOrEmpty()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddNotNullOrEmpty().Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", null).AddNotNullOrEmpty().Validate();
        Assert.AreEqual("field is required", errMsg);
    }


    [TestMethod]
    public void NotNullOrWhiteSpace()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddNotNullOrWhiteSpace().Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", null).AddNotNullOrWhiteSpace().Validate();
        Assert.AreEqual("field is required", errMsg);
    }

    [TestMethod]
    public void Text()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddText().Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", null).AddText().Validate();
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
