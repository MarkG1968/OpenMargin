using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaMoney;
using Should.Fluent;
using Ploeh.AutoFixture;

namespace MarkG1968.OpenMargin.UnitTests
{
    public class ExposureTests
    {
        public void when_an_exposure_is_positive_for_the_bank_it_is_in_the_money()
        {
            var sut = new Exposure(Money.USDollar(100));

            sut.StateForBank.Should().Equal(ExposureState.InTheMoney);
        }

        public void when_an_exposure_is_negative_for_the_bank_it_is_out_of_the_money()
        {
            var sut = new Exposure(Money.USDollar(-100));

            sut.StateForBank.Should().Equal(ExposureState.OutOfTheMoney);
        }

        public void when_an_exposure_is_zero_for_the_bank_it_is_at_the_money()
        {
            var sut = new Exposure(Money.USDollar(0));

            sut.StateForBank.Should().Equal(ExposureState.AtTheMoney);
        }
 
        public void an_exposure_is_convertable_to_money()
        {
            var expectedExposureAmount = new Fixture().Create<Money>();

            Exposure sut = new Exposure(expectedExposureAmount);

            sut.AsAmount().Should().Equal(expectedExposureAmount);
        }
    }
}
