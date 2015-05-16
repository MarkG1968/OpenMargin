using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaMoney;
using Ploeh.AutoFixture;
using Should.Fluent;

namespace MarkG1968.OpenMargin
{
    public class ExposureCalculatorTests
    {
        public void an_exposure_calculation_returns_an_exposure()
        {
            var expectedExposureAmount = new Fixture().Create<Money>();;

            var sut = new ExposureCalculator(expectedExposureAmount);

            sut.CalculateExposure().Should().Be.AssignableFrom<Exposure>();
        }
    }
}
