using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    public static Sale salesValidFake()
    {
        var entityFake = new Faker<Sale>("pt_BR")
            .RuleFor(c => c.Id, f => f.IndexFaker)
            .RuleFor(c => c.BranchId,  f => f.Random.Long(1, 1000))
            .RuleFor(c => c.Branch, branchFake)
            .RuleFor(c => c.ClientId, f => f.Random.Long(1, 1000))
            .RuleFor(c => c.Client, clientFake)
            .RuleFor(c => c.Date, f => f.Date.Recent(100))
            .RuleFor(c => c.SalesFinalPrice, f => f.Random.Decimal(1, 500))
            .RuleFor(c => c.SalesProducts, salesProductFake);

        return entityFake;
    }

    public static List<SalesProductDTO> salesProductDTOFake()
    {
        var entityFake = new Faker<SalesProductDTO>("pt_BR")
            .RuleFor(c => c.ProductId, 1)
            .RuleFor(c => c.Quantity, f => f.Random.Int(1, 19));
        var result = entityFake.Generate(5);

        return result;
    }

    public static List<SalesProduct> salesProductFake()
    {
        var entityFake = new Faker<SalesProduct>("pt_BR")
            .RuleFor(c => c.Canceled, false)
            .RuleFor(c => c.ProductId, f => f.Random.Int(1, 500))
            .RuleFor(c => c.Product, productFake)
            .RuleFor(c => c.Id, f => f.Random.Long(1, 500))
            .RuleFor(c => c.Sales, new Sale())
            .RuleFor(c => c.Quantity, f => f.Random.Int(1, 20));

        var result = entityFake.Generate(5);

        return result;
    }

    public static Branch branchFake()
    {
        var entityFake = new Faker<Branch>("pt_BR")
            .RuleFor(c => c.Id, f => 1)
            .RuleFor(c => c.Name, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female));
        return entityFake;
    }

    public static Client clientFake()
    {
        var entityFake = new Faker<Client>("pt_BR")
            .RuleFor(c => c.Id, f => 1)
            .RuleFor(c => c.Name, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Male));
        return entityFake;
    }

    public static Product productFake()
    {
        var entityFake = new Faker<Product>("pt_BR")
            .RuleFor(c => c.Id, f => 1)
            .RuleFor(c => c.Name, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Male))
            .RuleFor(c => c.Price, f => f.Random.Decimal(1, 500));

        return entityFake;
    }
}
