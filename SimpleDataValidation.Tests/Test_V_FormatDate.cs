using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_FormatDate
{
    [TestMethod]
    public void FormatDateOneFormat()
    {
        string errMsg;
        errMsg = V.FormatDate("name", "10/12/2026", "dd/MM/yyyy");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.FormatDate("name", "10/12/202", "dd/MM/yyyy");
        Assert.AreEqual("name must be a valid date", errMsg);

        /// "yyyy-MM-dd HH:mm:ss,fff"
        errMsg = V.FormatDate("name", "2026-12-20 10:30:00,123", "yyyy-MM-dd HH:mm:ss,fff");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.FormatDate("name", "10/12/202", "dd/MM/yyyy", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void FormatDateSeveralFormats()
    {
        string errMsg;
        errMsg = V.FormatDate("name", "2026-10-25", new[] { "dd/MM/yyyy", "yyyy-MM-dd" });
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.FormatDate("name", "2026-27-25", new[] { "dd/MM/yyyy", "yyyy-MM-dd" });
        Assert.AreEqual("name must be a valid date", errMsg);

        errMsg = V.FormatDate("name", "10/12/202", new[] { "dd/MM/yyyy", "yyyy-MM-dd" }, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }
}
