using ApplicationSample.Policy;
using Moq;

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
            Assert.AreEqual(2, firstPolicy.Beneficiaries.Count);
            Assert.AreEqual("Beneficiary 1-1", firstPolicy.Beneficiaries[0].Name);
            Assert.AreEqual("Female", firstPolicy.Beneficiaries[0].Genre);

            // Verificar que ningún beneficiario tenga la relación "COTIZANTE"
            foreach (var policy in policies)
            {
                foreach (var beneficiary in policy.Beneficiaries)
                {
                    Assert.AreNotEqual("COTIZANTE", beneficiary.RelationShip,
                        $"The beneficiary '{beneficiary.Name}' in policy '{policy.Id}' has an invalid relationship: COTIZANTE.");
                }
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
                        new BeneficiaryInfo { Id = 1, Name = "Beneficiary 1-1", Genre = "Female", RelationShip = "Spouse" },
                        new BeneficiaryInfo { Id = 2, Name = "Beneficiary 1-2", Genre = "Male", RelationShip = "Child" }
                    }
                },
                new PolicyInfo
                {
                    Id = "P-0002",
                    Name = "Policy 2",
                    Beneficiaries = new List<BeneficiaryInfo>
                    {
                        new BeneficiaryInfo { Id = 1, Name = "Beneficiary 2-1", Genre = "Female", RelationShip = "Parent" },
                        new BeneficiaryInfo { Id = 2, Name = "Beneficiary 2-2", Genre = "Male", RelationShip = "Sibling" }
                    }
                }
            };
        }
    }
}