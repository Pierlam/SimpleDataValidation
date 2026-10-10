using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class TestLength
{
    [TestMethod]
    public void BetweenLength()
    {
        string errMsg;
        errMsg = V.BetweenLength("field", "john", 2, 10);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.BetweenLength("field", "jo", 2, 10);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.BetweenLength("field", "j", 2, 10);
        Assert.AreEqual("field must be between 2 and 10 characters long", errMsg);

        errMsg = V.BetweenLength("field", "johnjohnjohn", 2, 10, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void MinLength()
    {
        string errMsg;

        errMsg = V.MinLength("field", "john", 2);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.MinLength("field", "john", 25);
        Assert.AreEqual("field must be at least 25 characters long", errMsg);

        // special case
        errMsg = V.MinLength("field", null, 4);
        Assert.AreEqual("field must be at least 4 characters long", errMsg);
    }

    [TestMethod]
    public void MaxLength()
    {
        string errMsg;
        errMsg = V.MaxLength("field", "john", 10);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.MaxLength("field", "john", 3);
        Assert.AreEqual("field must be no more than 3 characters long", errMsg);

        // special case
        errMsg = V.MaxLength("field", null, 2);
        Assert.AreEqual(string.Empty, errMsg);
    }

    [TestMethod]
    public void ExactLength()
    {
        string errMsg;
        errMsg = V.ExactLength("field", "john", 4);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.ExactLength("field", "john", 3);
        Assert.AreEqual("field must be exactly 3 characters long", errMsg);

        // special case
        errMsg = V.ExactLength("field", null, 2);
        Assert.AreEqual("field must be exactly 2 characters long", errMsg);
    }

}
