using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleBankCardNumber: RuleBase
{
    public RuleBankCardNumber(BankCardBank cardBank)
    {
        CardBank = cardBank;
    }

    public BankCardBank CardBank { get; }


}
