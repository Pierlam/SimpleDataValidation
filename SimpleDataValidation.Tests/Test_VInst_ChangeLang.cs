using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_VInst_ChangeLang
{
    [TestMethod]
    public void TestVInst_LangNotExists()
    {
        try
        {
            VInst vInst = V.CreateInst("notexists");
            Assert.IsNotNull(vInst);
        }
        catch (Exception ex)
        {
            Assert.AreEqual("Language 'notexists' not found in the error message table", ex.Message);
        }
    }

    [TestMethod]
    public void TestVInst_NotNull_DefaultLang()
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

    [TestMethod]
    public void TestVInst_NotNull_Fr_Fr()
    {
        VInst vInst = V.CreateInst("fr-fr");

        string errMsg;
        errMsg = vInst.NotNull("field", "value");
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = vInst.NotNull("field", null);
        Assert.AreEqual("field est requis", errMsg);

        errMsg = vInst.Define("field", "value").AddNotNull().Validate();
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = vInst.Define("field", null).AddNotNull().Validate();
        Assert.AreEqual("field est requis", errMsg);
    }

    [TestMethod]
    public void TestVInst_NotNull_2Inst_diffLang()
    {
        string errMsg;
        errMsg = V.NotNull("field", null);
        Assert.AreEqual("field is required", errMsg);

        errMsg = V.Define("field", null).AddNotNull().Validate();
        Assert.AreEqual("field is required", errMsg);

        //--fr-fr
        VInst vInst = V.CreateInst("fr-fr");

        errMsg = vInst.NotNull("field", null);
        Assert.AreEqual("field est requis", errMsg);

        errMsg = vInst.Define("field", null).AddNotNull().Validate();
        Assert.AreEqual("field est requis", errMsg);


        //--it-it
        VInst vInstIt = V.CreateInst("it-it");

        errMsg = vInstIt.NotNull("field", null);
        Assert.AreEqual("field è obbligatorio", errMsg);

        errMsg = vInstIt.Define("field", null).AddNotNull().Validate();
        Assert.AreEqual("field è obbligatorio", errMsg);

        //--back to the default lang (en-gb)
        errMsg = V.NotNull("field", null);
        Assert.AreEqual("field is required", errMsg);

    }

}
