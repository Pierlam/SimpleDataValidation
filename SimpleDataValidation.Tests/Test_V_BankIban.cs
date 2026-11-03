using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Tests;

[TestClass]
public class Test_V_BankIban
{
    [TestMethod]
    public void IbanOkAndWrong()
    {
        string errMsg;

        string iban = "GB82 WEST 1234 5698 7654 32";
        errMsg = V.BankIban("field", iban);
        Assert.AreEqual(string.Empty, errMsg);

        iban = "GB82WEST12345698765432";
        errMsg = V.BankIban("field", iban);
        Assert.AreEqual(string.Empty, errMsg);

        iban = "gb82WEST12345698765432";
        errMsg = V.BankIban("field", iban);
        Assert.AreEqual(string.Empty, errMsg);

        errMsg = V.BankIban("field", "B82WEST12345698765432");
        Assert.AreEqual("field must be a valid IBAN", errMsg);
    }

}
