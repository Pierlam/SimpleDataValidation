using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_RuleLength
{
    [TestMethod]
    public void MinMaxLength()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddMinLength(3).AddMaxLength(10).Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "jo").AddMinLength(3).AddMaxLength(10).Validate();
        Assert.AreEqual("field must be at least 3 characters long", errMsg);

        errMsg = V.Define("field", "johnjohnjohn").AddMinLength(3).AddMaxLength(10).Validate();
        Assert.AreEqual("field must be no more than 10 characters long", errMsg);
    }

    [TestMethod]
    public void BetweenLength()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddBetweenLength(2, 10).Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "jo").AddBetweenLength(2, 10).Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "j").AddBetweenLength(2, 10).Validate();
        Assert.AreEqual("field must be between 2 and 10 characters long", errMsg);

        // Not yet implemented in RuleValidator.cs
        //errMsg = V.Define("field", "johnjohnjohn").AddBetweenLength(2, 10, "Custom error message").Validate();
        //Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void ExactLength()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddExactLength(4).Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "jo").AddExactLength(4).Validate();
        Assert.AreEqual("field must be exactly 4 characters long", errMsg);
    }

}
