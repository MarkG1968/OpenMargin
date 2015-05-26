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
    public class CollateralTests
    {
        public void collateral_is_convertable_to_money()
        {
            var expectedCollateralAmount = new Fixture().Create<Money>();

            Collateral sut = new Collateral(expectedCollateralAmount);

            sut.AsAmount().Should().Equal(expectedCollateralAmount);
        }

        public void when_collateral_is_positive_it_is_held_by_the_bank()
        {
            Collateral sut = new Collateral(Money.PoundSterling(100));

            sut.IsCollateralHeld().Should().Be.True();
 
        }

        public void when_collateral_is_negative_it_is_held_by_the_other_party()
        {
            Collateral sut = new Collateral(Money.PoundSterling(-100));

            sut.IsCollateralHeldByOtherParty().Should().Be.True();

        }
    }
}
