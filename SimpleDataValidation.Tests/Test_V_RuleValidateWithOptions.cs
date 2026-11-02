using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_RuleValidateWithOptions
{
    [TestMethod]
    public void MinMaxLength()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddMinLength(3).AddMaxLength(10).Validate(ValidateOptions.StopOnFirstError);
        Assert.AreEqual(string.Empty, errMsg);

        // normal
        errMsg = V.Define("field", "jo").AddMinLength(3).AddMaxLength(10).Validate(ValidateOptions.StopOnFirstError);
        Assert.AreEqual("field must be at least 3 characters long", errMsg);

        // continue on error, so the max length validation will be executed and the error message will be concatenated
        errMsg = V.Define("field", "johnjohn").AddMinLength(10).AddMaxLength(5).Validate();
        Assert.AreEqual("field must be at least 10 characters long - field must be no more than 5 characters long", errMsg);

        // will stop on the first error, so the max length validation will not be executed
        errMsg = V.Define("field", "johnjohn").AddMinLength(10).AddMaxLength(4).Validate(ValidateOptions.StopOnFirstError);
        Assert.AreEqual("field must be at least 10 characters long", errMsg);
    }

    [TestMethod]
    public void MinMaxLengthContainsStartsWith()
    {
        string errMsg;
        errMsg = V.Define("field", "john").AddMinLength(5).AddContains("a").AddStartsWith("x").Validate();
        Assert.AreEqual("field must be at least 5 characters long - field must contain: a - field must starts with: x", errMsg);

        // only the first error message will be returned, because we are using the StopOnFirstError option
        errMsg = V.Define("field", "john").AddMinLength(5).AddContains("a").AddStartsWith("x").Validate(ValidateOptions.StopOnFirstError);
        Assert.AreEqual("field must be at least 5 characters long", errMsg);
    }
}
