using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests.V_Directs;

[TestClass]
public class Test_V_CompareStrings
{
    [TestMethod]
    public void StringsEquals()
    {
        string errMsg;

        errMsg = V.Equals("field", "John", "John");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Equals("field", "John", "Jane");
        Assert.AreEqual("field must be equal to: Jane", errMsg);

        errMsg = V.Equals("field", "John", "Jane", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

}
