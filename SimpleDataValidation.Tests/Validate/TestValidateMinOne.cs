using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests.Validate;

[TestClass]
public class TestValidateMinOne
{
    [TestMethod]
    public void ValidateMinOneOk()
    {
        string errMsg;

        // all rule are ok, so errMsg should be empty
        errMsg = V.Define("field", "john").AddNotNull().AddEquals("john").ValidateMinOne();
        Assert.AreEqual(string.Empty, errMsg);

        // only the first rule is ok, so errMsg should be empty
        errMsg = V.Define("field", "john").AddNotNull().AddEquals("louis").ValidateMinOne();
        Assert.AreEqual(string.Empty, errMsg);

        // the last rule is ok, so errMsg should be empty
        errMsg = V.Define("field", "john").AddNull().AddEquals("louis").AddMinLength(10).AddFirstCharLetter().ValidateMinOne();
        Assert.AreEqual(string.Empty, errMsg);

        // all rules are wrong, so errMsg should be the concatenation of all error messages
        errMsg = V.Define("field", "john").AddMinLength(10).AddEquals("louis").ValidateMinOne();
        Assert.AreEqual("field must be at least 10 characters long - field must be equal to: louis", errMsg);
    }
}
