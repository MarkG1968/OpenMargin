using NodaMoney;
using Should.Fluent;
using Ploeh.AutoFixture;

namespace MarkG1968.OpenMargin.UnitTests
{
    public class MarginCallTests
    {
        public void a_margin_call_is_convertable_to_money()
        {
            var expectedExposure = new Fixture().Create<Money>();

            MarginCall sut = new MarginCall(expectedExposure.ToZeroAmount().AsCollateral(), expectedExposure.AsExposure());

            sut.AsAmount().Should().Equal(expectedExposure);
        }

        // when_the_call_is_positive_and_collateral_is_being_held_by_the_other_party_then_a_recall_is_made_upto_the_amount_being_held_by_them
        // when_the_call_is_positive_and_collateral_is_being_held_by_the_other_party_then_a_call_is_made_for_the_amount_in_excess_of_that_being_held_by_them


        public void when_the_exposure_is_positive_and_no_collateral_is_being_held_then_a_call_is_made()
        {
            var collateralAmount = Money.Euro(0).AsCollateral();
            var exposureAmount = Money.Euro(100).AsExposure();
 
            var sut = new MarginCall(collateralAmount, exposureAmount);

            sut.Action.Should().Equal(Action.Call);
        }

        public void when_the_exposure_is_positive_and_collateral_is_being_held_by_the_other_party_then_a_recall_is_made()
        {
            var collateralAmount = Money.Euro(-100).AsCollateral();
            var exposureAmount = Money.Euro(50).AsExposure();

            var sut = new MarginCall(collateralAmount, exposureAmount);

            sut.Action.Should().Equal(Action.Recall);
        }
 
        public void when_the_expsoure_is_negative_and_collateral_is_being_held_then_a_return_is_made()
        {
            var exposureAmount = Money.Euro(-100).AsExposure();
            var collateralAmount = Money.Euro(150).AsCollateral();

            var sut = new MarginCall(collateralAmount, exposureAmount);

            sut.Action.Should().Equal(Action.Return);
        }
    
        public void when_the_exposure_is_negative_and_no_collateral_is_held_then_a_delivery_is_made()
        {
            var exposureAmount = Money.Euro(-100).AsExposure();
            var collateralAmount = Money.Euro(0).AsCollateral();

            var sut = new MarginCall(collateralAmount, exposureAmount);

            sut.Action.Should().Equal(Action.Delivery);
        }

        public void when_the_exposure_is_negative_and_no_collateral_is_held_then_there_is_a_demand_anticipated()
        {
            var exposureAmount = Money.Euro(-100).AsExposure();
            var collateralAmount = Money.Euro(0).AsCollateral();

            var sut = new MarginCall(collateralAmount, exposureAmount);

            sut.IsAnticaptedDemand().Should().Be.True();
        }

        public void when_the_exposure_is_negative_and_no_collateral_is_held_then_the_call_amount_should_equal_the_exposure()
        {
            var exposureAmount = Money.Euro(-100);
            var collateralAmount = Money.Euro(0);

            var sut = new MarginCall(collateralAmount.AsCollateral(), exposureAmount.AsExposure());

            sut.AsAmount().Should().Equal(exposureAmount);
        }

        public void when_the_exposure_is_negative_and_collateral_is_held_by_the_other_party_then_a_delivery_is_made()
        {
            var exposureAmount = Money.Euro(-100).AsExposure();
            var collateralAmount = Money.Euro(-50).AsCollateral();

            var sut = new MarginCall(collateralAmount, exposureAmount);

            sut.Action.Should().Equal(Action.Delivery);
        }
    }
}
