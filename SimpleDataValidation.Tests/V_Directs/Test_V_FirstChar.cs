using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests.V_Directs;

[TestClass]
public class Test_V_FirstChar
{
    [TestMethod]
    public void FirstCharIn()
    {
        string errMsg;
        errMsg = V.FirstCharIn("field", "john","jx");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.FirstCharIn("field", "jane","abc");
        Assert.AreEqual("field first char must be in: abc", errMsg);

        errMsg = V.FirstCharIn("field", "john", "ab","Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void FirstCharNotIn()
    {
        string errMsg;
        errMsg = V.FirstCharNotIn("field", "john", "xyz");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.FirstCharNotIn("field", "jane", "js");
        Assert.AreEqual("field first char must be not in: js", errMsg);

        errMsg = V.FirstCharNotIn("field", "john", "jo", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void FirstCharLetter()
    {
        string errMsg;
        errMsg = V.FirstCharLetter("field", "john");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.FirstCharLetter("field", "9jane");
        Assert.AreEqual("field first char must be a letter", errMsg);

        errMsg = V.FirstCharLetter("field", "4john", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

}
