using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DevApp;

/// <summary>
/// https://www.iban.fr/verification.html
/// </summary>
public class IbanValidator
{
    /// <summary>
    /// Check if the provided IBAN is valid according to the IBAN validation rules. The IBAN should be in the format of a string, and it can contain spaces for readability. For example, a valid IBAN could be:
    /// "GB82 WEST 1234 5698 7654 32"
    /// </summary>
    /// <param name="iban"></param>
    /// <returns></returns>
    public bool CheckIban(string iban)
    {
        // Implement IBAN validation logic here
        if (string.IsNullOrWhiteSpace(iban))
        {
            return false;
        }

        // Remove spaces and convert to uppercase
        iban = iban.Replace(" ", "").ToUpper();

        // minimum length check for IBAN is 15 characters and maximum is 34 characters
        if (iban.Length < 15 || iban.Length > 34)
        {
            return false;
        }

        // Check if the IBAN contains only alphanumeric characters
        if (!iban.All(char.IsLetterOrDigit))
        {
            return false;
        }

        // Move the first four characters to the end of the string
        string rearrangedIban = iban.Substring(4) + iban.Substring(0, 4);

        // Convert letters to numbers (A=10, B=11, ..., Z=35)
        StringBuilder numericIban = new StringBuilder();
        foreach (char c in rearrangedIban)
        {
            if (char.IsLetter(c))
            {
                numericIban.Append((int)char.ToUpper(c) - 'A' + 10);
            }
            else
            {
                numericIban.Append(c);
            }
        }

        // Perform the mod-97 operation
        //BigInteger big = BigInteger.Parse(numericIban.ToString());
        //if (big % 97 != 1) return false;

        // csharp
        string numeric = numericIban.ToString();
        long remainder = 0;
        int pos = 0;
        while (pos < numeric.Length)
        {
            int len = Math.Min(9, numeric.Length - pos);
            string part = remainder.ToString() + numeric.Substring(pos, len);
            remainder = long.Parse(part) % 97;
            pos += len;
        }
        if (remainder != 1) return false;

        // Additional IBAN validation logic can be added here
        return true;
    }
}
