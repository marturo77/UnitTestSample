namespace ApplicationSample.Policy
{
    /// <summary>
    ///
    /// </summary>
    internal class PolicyService : IPolicyService
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
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
        ///
        /// </summary>
        /// <param name="policyNumber"></param>
        /// <returns></returns>

        private List<BeneficiaryInfo> GenerateSampleBeneficiaries(int policyNumber)
        {
            var beneficiaries = new List<BeneficiaryInfo>();

            for (int j = 1; j <= 3; j++) // Agrega 3 beneficiarios a cada póliza
            {
                beneficiaries.Add(new BeneficiaryInfo
                {
                    Id = j,
                    Name = $"Beneficiary {policyNumber}-{j}",
                    Genre = j % 2 == 0 ? "M" : "F"
                });
            }

            return beneficiaries;
        }
    }
}