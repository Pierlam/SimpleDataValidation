using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests.Validate;

[TestClass]
public class TestValidate
{
    [TestMethod]
    public void ValidateManyOk()
    {
        string errMsg;

        errMsg = V.Define("field", "john").AddNotNull().AddText().AddEquals("john").AddMinLength(3).
            AddMaxLength(10).AddExactLength(4).AddStartsWith("jo").AddEndsWith("hn").AddFirstCharLetter()
            .AddContains("oh").AddNotContains("xyz").Validate();

        // all rules are ok, so errMsg should be empty
        Assert.AreEqual(string.Empty, errMsg);
    }

    [TestMethod]
    public void ValidateManyErrors()
    {
        string errMsg;

        errMsg = V.Define("field", "john").AddNull().AddEquals("louis").AddMinLength(5).AddMaxLength(3).Validate();
        Assert.AreEqual("field must be null - field must be equal to: louis - field must be at least 5 characters long - field must be no more than 3 characters long", errMsg);
    }

    [TestMethod]
    public void DateTimeExpected()
    {
        string errMsg;

        errMsg = V.Define("field", "john").AddEquals(new DateTime(2024, 5, 1)).Validate();
        Assert.AreEqual("field must be a valid date", errMsg);
    }
}