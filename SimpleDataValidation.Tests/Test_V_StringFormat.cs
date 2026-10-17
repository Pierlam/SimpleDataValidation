using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_StringFormat
{
    [TestMethod]
    public void Letters()
    {
        string errMsg;
        errMsg = V.Letters("field", "john");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Letters("field", "j12hn");
        Assert.AreEqual("field must contains only letter", errMsg);

        errMsg = V.Letters("field", null);
        Assert.AreEqual("field must contains only letter", errMsg);

        errMsg = V.Letters("field", "12", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void Digits()
    {
        string errMsg;
        errMsg = V.Digits("field", "12345");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Digits("field", "j12hn");
        Assert.AreEqual("field must contains only digit", errMsg);

        errMsg = V.Digits("field", null);
        Assert.AreEqual("field must contains only digit", errMsg);

        errMsg = V.Digits("field", "text", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void LettersDigitsUnderscore()
    {
        string errMsg;
        errMsg = V.LettersDigitsUnderscore("field", "john");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.LettersDigitsUnderscore("field", null);
        Assert.AreEqual("field must contains only letter, digit or underscore", errMsg);

        errMsg = V.LettersDigitsUnderscore("field", "<<null>>");
        Assert.AreEqual("field must contains only letter, digit or underscore", errMsg);

        errMsg = V.LettersDigitsUnderscore("field", null, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

}
