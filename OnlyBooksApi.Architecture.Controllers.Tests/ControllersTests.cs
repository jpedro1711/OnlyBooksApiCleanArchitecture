using NetArchTest.Rules;

namespace OnlyBooksApi.Architecture.Controllers.Tests
{
    public class ControllersTests
    {
        public const string ApplicationNamespace = "OnlyBooksApi.Application";
        public const string CoreNamespace = "OnlyBooksApi.Core";
        public const string InfrastructureNamespace = "OnlyBooksApi.Infrastructure";
        public const string WebNamespace = "OnlyBooksApi.Web";

        [Fact]
        public void Controllers_Should_NotCall_Repositories()
        {
            var assembly = typeof(OnlyBooksApi.Web.Controllers.EmprestimoController).Assembly;

            var otherLayers = new[]
            {
                InfrastructureNamespace
            };

            var result = Types
                .InAssembly(assembly)
                .Should()
                .HaveDependencyOnAny(otherLayers)
                .GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}
