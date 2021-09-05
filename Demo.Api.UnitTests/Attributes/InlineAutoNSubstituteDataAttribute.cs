using AutoFixture.Xunit2;

namespace Demo.Api.UnitTests.Attributes
{
    public class InlineAutoNSubstituteDataAttribute : InlineAutoDataAttribute
    {
        public InlineAutoNSubstituteDataAttribute(params object[] values)
            : base(new AutoNSubstituteDataAttribute(), values)
        {
        }
    }
}
