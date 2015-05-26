using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaMoney;

namespace MarkG1968.OpenMargin
{
    public class Exposure
    {
        private Money amount;

        public Exposure(Money amount)
        {
            this.amount = amount;
        }

        public ExposureState StateForBank
        {
            get
            {
                return amount.Amount == 0 ? ExposureState.AtTheMoney : amount.Amount > 0 ? ExposureState.InTheMoney : ExposureState.OutOfTheMoney;
            }
        }

        public static explicit operator Exposure(Money amount)
        {
            return new Exposure(amount);
        }

        public static explicit operator Money(Exposure exposure)
        {
            return exposure.amount;
        }

        public Money AsAmount()
        {
            return amount;
        }
    }
}
