using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fixie;
using MarkG1968.OpenMargin.Test;

namespace MarkG1968.OpenMargin
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
                .Add<FromInputAttributes>()
                .Add<FromAutoFixture>();
        }
    }
}
