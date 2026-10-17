using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_RuleStartsWithFirstCharInNotIn
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
    public void FirstCharIn()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddFirstCharIn("jx").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "john").AddFirstCharIn("abc").Validate();
        Assert.AreEqual("field first char must be in: abc", errMsg);

        errMsg = V.Define("field", null).AddFirstCharIn("jo").Validate();
        Assert.AreEqual("field first char must be in: jo", errMsg);
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
        Assert.AreEqual("field first char must be not in: jo", errMsg);
    }

}
