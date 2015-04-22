using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should.Fluent;
using NodaMoney;
using System.Globalization;

namespace MarkG1968.OpenMargin
{
    public class MarginCalculationTests
    {
        public void can_create_exposure(Money exposure)
        {
            exposure.Should().Equal(exposure);
        }

        public void can_calculate_margin(ExposureCalculator exposureCalc)
        {
            MarginCalculation sut = new MarginCalculation(exposureCalc);
            sut.Calculate().Should().Equal(Money.PoundSterling(2000));
        }

        public void can_convert_money_using_invariant_culture()
        {
            Money.PoundSterling(3000).ToString("C", CultureInfo.InvariantCulture).Should().Equal("£3,000.00");
        }
    }
}
