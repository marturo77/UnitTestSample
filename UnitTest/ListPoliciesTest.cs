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

            // Validar la segunda póliza
            var secondPolicy = policies[1];
            Assert.AreEqual("P-0002", secondPolicy.Id);
            Assert.AreEqual("Policy 2", secondPolicy.Name);
            Assert.AreEqual(2, secondPolicy.Beneficiaries.Count);
            Assert.AreEqual("Beneficiary 2-1", secondPolicy.Beneficiaries[0].Name);
            Assert.AreEqual("Female", secondPolicy.Beneficiaries[0].Genre);
        }

        /// <summary>
        /// Metodo mock que reemplaza el llamadado a la base de datos
        /// Aqui se ponen datos de prueba para poder revisar que sucede si algo no esta bien
        /// o esperado de la base de datos y no se tiene que generar data desde la bd
        /// </summary>
        /// <returns></returns>
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
                        new BeneficiaryInfo { Id = 1, Name = "Beneficiary 1-1", Genre = "Female" },
                        new BeneficiaryInfo { Id = 2, Name = "Beneficiary 1-2", Genre = "Male" }
                    }
                },
                new PolicyInfo
                {
                    Id = "P-0002",
                    Name = "Policy 2",
                    Beneficiaries = new List<BeneficiaryInfo>
                    {
                        new BeneficiaryInfo { Id = 1, Name = "Beneficiary 2-1", Genre = "Female" },
                        new BeneficiaryInfo { Id = 2, Name = "Beneficiary 2-2", Genre = "Male" }
                    }
                }
            };
        }
    }
}