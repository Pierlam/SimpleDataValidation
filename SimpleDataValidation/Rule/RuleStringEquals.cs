namespace SimpleDataValidation.Rule;

public class RuleStringEquals : RuleBase
{
    public string ExpectedValue { get; }

    public RuleStringEquals(string expectedValue)
    {
        ExpectedValue = expectedValue;
    }
}
