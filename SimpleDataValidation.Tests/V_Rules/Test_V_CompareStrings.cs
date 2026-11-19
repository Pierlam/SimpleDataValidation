using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests.V_Rules;

public class Test_V_CompareStrings
{
    [TestMethod]
    public void StringEquals()
    {
        string errMsg;
        errMsg = V.Define("field", "John").AddText().AddEquals("John").Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", "John").AddText().AddEquals("Jane").Validate();
        Assert.AreEqual("field must be equal to: Jane", errMsg);

        errMsg = V.Define("field", null).AddText().AddEquals("Jane").Validate();
        Assert.AreEqual("field is required - field must be a valid string", errMsg);
    }

}
