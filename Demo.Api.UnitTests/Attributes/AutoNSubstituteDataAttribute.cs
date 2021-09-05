using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using Demo.Api.UnitTests.Customizations;

namespace Demo.Api.UnitTests.Attributes
{
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        // AutoFixture: cria valores de quaisquer tipos
        // NSubstitute: mocka retornos
        // Esse atributo une os dois, gerando retornos de qualquer tipo de qualquer dependência nossa
        public AutoNSubstituteDataAttribute()
            : base(() => new Fixture().Customize(new AutoNSubstituteCustomization
            {
                ConfigureMembers = true
            }).Customize(new ScheduleRequestCustomization()))
        {
        }
    }
}
