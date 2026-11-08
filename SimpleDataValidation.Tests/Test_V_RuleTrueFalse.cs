using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_RuleTrueFalse
{
    [TestMethod]
    public void AddTrue()
    {
        string errMsg;

        // Test case: value is true - should pass
        errMsg = V.Define("field", true).AddTrue().Validate();
        Assert.AreEqual(string.Empty, errMsg);

        // Test case: value is false - should fail with default message
        errMsg = V.Define("field", false).AddTrue().Validate();
        Assert.AreEqual("field must be true", errMsg);
    }

    [TestMethod]
    public void AddFalse()
    {
        string errMsg;

        // Test case: value is false - should pass
        errMsg = V.Define("field", false).AddFalse().Validate();
        Assert.AreEqual(string.Empty, errMsg);

        // Test case: value is true - should fail with default message
        errMsg = V.Define("field", true).AddFalse().Validate();
        Assert.AreEqual("field must be false", errMsg);
    }

    [TestMethod]
    public void CombinedRules()
    {
        string errMsg;

        // Test case: multiple rules where first passes
        errMsg = V.Define("field", true)
            .AddTrue()
            .Validate();
        Assert.AreEqual(string.Empty, errMsg);

        // Test case: multiple rules where first fails
        errMsg = V.Define("field", false)
            .AddTrue()
            .Validate();
        Assert.AreEqual("field must be true", errMsg);

        // Test case: True and False combined (should both fail for any boolean)
        errMsg = V.Define("field", true)
            .AddTrue()
            .AddFalse()
            .Validate();
        Assert.AreEqual("field must be false", errMsg);

        // Test case: True and False combined (should both fail for any boolean)
        errMsg = V.Define("field", false)
            .AddFalse()
            .AddTrue()
            .Validate();
        Assert.AreEqual("field must be true", errMsg);
    }

    [TestMethod]
    public void MultiLanguage()
    {
        // Save current language
        V.Setlanguage("en-gb");

        string errMsg;
        errMsg = V.Define("field", false).AddTrue().Validate();
        Assert.AreEqual("field must be true", errMsg);

        errMsg = V.Define("field", true).AddFalse().Validate();
        Assert.AreEqual("field must be false", errMsg);

        // Test with French
        V.Setlanguage("fr-fr");
        errMsg = V.Define("field", false).AddTrue().Validate();
        Assert.AreEqual("field doit être vrai", errMsg);

        errMsg = V.Define("field", true).AddFalse().Validate();
        Assert.AreEqual("field doit être faux", errMsg);

        // Reset to default language
        V.Setlanguage("en-gb");
    }
}
