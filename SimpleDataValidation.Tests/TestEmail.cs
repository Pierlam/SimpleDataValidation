using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class TestEmail
{
    [TestMethod]
    public void EmailBasic()
    {
        string errMsg;
        errMsg = V.EmailFormat("field", "pierlam-project@outlook.com");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.EmailFormat("field", "invalid-email");
        Assert.AreEqual("field must be a valid email address", errMsg);

        errMsg = V.EmailFormat("field", "john@", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void Email()
    {
        string errMsg;
        errMsg = V.Email("field", "pierlam-project@outlook.com");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Email("field", "invalid-email");
        Assert.AreEqual("field must be a valid email address", errMsg);

        errMsg = V.Email("field", "john@", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void EmailStrict()
    {
        string errMsg;
        errMsg = V.EmailStrict("field", "pierlam-project@outlook.com");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.EmailStrict("field", "invalid-email");
        Assert.AreEqual("field must be a valid email address", errMsg);

        errMsg = V.EmailStrict("field", "john@", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

}
