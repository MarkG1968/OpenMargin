using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fixie;
using System.Reflection;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace MarkG1968.OpenMarginApi.AcceptanceTests
{
    public class AutoFixtureParameterSource : ParameterSource
    {
        readonly Ploeh.AutoFixture.Fixture autoFixture;
        
        public AutoFixtureParameterSource()
        {
            autoFixture = new Ploeh.AutoFixture.Fixture();
        }

        public IEnumerable<object[]> GetParameters(MethodInfo methodInfo)
        {
            var parameterTypes = methodInfo.GetParameters().Select(x => x.ParameterType);

            var parameterValues = parameterTypes.Select(type => autoFixture.Create(type)).ToArray();

            return new[] { parameterValues };
        }
    }
}
