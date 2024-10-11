using NetArchTest.Rules;

namespace OnlyBooksApi.Architecture.Tests
{
    public class ApplicationLayerTests
    {
        public const string ApplicationNamespace = "OnlyBooksApi.Application";
        public const string CoreNamespace = "OnlyBooksApi.Core";
        public const string InfrastructureNamespace = "OnlyBooksApi.Infrastructure";
        public const string WebNamespace = "OnlyBooksApi.Web";

        [Fact]
        public void Application_Should_Depend_Only_On_Core_Layer()
        {
            var assembly = typeof(OnlyBooksApi.Application.Services.EmprestimoService).Assembly;

            var otherLayers = new[]
            {
                WebNamespace,
                InfrastructureNamespace
            };

            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherLayers)
                .GetResult();

            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Services_Should_Not_Depend_On_Concrete_Repositories()
        {
            var assembly = typeof(OnlyBooksApi.Application.Services.EmprestimoService).Assembly;

            var result = Types
                .InAssembly(assembly)
                .That()
                .ResideInNamespace("OnlyBooksApi.Application.Services")
                .ShouldNot()
                .HaveDependencyOn("OnlyBooksApi.Infrastructure.Repositories")
                .GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}
