using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation.Rule;

public class RuleCardNumber: RuleBase
{
    public RuleCardNumber(CardBank cardBank)
    {
        CardBank = cardBank;
    }

    public CardBank CardBank { get; }


}
