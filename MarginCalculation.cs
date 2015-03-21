using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodaMoney;

namespace MarkG1968.OpenMargin
{
    public class MarginCalculation
    {
        private IExposureCalculation exposureCaculation;

        public MarginCalculation(IExposureCalculation exposureCaculation)
        {
            this.exposureCaculation = exposureCaculation;
        }

        public Money Calculate()
        {
            Money collateral = Money.PoundSterling(6000);
            return collateral - exposureCaculation.CalculateExposure();
        }
    }
}
