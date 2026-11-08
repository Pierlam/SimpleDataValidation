using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataValidation;

public class PrefixToBankItem
{
    public string PrefixStart { get; set; }

    public string PrefixEnd { get; set; } = string.Empty;

    public int IntPrefixStart { get; set; }

    public int IntPrefixEnd { get; set; } = 0;

    public BankCardBank Bank { get; set; }
    public int LengthMin { get; set; }

    public int LengthMax { get; set; }

    public bool LengthCheckResult { get; set; }
    public bool AppyLuhnCheck { get; set; } = true;
}

public class PrefixToBankMapper
{
    List<PrefixToBankItem> _prefixesToBanks = new List<PrefixToBankItem>();

    public void AddStart(string prefix, BankCardBank bank, int length, bool applyLuhnCheck)
    {
        AddStart(prefix, bank, length, length, applyLuhnCheck);
    }

    public void AddStart(string prefix, BankCardBank bank, int lengthMin, int lengthMax, bool applyLuhnCheck)
    {
        if(!int.TryParse(prefix, out int prefixStart))throw new ArgumentException("prefix must be a number", nameof(prefix));

        PrefixToBankItem item = new PrefixToBankItem
        {
            PrefixStart = prefix,
            IntPrefixStart = prefixStart,
            Bank = bank,
            LengthMin = lengthMin,
            LengthMax = lengthMax,
            AppyLuhnCheck = applyLuhnCheck
        };
        _prefixesToBanks.Add(item);
    }

    public void AddStart(string prefixStart, string prefixEnd, BankCardBank bank, int length, bool applyLuhnCheck)
    {
        AddStart(prefixStart, prefixEnd, bank, length, length, applyLuhnCheck);    
    }

    public void AddStart(string prefixStart, string prefixEnd, BankCardBank bank, int lengthMin, int lengthMax, bool applyLuhnCheck)
    {
        if (!int.TryParse(prefixStart, out int intPrefixStart)) throw new ArgumentException("prefix must be a number", nameof(prefixStart));
        if (!int.TryParse(prefixEnd, out int intPrefixEnd)) throw new ArgumentException("prefix must be a number", nameof(prefixEnd));

        if(intPrefixEnd < intPrefixStart) throw new ArgumentException("prefixEnd must be greater than prefixStart", nameof(prefixEnd));
        if (lengthMax< lengthMax) throw new ArgumentException("LengthMax must be greater than lengthMin", nameof(prefixEnd));

        PrefixToBankItem item = new PrefixToBankItem
        {
            PrefixStart = prefixStart,
            PrefixEnd = prefixEnd,
            IntPrefixStart = intPrefixStart,
            IntPrefixEnd = intPrefixEnd,
            Bank = bank,
            LengthMin = lengthMin,
            LengthMax = lengthMax,
            AppyLuhnCheck = applyLuhnCheck
        };
        _prefixesToBanks.Add(item);
    }

    public PrefixToBankItem GetItem(string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber)) return null;

        foreach (var item in _prefixesToBanks)
        {
            //--only prefix start
            if(item.PrefixEnd==string.Empty)
            {
                if(cardNumber.StartsWith(item.PrefixStart))
                {
                    if (cardNumber.Length >= item.LengthMin && cardNumber.Length <= item.LengthMax) item.LengthCheckResult = true;
                    else item.LengthCheckResult = false;
                    return item;
                }

                // goto next item
                continue;
            }

            string prefix = cardNumber.Substring(0, item.PrefixStart.Length);
            int intPrefix = int.Parse(prefix);
            if(intPrefix >= item.IntPrefixStart && intPrefix <= item.IntPrefixEnd)
            {
                if (cardNumber.Length >= item.LengthMin && cardNumber.Length <= item.LengthMax) item.LengthCheckResult = true;
                else item.LengthCheckResult = false;
                return item;
            }
        }
        return null;
    }
}
