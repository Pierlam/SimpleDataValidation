using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests.V_Directs;

[TestClass]
public class Test_V_CompareDates
{
    [TestMethod]
    public void DatesEquals()
    {
        string errMsg;
        var dt= new DateTime(2024, 1, 1);
        var dt2 = new DateTime(2024, 1, 1);
        var dt3 = new DateTime(2026, 5, 12);

        errMsg = V.Equals("field", dt, dt2);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Equals("field", dt, dt3);
        Assert.AreEqual("field must be equal to the specified date: " + dt.ToShortDateString(), errMsg);
    }
}
