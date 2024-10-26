using ApplicationSample.Policy;

Console.WriteLine("Hello, World!");

PolicyService policyService = new PolicyService();

// Obtiene las pólizas de la base de datos
var policies = policyService.GetPolicies();

// Encabezado de la tabla
Console.Write("Policy ID   Policy Name   ");
for (int i = 1; i <= 3; i++) // Supongamos que cada póliza tiene hasta 3 beneficiarios
{
    Console.Write($"Beneficiary {i} ID   Beneficiary {i} Name       Beneficiary {i} Genre   ");
}
Console.WriteLine();
Console.WriteLine(new string('-', 110));

// Imprimir cada póliza con sus beneficiarios en una sola fila
foreach (var policy in policies)
{
    Console.Write($"{policy.Id,-12}{policy.Name,-15}");

    // Agregar los beneficiarios en columnas
    for (int i = 0; i < 3; i++) // Hasta 3 beneficiarios por póliza
    {
        if (i < policy.Beneficiaries.Count)
        {
            var beneficiary = policy.Beneficiaries[i];
            Console.Write($"{beneficiary.Id,-16}{beneficiary.Name,-22}{beneficiary.Genre,-18}");
        }
        else
        {
            // Dejar las columnas vacías si no hay suficientes beneficiarios
            Console.Write($"{string.Empty,-16}{string.Empty,-22}{string.Empty,-18}");
        }
    }
    Console.WriteLine();
}

Console.ReadKey();