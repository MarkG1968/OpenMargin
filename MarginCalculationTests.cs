using Should.Fluent;
using NodaMoney;
using System.Globalization;
using Ploeh.AutoFixture.Dsl;
using MarkG1968.OpenMargin.Test;

namespace MarkG1968.OpenMargin
{
    public class MarginCalculationTests
    {
        [Input(100, 0, 100)]
        [Input(100, 100, 0)]
        public void can_calculate_margin_call(int expectedExposureAmount, int expectedCollateralAmount, int expectedMarginCallAmount)
        {
            Money expectedExposure = Money.PoundSterling(expectedExposureAmount);
            Money expectedCollateral = Money.PoundSterling(expectedCollateralAmount);
            Money expectedMarginCall = Money.PoundSterling(expectedMarginCallAmount);

            IExposureCalculation exposureCalculation = new ExposureCalculator(expectedExposure);
            ICollateralCalculation collateralCalculation = new CollateralCalculator(expectedCollateral);

            MarginCalculation sut = new MarginCalculation(exposureCalculation, collateralCalculation);

            sut.Calculate().Should().Equal(expectedMarginCall);
        }
    }
}
