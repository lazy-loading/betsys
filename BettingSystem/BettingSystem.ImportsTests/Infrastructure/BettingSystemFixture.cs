using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;

namespace BettingSystem.ImportsTests.Infrastructure
{
    public class BettingSystemFixture : Fixture
    {
        public BettingSystemFixture()
        {
            Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => Behaviors.Remove(b));
            Behaviors.Add(new OmitOnRecursionBehavior());
            Customizations.Add(new PropertyNameOmitter("Id"));
        }
    }
    
    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}