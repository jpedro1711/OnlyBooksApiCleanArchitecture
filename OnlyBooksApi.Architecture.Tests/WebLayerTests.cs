using NetArchTest.Rules;

namespace OnlyBooksApi.Architecture.Tests
{
    public class WebLayerTests
    {
        public const string ControllersNamespace = "OnlyBooksApi.Web.Controllers";
        public const string InfrastructureNamespace = "OnlyBooksApi.Infrastructure"; 

        [Fact]
        public void Controllers_Should_Not_Depend_On_Repositories()
        {
            var assembly = typeof(OnlyBooksApi.Web.Controllers.EmprestimoController).Assembly;

            var result = Types
                .InAssembly(assembly)
                .That()
                .ResideInNamespace(ControllersNamespace) 
                .ShouldNot()
                .HaveDependencyOn(InfrastructureNamespace) 
                .GetResult();

            Assert.True(result.IsSuccessful);
        }
    }
}
