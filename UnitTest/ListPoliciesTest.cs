using ApplicationSample.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationSample.Tests
{
    [TestClass]
    public class PolicyListingTests
    {
        [TestMethod]
        public void GetPolicies_ShouldReturnCorrectPoliciesAndBeneficiaries()
        {
            // Arrange
            var mockPolicyService = new Mock<IPolicyService>();

            // Configuración del mock para que devuelva una lista de 2 pólizas ficticias
            mockPolicyService.Setup(service => service.GetPolicies()).Returns(GenerateSamplePolicies());

            // Act
            var policies = mockPolicyService.Object.GetPolicies();

            // Assert
            Assert.IsNotNull(policies);
            Assert.AreEqual(2, policies.Count);

            // Validar la primera póliza
            var firstPolicy = policies[0];
            Assert.AreEqual("P-0001", firstPolicy.Id);
            Assert.AreEqual("Policy 1", firstPolicy.Name);
            Assert.AreEqual(3, firstPolicy.Beneficiaries.Count);

            // Verificar que el primer beneficiario es "COTIZANTE"
            foreach (var policy in policies)
            {
                // Verificar que al menos uno de los otros beneficiarios también es "COTIZANTE"
                var hasAdditionalCotizante = policy.Beneficiaries.Any(b => b.RelationShip == "COTIZANTE");
                Assert.IsTrue(hasAdditionalCotizante, $"La politica '{policy.Id}' tiene un beneficiario como 'COTIZANTE'");
            }
        }

        private List<PolicyInfo> GenerateSamplePolicies()
        {
            return new List<PolicyInfo>
            {
                // Registro correcto
                new PolicyInfo
                {
                    Id = "P-0001",
                    Name = "FULANO PEREZ",
                    Beneficiaries = new List<BeneficiaryInfo>
                    {
                        new BeneficiaryInfo { Id = 2, Name = "Mama de Fulano", Genre = "Male", RelationShip = "MADRE" },
                        new BeneficiaryInfo { Id = 3, Name = "Hijo de Fulano", Genre = "Female", RelationShip = "HIJO" }
                    }
                },

                //Registro donde pancrasia aparece tambien como beneficiaria y parentesco COTIZANTE
                new PolicyInfo
                {
                    Id = "P-0002",
                    Name = "PANCRASIA MEDINA",
                    Beneficiaries = new List<BeneficiaryInfo>
                    {
                        new BeneficiaryInfo { Id = 1, Name = "PANCRASIA", Genre = "Female", RelationShip = "COTIZANTE" },
                        new BeneficiaryInfo { Id = 2, Name = "Padre de pancrasia", Genre = "Male", RelationShip = "PADRE" },
                        new BeneficiaryInfo { Id = 3, Name = "Madre de pancrasia", Genre = "Female", RelationShip = "MADRE" }
                    }
                }
            };
        }
    }
}