namespace ApplicationSample.Policy
{
    /// <summary>
    ///
    /// </summary>
    public interface IPolicyService
    {
        /// <summary>
        /// Obtiene la lista de polizas de la base de datos
        /// </summary>
        /// <returns></returns>
        List<PolicyInfo> GetPolicies();
    }
}