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

        public MarginCall(Money amount)
        {
            this.amount = amount;
            this.collateral = new Collateral(new Money(0, amount.Currency));
        }

        public MarginCall(Money amount, Money collateralAmount)
        {
            this.amount = amount;
            this.collateral = new Collateral(collateralAmount);
        }

        public MarginCall(Money collateralAmount, Exposure exposure)
        {
            this.collateral = new Collateral(collateralAmount);
            this.exposure = exposure;
            Money exposureMoney = exposure;
            Money collateralMoney = collateral;
            this.amount = exposureMoney - collateralMoney;
        }
        
        public Action Action
        {
            get { return IsAnticaptedDemand() ? DetermineActionDueToCollateralPosition() : collateral.IsCollateralHeldByOtherParty() ? Action.Recall : Action.Call; }
        }

        private OpenMargin.Action DetermineActionDueToCollateralPosition()
        {
            return collateral.IsCollateralHeld() ? Action.Return : Action.Delivery;
        }

        private bool IsAnticaptedDemand()
        {
            return amount.Amount < 0;
        }

        public static implicit operator Money(MarginCall marginCall)
        {
            return marginCall.amount;
        }
    }
}
