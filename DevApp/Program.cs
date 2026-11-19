// See https://aka.ms/new-console-template for more information
using DevApp;
using SimpleDataValidation;

void SomeTests()
{
    V.Setlanguage("en-gb");

    Console.WriteLine("Hello, World!");
    string errMsg;

    errMsg = V.NotNull("Name", "John");
    Console.WriteLine($"errorMessage: {errMsg}");

    //==test
    int a = 12;
    string s = "";
    errMsg = V.Int("field", a);
    errMsg = V.Int("field", s);

    string text = "bonjour";
    errMsg = V.Text("Bienvenue", text);
    errMsg = V.NotNullOrWhiteSpace("Bienvenue", text);


    //===many check on a data
    //errMsg = V.Define(null, "name").AddNotNull().AddMinLength(8).Validate();
    //if (string.IsNullOrWhiteSpace(errMsg)) return;
    //if (V.Error(errMsg)) return;


    errMsg = V.Define("toto", "name").AddNotNull().AddMinLength(8).Validate();
    Console.WriteLine("2: " + errMsg);


    string iban = "GB82 WEST 1234 5698 7654 32";

    errMsg = V.BankIban("field", iban);
    Console.WriteLine("Iban validation: " + errMsg);
}

void TestDates()
{
    var dt = new DateTime(2024, 5, 12);
    Console.WriteLine("Date validation: " + dt.ToShortDateString());
}

//========MAIN:
Console.WriteLine("=> Dev lib SimpleDataValidation:");


TestDates();
