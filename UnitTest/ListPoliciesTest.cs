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
                Assert.AreEqual("COTIZANTE", policy.Beneficiaries[0].RelationShip, $"The first beneficiary in policy '{policy.Id}' should be 'COTIZANTE'.");

                // Verificar que al menos uno de los otros beneficiarios también es "COTIZANTE"
                var hasAdditionalCotizante = policy.Beneficiaries.Skip(1).Any(b => b.RelationShip == "COTIZANTE");
                Assert.IsTrue(hasAdditionalCotizante, $"Policy '{policy.Id}' should have at least one other 'COTIZANTE' besides the first beneficiary.");
            }
        }

        private List<PolicyInfo> GenerateSamplePolicies()
        {
            return new List<PolicyInfo>
            {
                new PolicyInfo
                {
                    Id = "P-0001",
                    Name = "Policy 1",
                    Beneficiaries = new List<BeneficiaryInfo>
                    {
                        new BeneficiaryInfo { Id = 1, Name = "Beneficiary 1-1", Genre = "Female", RelationShip = "COTIZANTE" },
                        new BeneficiaryInfo { Id = 2, Name = "Beneficiary 1-2", Genre = "Male", RelationShip = "COTIZANTE" },
                        new BeneficiaryInfo { Id = 3, Name = "Beneficiary 1-3", Genre = "Female", RelationShip = "HIJO" }
                    }
                },
                new PolicyInfo
                {
                    Id = "P-0002",
                    Name = "Policy 2",
                    Beneficiaries = new List<BeneficiaryInfo>
                    {
                        new BeneficiaryInfo { Id = 1, Name = "Beneficiary 2-1", Genre = "Female", RelationShip = "COTIZANTE" },
                        new BeneficiaryInfo { Id = 2, Name = "Beneficiary 2-2", Genre = "Male", RelationShip = "MADRE" },
                        new BeneficiaryInfo { Id = 3, Name = "Beneficiary 2-3", Genre = "Female", RelationShip = "COTIZANTE" }
                    }
                }
            };
        }
    }
}