using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodaMoney;

namespace MarkG1968.OpenMargin
{
    public class Collateral
    {
        private Money amount;

        public Collateral(Money amount)
        {
            this.amount = amount;
        }

        public static implicit operator Money(Collateral collateral)
        {
            return collateral.amount;
        }

        public bool IsCollateralHeld()
        {
            return amount.IsPositive();
        }

        public bool IsCollateralHeldByOtherParty()
        {
            return amount.IsNegative();
        }
    }
}
