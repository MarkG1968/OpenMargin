using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture.Kernel;

namespace MarkG1968.OpenMargin.UnitTests.Test
{
    public static class AutoFixtureExtensions
    {
        //Normal AutoFixture usage is to write:
        //
        //  var thing = autoFixture.Create<MyClass>();
        //
        //If all you have is an arbitrary Type object, though,
        //this extension method lets you write:
        //
        //  var thing = autoFixture.Create(type);
        public static object Create(this ISpecimenBuilder builder, Type type)
        {
            return new SpecimenContext(builder).Resolve(type);
        }
    }
}
