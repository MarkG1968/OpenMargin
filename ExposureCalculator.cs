using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaMoney;

namespace MarkG1968.OpenMargin
{
    public class ExposureCalculator : IExposureCalculation
    {
        private Money exposure;

        public ExposureCalculator(Money exposure)
        {
            this.exposure = exposure;
        }

        public Exposure CalculateExposure()
        {
            return exposure;
        }
    }
}
