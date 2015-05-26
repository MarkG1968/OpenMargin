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
        private Collateral collateral;
        private Exposure exposure;

        public MarginCall(Collateral collateral, Exposure exposure)
        {
            this.collateral = collateral;
            this.exposure = exposure;
            this.amount = (Money)exposure - (Money)collateral;
        }

        public Action Action
        {
            get { return IsAnticaptedDemand() ? DetermineActionDueToCollateralPosition() : collateral.IsCollateralHeldByOtherParty() ? Action.Recall : Action.Call; }
        }

        private OpenMargin.Action DetermineActionDueToCollateralPosition()
        {
            return collateral.IsCollateralHeld() ? Action.Return : Action.Delivery;
        }

        public bool IsAnticaptedDemand()
        {
            return amount.Amount < 0;
        }


        public Money AsAmount()
        {
            return amount;
        }

        public static explicit operator Money(MarginCall marginCall)
        {
            return marginCall.AsAmount();
        }
    }
}
