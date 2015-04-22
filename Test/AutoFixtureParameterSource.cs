using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fixie;
using System.Reflection;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace MarkG1968.OpenMargin.Test
{
    public class AutoFixtureParameterSource : ParameterSource
    {
        readonly Ploeh.AutoFixture.Fixture autoFixture;
        
        public AutoFixtureParameterSource()
        {
            autoFixture = new Ploeh.AutoFixture.Fixture();
//            autoFixture.Customize(new AutoMoqCustomization());
        }

        IEnumerable<object[]> ParameterSource.GetParameters(MethodInfo methodInfo)
        {
            var parameterTypes = methodInfo.GetParameters().Select(x => x.ParameterType);

            var parameterValues = parameterTypes.Select(type => autoFixture.Create(type)).ToArray();

            return new[] { parameterValues };
        }
    }
}
