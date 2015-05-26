using Should.Fluent;
using NodaMoney;
using System.Globalization;
using Ploeh.AutoFixture.Dsl;
using MarkG1968.OpenMargin.UnitTests.Test;
using Ploeh.AutoFixture;

namespace MarkG1968.OpenMargin.UnitTests
{
    public class MarginCalculationTests
    {
        private Fixture fixture;

        public MarginCalculationTests()
        {
            fixture = new Fixture();
        }

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

            MarginCall acutalMarginCall = sut.Calculate();
            
            acutalMarginCall.AsAmount().Should().Equal(expectedMarginCall);
        }

        public void performing_a_margin_calculation_should_result_in_margin_call()
        {
            Money expectedExposure = fixture.Create<Money>();
            Money expectedCollateral = fixture.Create<Money>();
            Money expectedMarginCall = fixture.Create<Money>();

            IExposureCalculation exposureCalculation = new ExposureCalculator(expectedExposure);
            ICollateralCalculation collateralCalculation = new CollateralCalculator(expectedCollateral);

            MarginCalculation sut = new MarginCalculation(exposureCalculation, collateralCalculation);

            sut.Calculate().Should().Be.AssignableFrom<MarginCall>();
        }
    }
}
