﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodaMoney;

namespace MarkG1968.OpenMargin
{
    public interface IExposureCalculation
    {
        Money CalculateExposure();
    }
}
