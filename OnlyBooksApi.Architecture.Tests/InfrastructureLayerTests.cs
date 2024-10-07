using NetArchTest.Rules;

namespace OnlyBooksApi.Architecture.Tests
{
    public class InfrastructureLayerTests
    {
        public const string ApplicationNamespace = "OnlyBooksApi.Application";
        public const string CoreNamespace = "OnlyBooksApi.Core";
        public const string InfrastructureNamespace = "OnlyBooksApi.Infrastructure";
        public const string WebNamespace = "OnlyBooksApi.Web";

        [Fact]
        public void Infrastructure_Should_Depend_Only_On_Core_And_Application_Layers()
        {
            var assembly = typeof(OnlyBooksApi.Infrastructure.Data.OnlyBooksDbContext).Assembly;

            var otherLayers = new[]
            {
                WebNamespace
            };

            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherLayers)
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

    }
}
