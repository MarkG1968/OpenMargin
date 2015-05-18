using NodaMoney;
using Should.Fluent;
using Ploeh.AutoFixture;

namespace MarkG1968.OpenMargin.UnitTests
{
    public class MarginCallTests
    {
        public void a_margin_call_is_convertable_to_money()
        {
            var expectedMarginCallAmount = new Fixture().Create<Money>();

            Money sut = new MarginCall(expectedMarginCallAmount);

            sut.Should().Equal(expectedMarginCallAmount);
        }

        // when_the_call_is_positive_and_collateral_is_being_held_by_the_other_party_then_a_recall_is_made_upto_the_amount_being_held_by_them
        // when_the_call_is_positive_and_collateral_is_being_held_by_the_other_party_then_a_call_is_made_for_the_amount_in_excess_of_that_being_held_by_them


        public void when_the_call_is_positive_and_no_collateral_is_being_held_then_a_call_is_made()
        {
            var collateralAmount = Money.Euro(0);
            var expectedMarginCallAmount = Money.Euro(100);
            Exposure expectedExposure = new Exposure(Money.Euro(100));

            var sut = new MarginCall(expectedMarginCallAmount, collateralAmount);

            sut.Action.Should().Equal(Action.Call);
        }

        public void when_the_call_is_positive_and_collateral_is_being_held_by_the_other_party_then_a_recall_is_made()
        {
            var collateralAmount = Money.Euro(-100);
            var expectedMarginCallAmount = Money.Euro(50);

            var sut = new MarginCall(expectedMarginCallAmount, collateralAmount);

            sut.Action.Should().Equal(Action.Recall);
        }
 
        public void when_the_call_is_negative_and_collateral_is_being_held_then_a_return_is_made()
        {
            var expectedMarginCallAmount = Money.Euro(-100);
            var collateralAmount = Money.Euro(150);

            var sut = new MarginCall(expectedMarginCallAmount, collateralAmount);

            sut.Action.Should().Equal(Action.Return);
        }
    
        public void when_the_call_is_negative_and_no_collateral_is_held_then_a_delivery_is_made()
        {
            var expectedMarginCallAmount = Money.Euro(-100);
            var collateralAmount = Money.Euro(0);

            var sut = new MarginCall(expectedMarginCallAmount, collateralAmount);

            sut.Action.Should().Equal(Action.Delivery);
        }


    }
}
