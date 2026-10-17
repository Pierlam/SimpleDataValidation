namespace SimpleDataValidation.Tests;

[TestClass]
public sealed class Test_V_NotNull
{
    [TestMethod]
    public void NotNull()
    {
        string errMsg;
        errMsg = V.NotNull("field", "john");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.NotNull("field", null);
        Assert.AreEqual("field is required", errMsg);

        errMsg = V.NotNull("field",null, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void NotNullOrEmpty()
    {
        string errMsg;
        errMsg = V.NotNullOrEmpty("field", "john");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.NotNullOrEmpty("field", null);
        Assert.AreEqual("field is required", errMsg);

        errMsg = V.NotNullOrEmpty("field", string.Empty);
        Assert.AreEqual("field is required", errMsg);

        errMsg = V.NotNullOrEmpty("field", null, "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void Text()
    {
        string errMsg;
        errMsg = V.Text("field", "john");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.Text("field", null);
        Assert.AreEqual("field is required", errMsg);

        errMsg = V.Text("field", string.Empty);
        Assert.AreEqual("field is required", errMsg);

        errMsg = V.Text("field", "   ", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }

    [TestMethod]
    public void NotNullOrWhiteSpace()
    {
        string errMsg;
        errMsg = V.NotNullOrWhiteSpace("field", "john");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.NotNullOrWhiteSpace("field", null);
        Assert.AreEqual("field is required", errMsg);

        errMsg = V.NotNullOrWhiteSpace("field", string.Empty);
        Assert.AreEqual("field is required", errMsg);

        errMsg = V.NotNullOrWhiteSpace("field", "   ", "Custom error message");
        Assert.AreEqual("Custom error message", errMsg);
    }
}
