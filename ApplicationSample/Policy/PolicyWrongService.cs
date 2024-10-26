namespace ApplicationSample.Policy
{
    /// <summary>
    /// Servicio para gestionar pólizas y beneficiarios, pero los lista mal porque
    /// deja cotizantes entre los beneficiarios
    /// </summary>
    internal class PolicyWrongService : IPolicyService
    {
        /// <summary>
        /// Obtiene la lista de pólizas de la base de datos
        /// </summary>
        /// <returns>Lista de pólizas</returns>
        public List<PolicyInfo> GetPolicies()
        {
            var policies = new List<PolicyInfo>();
            var random = new Random();
            var names = new List<string> { "CARLOS", "MARIA", "JUAN" }; // Lista de nombres posibles

            for (int i = 1; i <= 10; i++)
            {
                policies.Add(new PolicyInfo
                {
                    Id = $"P-{i:D4}",
                    Name = names[random.Next(names.Count)], // Selecciona un nombre aleatorio
                    Beneficiaries = ListaMalBeneficiarios(i)
                });
            }

            return policies;
        }

        /// <summary>
        /// Genera una lista de beneficiarios con relaciones predefinidas hacer de cuenta
        /// que esta leyendo la base de datos y devuelve la informacion
        /// </summary>
        /// <param name="policyNumber">Número de póliza</param>
        /// <returns>Lista de beneficiarios</returns>

        private List<BeneficiaryInfo> ListaMalBeneficiarios(int policyNumber)
        {
            var beneficiaries = new List<BeneficiaryInfo>();
            var random = new Random();

            // Lista de relaciones posibles, excluyendo "COTIZANTE" para los beneficiarios aleatorios
            var relationships = new List<string> { "HIJO", "PADRE", "MADRE" };

            // Listas de nombres por género
            var maleNames = new List<string> { "Carlos", "Juan", "Pedro", "Luis" }; // Nombres masculinos
            var femaleNames = new List<string> { "Maria", "Ana", "Luisa", "Carmen" }; // Nombres femeninos

            for (int j = 1; j <= 3; j++) // Agrega 3 beneficiarios a cada póliza
            {
                // Determina el género y elige un nombre correspondiente
                bool isMale = j % 2 == 0;
                string name = isMale ? maleNames[random.Next(maleNames.Count)]
                                     : femaleNames[random.Next(femaleNames.Count)];
                string genre = isMale ? "M" : "F";

                beneficiaries.Add(new BeneficiaryInfo
                {
                    Id = j,
                    Name = name,
                    Genre = genre,
                    RelationShip = relationships[random.Next(relationships.Count)]
                });
            }

            return beneficiaries;
        }
    }
}