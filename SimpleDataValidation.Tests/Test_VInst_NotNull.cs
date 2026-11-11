using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_VInst_NotNull
{
    [TestMethod]
    public void TestVInst_NotNull()
    {
        VInst vInst = V.CreateInst();

        string errMsg;
        errMsg = vInst.NotNull("field", "value");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = vInst.NotNull("field", null);
        Assert.AreEqual("field is required", errMsg);

        errMsg = vInst.Define("field", "value").AddNotNull().Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = vInst.Define("field", null).AddNotNull().Validate();
        Assert.AreEqual("field is required", errMsg);
    }
}
