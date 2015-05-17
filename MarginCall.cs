using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodaMoney;

namespace MarkG1968.OpenMargin
{
    public class MarginCall
    {
        private Money amount;
        private Money collateralAmount;

        public MarginCall(Money amount)
        {
            this.amount = amount;
            this.collateralAmount = new Money(0, amount.Currency);
        }

        public MarginCall(Money amount, Money collateralAmount)
        {
            this.amount = amount;
            this.collateralAmount = collateralAmount;
        }

        public Action Action
        {
            get { return IsAnticaptedDemand() ? DetermineActionDueToCollateralPosition() : IsCollateralHeldByOtherParty() ? Action.Recall : Action.Call; }
        }

        private OpenMargin.Action DetermineActionDueToCollateralPosition()
        {
            return IsCollateralHeld() ? Action.Return : Action.Delivery;
        }

        private bool IsAnticaptedDemand()
        {
            return amount.Amount < 0;
        }

        public static implicit operator Money(MarginCall marginCall)
        {
            return marginCall.amount;
        }

        public bool IsCollateralHeld() 
        {
            return collateralAmount.Amount > 0;
        }

        public bool IsCollateralHeldByOtherParty()
        {
            return collateralAmount.Amount < 0;
        }
    }
}
