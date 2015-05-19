using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fixie;
using MarkG1968.OpenMargin.UnitTests.Test;

namespace MarkG1968.OpenMarginApi.AcceptanceTests
{
    public class CustomConvention : Convention
    {
        public CustomConvention()
        {
            Classes
                .NameEndsWith("Tests");

            Methods
                .Where(method => method.IsVoid());

            Parameters
                .Add<FromAutoFixture>();
        }
    }
}
