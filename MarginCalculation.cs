using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodaMoney;

namespace MarkG1968.OpenMargin
{
    public class MarginCalculation
    {
        private IExposureCalculation exposureCalculation;
        private ICollateralCalculation collateralCalculation;

        public MarginCalculation(IExposureCalculation exposureCalculation, ICollateralCalculation collateralCalculation)
        {
            this.exposureCalculation = exposureCalculation;
            this.collateralCalculation = collateralCalculation;
        }

        public Money Calculate()
        {
            Money collateral = collateralCalculation.CalculateCollateral();
            Money exposure = exposureCalculation.CalculateExposure();
            return exposure - collateral;
        }
    }
}
