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

        public static explicit operator Money(Collateral collateral)
        {
            return collateral.amount;
        }

        public static explicit operator Collateral(Money amount)
        {
            return new Collateral(amount);
        }
        
        public bool IsCollateralHeld()
        {
            return amount.IsPositive();
        }

        public bool IsCollateralHeldByOtherParty()
        {
            return amount.IsNegative();
        }

        public Money AsAmount()
        {
            return amount;
        }
    }
}
