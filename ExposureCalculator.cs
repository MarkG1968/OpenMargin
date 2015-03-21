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
        public Money CalculateExposure()
        {
            return Money.PoundSterling(4000);
        }
    }
}
