using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_RuleFirstChar
{
    [TestMethod]
    public void FirstCharIn()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddFirstCharIn("jx").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddFirstCharIn("abc").Validate();
        Assert.AreEqual("field first char must be in: abc", errMsg);

        errMsg = V.Define("field", null).AddFirstCharIn("jo").Validate();
        Assert.AreEqual("field must be a string", errMsg);
    }

    [TestMethod]
    public void FirstCharNotIn()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddFirstCharNotIn("xyz").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddFirstCharNotIn("js").Validate();
        Assert.AreEqual("field first char must be not in: js", errMsg);

        errMsg = V.Define("field", null).AddFirstCharNotIn("jo").Validate();
        Assert.AreEqual("field must be a string", errMsg);
    }

    [TestMethod]
    public void FirstCharLetter()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddFirstCharLetter().Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "123").AddFirstCharLetter().Validate();
        Assert.AreEqual("field first char must be a letter", errMsg);

        errMsg = V.Define("field", null).AddFirstCharLetter().Validate();
        Assert.AreEqual("field must be a string", errMsg);
    }

}
