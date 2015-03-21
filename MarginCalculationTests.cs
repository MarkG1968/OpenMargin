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

        public void can_calculate_margin(MarginCalculation sut, Money exposure)
        {
            sut.Calculate().Should().Equal(exposure);
        }

        public void can_calculate_margin_using_given_values(MarginCalculation sut)
        {
            Money collateral = Money.PoundSterling(3000);
            Money exposure = Money.PoundSterling(1000);

            Money margin = sut.Calculate();
                
            margin.Should().Equal(Money.PoundSterling(2000));
        }

        public void can_convert_money_using_invariant_culture()
        {
            //Convert.ToString(Money.PoundSterling(3000), CultureInfo.InvariantCulture).Should().Equal("£3000");
            //Money.PoundSterling(3000).ToString("C", CultureInfo.CurrentCulture).Should().Equal("£3000");
 //           Money.PoundSterling(3000).ToString("C", CultureInfo.InvariantCulture).Should().Equal("£3000");
            Money.PoundSterling(3000).ToString("C", new CultureInfo("en-gb")).Should().Equal("£3000");
        }
    }
}
