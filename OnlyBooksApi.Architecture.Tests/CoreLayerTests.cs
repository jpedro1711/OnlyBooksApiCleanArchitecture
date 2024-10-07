using NetArchTest.Rules;

namespace OnlyBooksApi.Architecture.Tests
{
    public class CoreLayerTests
    {
        public const string ApplicationNamespace = "OnlyBooksApi.Application";
        public const string CoreNamespace = "OnlyBooksApi.Core";
        public const string InfrastructureNamespace = "OnlyBooksApi.Infrastructure";
        public const string WebNamespace = "OnlyBooksApi.Web";

        [Fact]
        public void Core_Should_Not_Depend_On_Other_Layers()
        {
            var assembly = typeof(OnlyBooksApi.Core.Models.Emprestimo).Assembly;

            var otherLayers = new[]
            {
                WebNamespace,
                InfrastructureNamespace,
                ApplicationNamespace,
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
