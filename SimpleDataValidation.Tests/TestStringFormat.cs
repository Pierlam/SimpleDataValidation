using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class TestStringFormat
{
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
