using System.Collections.Generic;

namespace ApplicationSample.Policy
{
    /// <summary>
    /// Servicio para gestionar pólizas y beneficiarios
    /// </summary>
    internal class PolicyService : IPolicyService
    {
        /// <summary>
        /// Obtiene la lista de pólizas de la base de datos
        /// </summary>
        /// <returns>Lista de pólizas</returns>
        public List<PolicyInfo> GetPolicies()
        {
            var policies = new List<PolicyInfo>();

            for (int i = 1; i <= 10; i++)
            {
                policies.Add(new PolicyInfo
                {
                    Id = $"P-{i:D4}",
                    Name = $"Policy {i}",
                    Beneficiaries = GenerateSampleBeneficiaries(i)
                });
            }

            return policies;
        }

        /// <summary>
        /// Genera una lista de beneficiarios con relaciones predefinidas
        /// </summary>
        /// <param name="policyNumber">Número de póliza</param>
        /// <returns>Lista de beneficiarios</returns>

        private List<BeneficiaryInfo> GenerateSampleBeneficiaries(int policyNumber)
        {
            var beneficiaries = new List<BeneficiaryInfo>();
            var random = new Random();

            // Lista de relaciones posibles, excluyendo "COTIZANTE" para los beneficiarios aleatorios
            var relationships = new List<string> { "HIJO", "PADRE", "MADRE" };

            for (int j = 1; j <= 3; j++) // Agrega 3 beneficiarios a cada póliza
            {
                beneficiaries.Add(new BeneficiaryInfo
                {
                    Id = j,
                    Name = $"BeneficiaryName {policyNumber}-{j}",
                    Genre = j % 2 == 0 ? "M" : "F",
                    RelationShip = j == 1 ? "COTIZANTE" : relationships[random.Next(relationships.Count)]
                });
            }

            return beneficiaries;
        }
    }
}