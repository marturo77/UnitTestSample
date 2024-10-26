using ApplicationSample.Policy;
using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Lista de pólizas del excel");

IPolicyService policyService = new PolicyWrongService();
var policies = policyService.GetPolicies();

// Calcular el ancho máximo para cada columna
int policyIdWidth = Math.Max("Policy ID".Length, policies.Max(p => p.Id.Length));
int policyNameWidth = Math.Max("Policy Name".Length, policies.Max(p => p.Name.Length));
int beneficiaryNameWidth = "Beneficiary Name".Length;
int beneficiaryGenreWidth = "Beneficiary Genre".Length;
int beneficiaryRelationWidth = "Beneficiary Relationship".Length;

foreach (var policy in policies)
{
    foreach (var beneficiary in policy.Beneficiaries)
    {
        beneficiaryNameWidth = Math.Max(beneficiaryNameWidth, beneficiary.Name.Length);
        beneficiaryGenreWidth = Math.Max(beneficiaryGenreWidth, beneficiary.Genre.Length);
        beneficiaryRelationWidth = Math.Max(beneficiaryRelationWidth, beneficiary.RelationShip.Length);
    }
}

// Imprimir encabezado de la tabla sin el ID de beneficiario
Console.Write($"{"Policy ID".PadRight(policyIdWidth)} | {"Policy Name".PadRight(policyNameWidth)} | ");
for (int i = 1; i <= 3; i++)
{
    Console.Write($"{"Beneficiary Name".PadRight(beneficiaryNameWidth)} | {"Beneficiary Genre".PadRight(beneficiaryGenreWidth)} | {"Beneficiary Relationship".PadRight(beneficiaryRelationWidth)} | ");
}
Console.WriteLine();
Console.WriteLine(new string('-', policyIdWidth + policyNameWidth + (beneficiaryNameWidth + beneficiaryGenreWidth + beneficiaryRelationWidth + 9) * 3));

// Imprimir cada póliza con sus beneficiarios sin el ID de beneficiario
foreach (var policy in policies)
{
    Console.Write($"{policy.Id.PadRight(policyIdWidth)} | {policy.Name.PadRight(policyNameWidth)} |");

    for (int i = 0; i < 3; i++)
    {
        if (i < policy.Beneficiaries.Count)
        {
            var beneficiary = policy.Beneficiaries[i];
            Console.Write($" {beneficiary.Name.PadRight(beneficiaryNameWidth)} | {beneficiary.Genre.PadRight(beneficiaryGenreWidth)} | {beneficiary.RelationShip.PadRight(beneficiaryRelationWidth)} |");
        }
        else
        {
            // Columnas vacías si no hay suficientes beneficiarios
            Console.Write($" {"".PadRight(beneficiaryNameWidth)} | {"".PadRight(beneficiaryGenreWidth)} | {"".PadRight(beneficiaryRelationWidth)} |");
        }
    }
    Console.WriteLine();
}

Console.ReadKey();