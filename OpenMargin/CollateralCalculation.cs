using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodaMoney;

namespace MarkG1968.OpenMargin
{
    public class CollateralCalculator : ICollateralCalculation
    {
        private Money collateral;

        public CollateralCalculator(Money collateral)
        {
            this.collateral = collateral;
        }

        public Money CalculateCollateral()
        {
            return collateral;
        }
    }
}
