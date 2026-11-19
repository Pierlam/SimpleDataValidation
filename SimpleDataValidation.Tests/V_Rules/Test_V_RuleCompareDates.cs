using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests.V_Rules;

[TestClass]
public class Test_V_RuleCompareDates
{
    [TestMethod]
    public void DateTimeEquals()
    {
        string errMsg;

        errMsg = V.Define("field", new DateTime(2024, 5, 1)).AddEquals(new DateTime(2024, 5, 1)).Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", new DateTime(2024, 5, 1)).AddText().AddEquals(new DateTime(2024, 5, 1)).Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Define("field", new DateTime(2024, 5, 1)).AddText().AddEquals(new DateTime(2026, 9, 13)).Validate();
        Assert.AreEqual("field must be equal to the specified date: " + new DateTime(2026, 9, 13).ToShortDateString(), errMsg);

        errMsg = V.Define("field", null).AddEquals(new DateTime(2026, 9, 13)).Validate();
        Assert.AreEqual("field must be a valid date", errMsg);

        errMsg = V.Define("field", null).AddText().AddEquals(new DateTime(2026, 9, 13)).Validate();
        Assert.AreEqual("field is required - field must be a valid date", errMsg);
    }
}
