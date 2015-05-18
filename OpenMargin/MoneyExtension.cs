using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaMoney;

namespace MarkG1968.OpenMargin
{  
    public static class MoneyExtension
    {
        public static bool IsNegative(this Money money)
        {
            return money.Amount < 0;
        }

        public static bool IsPositive(this Money money)
        {
            return money.Amount > 0;
        }
    }
}
