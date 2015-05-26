using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodaMoney;

namespace MarkG1968.OpenMargin
{
    public class CollateralCalculator : ICollateralCalculation
    {
        private Collateral collateral;

        public CollateralCalculator(Money collateral)
        {
            this.collateral = (Collateral)collateral;
        }

        public Collateral CalculateCollateral()
        {
            return collateral;
        }
    }
}
