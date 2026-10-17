using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_CardNumber
{
    [TestMethod]
    public void Text()
    {
        string errMsg;
        //errMsg = V.CardNumber("field", "john");
        //Assert.AreEqual(string.Empty, errMsg);

        //errMsg = V.Define("field", null).AddText().Validate();
        //Assert.AreEqual("field is required", errMsg);
    }

}
